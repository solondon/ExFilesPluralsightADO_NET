using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling.SqlAzure;
using Microsoft.Practices.TransientFaultHandling;

namespace DataLayer
{

    /// <summary>
    /// Connection statistics
    /// </summary>
    public class ConnectionStatistics
    {
        public System.Collections.IDictionary OriginalStats { get; set; }
        public long ExecutionTime { get; set; }
        public long BytesReceived { get; set; }

        public ConnectionStatistics(System.Collections.IDictionary stats)
        {
            OriginalStats = stats;
            if (stats.Contains("ExecutionTime")) ExecutionTime = long.Parse(stats["ExecutionTime"].ToString());
            if (stats.Contains("BytesReceived")) BytesReceived = long.Parse(stats["BytesReceived"].ToString());
        }
    }

    public class DB
    {
        /// <summary>
        /// Last connection statistics gathered
        /// </summary>
        public static ConnectionStatistics LastStatistics { get; set; }

        /// <summary>
        /// Set to true to enable gathering statistics
        /// </summary>
        public static bool EnableStatistics { get; set; }

        public static string ConnectionString
        {
            get
            {
                string connStr = ConfigurationManager.ConnectionStrings["AWConnection"].ToString();

                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);
                sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                sb.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : sb.ConnectTimeout;

                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns an opened connection to the caller
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        { 
            RetryPolicy rp = new RetryPolicy(new ConnectionExceptionDetectionStrategy(), 3);
            
            rp.Retrying += (sender, args) =>
                {
                    // This code runs when a retry is taking place...
                    System.Diagnostics.Debug.WriteLine("Retrying... count=" + args.CurrentRetryCount.ToString());
                };

            // Open the database connection with retries
            SqlConnection conn = new SqlConnection(ConnectionString);
            //conn.OpenWithRetry(rp);

            rp.ExecuteAction(() =>
                {
                    // The action to perform with retry
                    conn.Open();
                });


            conn.StatisticsEnabled = EnableStatistics;
            conn.StateChange += conn_StateChange;
            return conn;
        }

        static void conn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            // Takes place when the connection state changes
            if (e.CurrentState == System.Data.ConnectionState.Closed)
            {
                if (((SqlConnection)sender).StatisticsEnabled)
                    LastStatistics = new ConnectionStatistics(((SqlConnection)sender).RetrieveStatistics());
            }
        }

        /// <summary>
        /// Overrides the connection timeout
        /// </summary>
        public static int ConnectionTimeout { get; set; }

        /// <summary>
        /// Property used to override the name of the application
        /// </summary>
        public static string ApplicationName
        {
            get;
            set;
        }

    }

    /// <summary>
    /// Implement a custom connection detection strategy
    /// </summary>
    public class ConnectionExceptionDetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            // Detect a network connection error
            bool isTransient = (ex is SqlException
                && ((SqlException)ex).Class == 20
                && ((SqlException)ex).Number == 53);

            // If error is different implement the default strategy
            if (!isTransient)
            {
                // Retrieve the retry mgr of the configuration
                var retryMgr = EnterpriseLibraryContainer.Current.GetInstance<RetryManager>();
                RetryPolicy rp = retryMgr.GetDefaultSqlConnectionRetryPolicy();
                isTransient = rp.ErrorDetectionStrategy.IsTransient(ex);
            }
            return isTransient;
        }
    }


}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace DataLayer
{
    public class ApplicationLog
    {

        /// <summary>
        /// Add a comment to the application log in the database
        /// </summary>
        /// <param name="comment"></param>
        public static void Add(string comment)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;

                    cmd.Parameters.Add(p1);

                    int res = cmd.ExecuteNonQuery();

                }
            }

        }

        /// <summary>
        /// Add a comment and return the last ID generated
        /// </summary>
        /// <param name="comment"></param>
        public static void Add2(string comment)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog2";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;

                    cmd.Parameters.Add(p1);

                    object res = cmd.ExecuteScalar();

                }
            }

        }

        /// <summary>
        /// Add a comment and use an output parameter
        /// </summary>
        /// <param name="comment"></param>
        public static void Add3(string comment)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog3";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;

                    cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("outid", System.Data.SqlDbType.Int);
                    p2.Direction = System.Data.ParameterDirection.Output;
                    
                    cmd.Parameters.Add(p2);

                    cmd.ExecuteNonQuery();

                    object res = p2.Value;

                }
            }

        }

        /// <summary>
        /// Add a comment and use the Return value
        /// </summary>
        /// <param name="comment"></param>
        public static void Add4(string comment)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog4";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;

                    cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
                    p2.Direction = System.Data.ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(p2);

                    cmd.ExecuteNonQuery();

                    object res = p2.Value;

                }
            }

        }

        /// <summary>
        /// Add a comment and use the Return value; sends an XML to the stored procedure
        /// </summary>
        /// <param name="comment"></param>
        public static void Add5(string comment)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog5";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;
                    cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("extra_data", System.Data.SqlDbType.Xml);
                    string xml = @"<data username=""{0}"" />"; // this must be a well formatted XML
                    string usr = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    xml = string.Format(xml, usr);
                    p2.Value = xml;
                    cmd.Parameters.Add(p2);

                    SqlParameter p3 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
                    p3.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(p3);

                    cmd.ExecuteNonQuery();

                    object res = p2.Value;

                }
            }

        }

        /// <summary>
        /// Deletes application log with an audit record
        /// </summary>
        /// <param name="appName"></param>
        public static void DeleteCommentsForAppWithAudit(string appName)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Delete the app log
                DeleteCommentsForApp(appName);

                // Log the delete
                string usr = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                string comment = "User '" + usr + "' delete all the comments";
                Add4(comment);

                scope.Complete();
            }

        }

        /// <summary>
        /// Delete all comments for a specific application
        /// </summary>
        /// <param name="appName"></param>
        public static void DeleteCommentsForApp(string appName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DeleteAppLog";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("appName", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = appName;

                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Retrieves application log details for a given application
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static DataTable GetLog(string appName)
        {
            DataTable table = new DataTable("ApplicationLog");
            SqlDataAdapter da = null;

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT id, date_added, comment, application_name, extra_data.value('(/data/@username)[1]', 'nvarchar(100)') as username FROM ApplicationLog WHERE application_name = @appname", conn);
                cmd.Parameters.Add(new SqlParameter("appname", System.Data.SqlDbType.NVarChar, 100));
                cmd.Parameters["appname"].Value = appName;

                da = new SqlDataAdapter(cmd);

                int res = da.Fill(table);
            }

            return table;
        }

        /// <summary>
        /// Retrieves application log XML details for a given application
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static string GetLogAsXML(string appName)
        {
            string res = "";

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(@"SELECT id, date_added, comment, 
application_name, 
extra_data.value('(/data/@username)[1]', 'nvarchar(100)') as username 
FROM ApplicationLog 
WHERE application_name = @appname FOR XML AUTO, XMLDATA" , conn);
                cmd.Parameters.Add(new SqlParameter("appname", System.Data.SqlDbType.NVarChar, 100));
                cmd.Parameters["appname"].Value = appName;

                XmlReader xmlr = cmd.ExecuteXmlReader();
                while (xmlr.Read())
                    res += xmlr.ReadOuterXml();
                
            }

            return res;
        }


        /// <summary>
        /// Applies the INSERT, DELETE and UPDATE operations from the disconnected data table
        /// </summary>
        /// <param name="tableLog"></param>
        /// <returns></returns>
        public static DataTable UpdateLogChanges(DataTable tableLog)
        {
            SqlDataAdapter da = new SqlDataAdapter();

            using (SqlConnection conn = DB.GetSqlConnection())
            {

                da.SelectCommand = new SqlCommand("SELECT * FROM ApplicationLog", conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                bool errMode = cmdBuilder.DataAdapter.ContinueUpdateOnError;
                // Perform up to 100 changes at once to minimize roundtrips 
                da.UpdateBatchSize = 100;

                cmdBuilder.ConflictOption = ConflictOption.CompareRowVersion;

                int res = da.Update(tableLog);
            }

            return tableLog;
        }

        /// <summary>
        /// Updates changes to the ApplicationLog in mass
        /// </summary>
        /// <param name="tableLog"></param>
        /// <returns></returns>
        public static DataTable UpdateLogChanges2(DataTable tableLog, string appName)
        {

            string xml = "";
            string xmlRow = @"<change op=""{0}"" datetime=""{1}"" comment=""{2}"" id=""{3}"" />";
            DataTable changes = tableLog.GetChanges();
            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                    xml += string.Format(xmlRow,
                        "UPDATE",
                        row["date_added"].ToString(),
                        row["comment"].ToString(),
                        row["id"].ToString());
            }

            xml = "<changes>" + xml + "</changes>";

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateLogMass";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("xmlchanges", SqlDbType.Xml));
                cmd.Parameters["xmlchanges"].Value = xml;

                // Persist changes in bulk
                cmd.ExecuteNonQuery();

                // Refresh table
                tableLog = GetLog(appName);

            }

            return tableLog;

        }

        /// <summary>
        /// Updates changes to the ApplicationLog in mass using MARS
        /// </summary>
        /// <param name="tableLog"></param>
        /// <returns></returns>
        public static DataTable UpdateLogChanges3(DataTable tableLog)
        {
            DataSet dsRes = new DataSet();
            string xml = "";
            string xmlRow = @"<change op=""{0}"" datetime=""{1}"" comment=""{2}"" id=""{3}"" />";
            DataTable changes = tableLog.GetChanges();
            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                    xml += string.Format(xmlRow,
                        "UPDATE",
                        row["date_added"].ToString(),
                        row["comment"].ToString(),
                        row["id"].ToString());
            }

            xml = "<changes>" + xml + "</changes>";

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateLogMass2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("xmlchanges", SqlDbType.Xml));
                cmd.Parameters["xmlchanges"].Value = xml;

                // Persist changes in bulk
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                int res = da.Fill(dsRes);

                // Refresh table
                tableLog = dsRes.Tables[1]; // read from the second table 

            }

            return tableLog;

        }

    }
}

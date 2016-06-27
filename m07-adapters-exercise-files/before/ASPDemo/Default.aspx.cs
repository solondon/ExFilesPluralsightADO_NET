using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack) LabelError.Text = "";

            try
            {
                //string connString = DataLayer.DB.ConnectionString;
                DataLayer.DB.ApplicationName = "ASPDemo Application";
                DataLayer.DB.ConnectionTimeout = 5;
                SqlConnection conn = DataLayer.DB.GetSqlConnection();
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                LabelError.Text = sqlex.Message;
            }
        }

        protected void LinkButtonGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.Employees es = new DataLayer.Employees();
                DataLayer.Employee employee = es.GetEmployee(int.Parse(TextBoxEID.Text));

                TextBoxFName.Text = employee.FirstName;
                TextBoxLName.Text = employee.LastName;
                TextBoxDepartment.Text = employee.DepartmentName;
                LabelDeptId.Text = employee.DepartmentId.ToString();

                DataLayer.ApplicationLog.Add4("Searched for user id: " + TextBoxEID.Text);

            }
            catch (SqlException sqlex)
            {
                // Connection error...
                LabelError.Text = sqlex.Message;
            }
            catch { }
        }

        protected void LinkButtonUpdateDepartmentName_Click(object sender, EventArgs e)
        {
            try
            {
                // A search must first be performed
                if (TextBoxEID.Text.Length > 0
                    && TextBoxDepartment.Text.Length > 0)
                {
                    DataLayer.Employees employees = new DataLayer.Employees();
                    int deptId = int.Parse(LabelDeptId.Text);
                    employees.UpdateDepartmentName(deptId, TextBoxDepartment.Text);
                }
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                LabelError.Text = sqlex.Message;
            }
            catch { }
        }

        protected void LinkButtonDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicationLog.DeleteCommentsForApp("ASPDemo Application");
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                LabelError.Text = sqlex.Message;
            }
            catch { }
        }
    }
}
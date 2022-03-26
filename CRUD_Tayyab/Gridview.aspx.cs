using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Tayyab
{
    public partial class Gridview : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-2H4EQN69;Initial Catalog=TayyabDb;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_getRecord_Click(object sender, EventArgs e)
        {

            sqlConnection.Open();
            string query = "select * from students";
            SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dataTable);
            try
            {
                sqlCommand.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                lbl_exception.Text = ex.Message;
            }
            finally
            {
                if(dataTable.Rows.Count > 0)
                {
                    GridView2.DataSource = dataTable;
                    GridView2.DataBind();
                }
            }

        }
    }
}
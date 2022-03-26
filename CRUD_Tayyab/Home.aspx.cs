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
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-2H4EQN69;Initial Catalog=TayyabDb;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true) 
            {
                for (int i = 10; i < 50; i++)
                {
                    ddl_age.Items.Add("" + i);
                }
                ddl_course.Items.Add("Computer Science");
                ddl_course.Items.Add("Eglish");
                ddl_course.Items.Add("Physics");
            }
           

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (rad_male.Checked ==true)
            {
                gender = "male";
            }
            else if(rad_female.Checked == true)
            {
                gender = "female";
            }
            con.Open();
            string query = "insert into students(S_Name, S_Pass, S_Age, S_gender, S_course) values('" + txt_name.Text + "', '" + txt_pass.Text + "', '" + ddl_age.Text + "', '" + gender + "', '"+ddl_course.Text+"')";
            SqlCommand sqlCommand = new SqlCommand(query,con);
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
                con.Close();
                Response.Redirect("Gridview.aspx");
            }
        }

        protected void btn_upd_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (rad_male.Checked == true)
            {
                gender = "male";
            }
            else if (rad_female.Checked == true)
            {
                gender = "female";
            }
            con.Open();
            string query = "update students set S_Name= '"+ txt_name.Text + "', S_Pass= '"+ txt_pass.Text + "',S_Age='"+ ddl_age.Text + "',S_gender='"+ gender + "', S_course='"+ ddl_course.Text + "' where S_ID='"+ddl_id.Text+"' ";
            SqlCommand sqlCommand = new SqlCommand(query, con);
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
                con.Close();
                Response.Write("Record updated Successfully");
            }
        }

        protected void ddl_course_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            //apne yaha id wala kam karagay tou show karaga na????
            con.Open();
            //string query = "select * from students where S_ID='" + ddl_id.Text + "' ";
            string query = "select rtrim(S_course) S_course,S_ID,S_Name,S_Pass,S_Age,rtrim(S_gender) S_gender from students where S_ID='" + ddl_id.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(query, con);
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
                if (dataTable.Rows.Count > 0)
                {
                    txt_name.Text = dataTable.Rows[0]["S_Name"].ToString();
                    txt_pass.Text = dataTable.Rows[0]["S_Pass"].ToString();
                    ddl_age.Text = dataTable.Rows[0]["S_Age"].ToString();
                 

                    if (dataTable.Rows[0]["S_gender"].ToString() == "male")
                    {
                        rad_male.Checked = true;
                    }
                    else if (dataTable.Rows[0]["S_gender"].ToString() == "female")
                    {
                        rad_female.Checked = true;
                    }

                    ddl_course.Text = dataTable.Rows[0]["S_course"].ToString();
                    //= dataTable.Rows[0]["S_course"].ToString();
                }
                con.Close();

            }
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from students where S_ID='" + ddl_del_id.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(query, con);
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
                Response.Write("Successfully deleted");
            }
        }
    }
}
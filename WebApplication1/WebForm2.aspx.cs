using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
                sc.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_student", sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          //  Response.Redirect("WebForm1.aspx?id=1");
        }


        public void loaddata()
        {

            SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_student", sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            sc.Close();

        }

        protected void OnEdit(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            loaddata();
            GridView1.Rows[e.NewEditIndex].Cells[1].Enabled = false;
        }




        protected void OnCancel(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            loaddata();
        }

        protected void OnUpdate(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gr = (GridViewRow)GridView1.Rows[e.RowIndex];
            
            TextBox txtid = gr.Cells[1].Controls[0] as TextBox;
            TextBox txtname = gr.Cells[2].Controls[0] as TextBox;
            TextBox txtemail = gr.Cells[3].Controls[0] as TextBox;

          //  int id = Int32.Parse(GridView1.DataKeys[e.RowIndex].Values[1].ToString());
            int id = Int32.Parse(txtid.Text);
            String name = txtname.Text;
            String email = txtemail.Text;

            SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlCommand sda = new SqlCommand ("update tbl_student set std_name = '" + name + " ', std_email =' " + email + " 'where std_id_pk = " + id + "", sc);
            sda.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            loaddata();
            
            sc.Close();

        }

        protected void OnDelete(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gr = GridView1.Rows[e.RowIndex];
//            Label labdel = (Label)gr.FindControl("std_id_pk");
            int val =Int32.Parse(GridView1.Rows[e.RowIndex].Cells[1].Text);
            SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlCommand sda = new SqlCommand("delete from tbl_student where std_id_pk = " + val + " ", sc);
            sda.ExecuteNonQuery();
            loaddata();
            sc.Close();
        }





    }
}
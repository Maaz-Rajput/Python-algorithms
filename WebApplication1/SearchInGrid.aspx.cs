using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class SearchInGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){


                GridView1.DataSource = loadgrid();
                GridView1.DataBind();

               DropDownList1.DataSource = loadgrid();
               DropDownList1.DataTextField = "std_name";
               DropDownList1.DataValueField = "std_id_pk";
               DropDownList1.DataBind();
            
            }
        }

        public DataTable loadgrid() {
            String constr = ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_student", sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sc.Close();
            return dt;
            
        }


       

        protected void Button1_Click(object sender, EventArgs e)
        {
            String txt =  TextBox1.Text;

        }

        protected void OnChange(object sender, EventArgs e)
        {
            String constr = ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            sc.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_student  where std_id_pk = @id", sc);
            cmd.Parameters.AddWithValue("@id" ,DropDownList1.SelectedValue.ToString());
            
            GridView1.DataSource =  cmd.ExecuteReader();
            GridView1.DataBind();
            
        }
    }
}
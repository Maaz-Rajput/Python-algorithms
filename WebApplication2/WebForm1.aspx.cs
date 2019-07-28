using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_student", sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Dropdownlist1.DataSource = dt;
            Dropdownlist1.DataTextField = "std_id_pk";
            Dropdownlist1.DataValueField = "std_name";
            Dropdownlist1.DataBind();
            sc.Close();

            Response.Write(Dropdownlist1.SelectedItem);
            Response.Write(Dropdownlist1.SelectedValue);

        }

        protected void Onchange(object sender, EventArgs e)
        {
            Response.Write("Getting clicked; " + sender.GetType().ToString());
            SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlCommand sda = new SqlCommand("select * from tbl_student where std_name = @name", sc);
            sda.Parameters.AddWithValue("@name" , Dropdownlist1.SelectedValue.ToString());
            


            GridView1.DataSource = sda.ExecuteReader();
            GridView1.DataBind();
        }
    }
}
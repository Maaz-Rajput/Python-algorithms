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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //APTECH First Class Prac
            
            Response.Write("PAKISTAN ZINDABAD");
           // Response.Write("<h1>PAKISTAN ZINDABAD</h1>");
            //Response.Redirect("<a href='WebForm1.aspx?id=1'>SET DATA</a>");
            
            

            //APtech SEcond Class Prac Connection with sqldataadopter
           /* SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_student", sc);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
            sc.Close();
            */

            //Connection with SQLcommand
           /* SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_student" , sc);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();

            GridView1.DataSource = sdr;
            GridView1.DataBind();


            sc.Close();
            */

            //sqldataadopter returned dataFill by getres Method
            /*
            GridView1.DataSource = getres();
            GridView1.DataBind();
            */

            //sqldataReader returned DATAFill By getDRres MEthod
           /*
            GridView1.DataSource = getDRres();
            GridView1.DataBind();
            */

            //DATATABLE returned DATAFill By getDTres MEthod
            /*
            GridView1.DataSource = getDTres();
            GridView1.DataBind();
            */


            GridView1.DataSource = getDTres();
            GridView1.DataBind();

            String constr = ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select std_name from tbl_student", sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "std_name";
            DropDownList1.DataValueField = "std_id_pk";
            DropDownList1.DataBind();
            sc.Close();

            

        }

        public DataSet getres() {
            SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_student", sc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
            sc.Close();
            
        }

        public IDataReader getDRres() {
            SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_student", sc);
            SqlDataReader sdr;
            sdr =  cmd.ExecuteReader();
            return sdr;
            sc.Close();
            
        }

        public DataTable getDTres() {
            SqlConnection sc = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=student;Integrated Security=True");
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_student", sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt ;
            sc.Close();
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
           // Label1.Text = Request.QueryString["id"].ToString();
        }

     

     
    }
}
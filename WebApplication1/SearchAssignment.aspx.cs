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
    public partial class SearchAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                loadgrid();
                
            }
            
        }

        public void loadgrid() {
            String constr = ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_student", sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            sc.Close();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String txt1 = TextBox1.Text;
            String col = DropDownList1.SelectedValue.ToString();

            String constr = ConfigurationManager.ConnectionStrings["studentConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(String.Format("select * from tbl_student where {0} = '" + txt1 + "'  ", col), sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            sc.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            loadgrid();
        }
    }
}
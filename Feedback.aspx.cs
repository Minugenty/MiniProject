using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMMS.User
{
    public partial class Complaint : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=ASUS-PC;Initial Catalog=mms;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.FindControl("l1").Visible = false;
                Master.FindControl("l2").Visible = true;
                string login = Session["log"].ToString();
                Session["ll"] = login;
            }
            con.Open();
            SqlCommand com = new SqlCommand("select count(*) from Tbl_Feedback;", con);
            int seq = Convert.ToInt16(com.ExecuteScalar());
            seq++;
            txtComID.Text = "C" + seq.ToString();
        }

        protected void bttnSubmit_Click(object sender, EventArgs e)
        {
            String sql = "insert into Tbl_Feedback values('"+txtComID.Text+"','"+txtUsername.Text+"','"+txtComplaint.Text+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            int k = cmd.ExecuteNonQuery();
            if(k>0)
                Response.Write("<script> alert('Saved')</script>");
            con.Close();
        }
    }
}
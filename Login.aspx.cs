using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProjectMMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string conString = "Data Source=ASUS-PC;Initial Catalog=mms;Integrated Security=True";
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String username, password;
            username = txtUsername.Text;
            password = txtPassword.Text;
            SqlConnection con = new SqlConnection(conString);
            SqlDataReader dr;
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_Login where username='" + username + "' and pasword='" + password + "'");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if(dr.Read())
                {
                    String type = dr["log_type"].ToString();

                    Session["log"] = username;
                    if (type=="user")
                    {
                        Response.Redirect("User/UDefault.aspx");
                    }
                    else if(type=="officer")
                    { Response.Redirect("Officer/ODefault.aspx"); }
                    else if(type=="admin")
                    { Response.Redirect("Admin/ADefault.aspx"); }

                }
            }
            else
            {
                lblMsg.Text = "Incorrect Username or Password";
                txtPassword.Text = " ";
                txtUsername.Text = " ";
            }
            dr.Close();
            cmd.Connection.Close();
            con.Close();
        }
        protected void btnClr_Click(object sender, EventArgs e)
        {
            txtUsername.Text = " ";
            txtPassword.Text = " ";
        }
    }
}
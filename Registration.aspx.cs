using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace ProjectMMS
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1970; i <= 2020; i++)
                drplstYear.Items.Add(i.ToString());
        }
        SqlConnection con = new SqlConnection("Data Source=ASUS-PC;Initial Catalog=mms;Integrated Security=True");
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String UserFirstName = txtfirstName.Text;
            String UserLastName = txtLastName.Text;
            String Houseno = txtHouseNo.Text;
            String DOB = drplstDay.SelectedValue + "/" + drplstMonth.SelectedValue + "/" + drplstYear.SelectedValue;
            String Address = txtAddress.Text;
            String EmailId = txtEmailId.Text;
            String PhoneNo = txtPhoneNO.Text;
            String PassWord = txtPassword.Text;
            String ConfPassword = txtConformPassword.Text;
            if (PassWord == ConfPassword)
            {
                con.Open();
                SqlCommand command = new SqlCommand("select * from Tbl_Login where username='" + txtHouseNo.Text.ToString() + "';", con);
                SqlDataReader sdr = command.ExecuteReader();
                if (sdr.HasRows)
                {
                    Label2.Visible = true;
                    btnAdd.Enabled = false;
                }
                else
                {
                    String sql = "insert into Tbl_Register values('" + UserFirstName + "','" + UserLastName + "','" + Address + "','" + EmailId + "','" + Houseno + "','" + PhoneNo + "','" + DOB + "','" + PassWord + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlCommand cmd2 = new SqlCommand("insert into Tbl_Login values('" + Houseno + "','" + PassWord + "','user')", con);
                    int k = cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    if (k > 0)
                    {
                        Response.Write("<Script> alert('saved')</script>");
                        Response.Redirect("Login.aspx");
                    }
                }
                con.Close();
            }
            else
            {
                Label1.Visible=true ;
                clear();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            txtAddress.Text = "";
            txtEmailId.Text = "";
            txtPassword.Text = "";
            txtConformPassword.Text = "";
            txtfirstName.Text = "";
            txtfirstName.Text = "";
            txtLastName.Text = "";
            txtHouseNo.Text = "";
            txtPhoneNO.Text = "";
            drplstDay.Text="";
        }
    }
}
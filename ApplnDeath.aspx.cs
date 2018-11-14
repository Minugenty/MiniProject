using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMMS.User
{
    public partial class ApplnDeath : System.Web.UI.Page
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
            for (int i = 1970; i <= 2020; i++)
                drplstYear.Items.Add(i.ToString());
            SqlCommand com = new SqlCommand("select count(*) from Tbl_Death;", con);
            Random randm = new Random();
            int r1 = randm.Next(1, 1000) + randm.Next(1, 1000);
            txtfrmno.Text = "DC" + r1 + Convert.ToString(com.ExecuteScalar());
        }
        string f;
        string p;
        string q;
        String sex;
        protected void bttnSubmit_Click(object sender, EventArgs e)
        {
            if (fupProof.HasFile)
            {
                try
                {
                    if (fupProof.PostedFile.ContentType == "application/pdf")
                    {
                        if (fupProof.PostedFile.ContentLength < 102400)
                        {
                            f = Path.GetFileName(fupProof.FileName);
                            fupProof.SaveAs(Server.MapPath("~/Docs/") + f);
                            //Status.Text = "Upload status: File uploaded!";
                        }
                        /*   else
                               Status.Text = "Upload status: The file has to be less than 100 kb!";
                       }
                       else
                           Status.Text = "Upload status: Only JPEG files are accepted!"; */
                    }
                }
                catch (Exception ex)
                {
                  //  Status.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (fupIDC.HasFile)
            {
                try
                {
                    if (fupIDC.PostedFile.ContentType == "application/pdf")
                    {
                        if (fupIDC.PostedFile.ContentLength < 102400)
                        {
                            p = Path.GetFileName(fupIDC.FileName);
                            fupIDC.SaveAs(Server.MapPath("~/Docs/") + p);
                          // Status.Text = "Upload status: File uploaded!";
                        }
                      //  else
                         //   Status.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                  //  else
                      //  Status.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                  //  Status.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (fupldElgCer.HasFile)
            {
                try
                {
                    if (fupldElgCer.PostedFile.ContentType == "application/pdf")
                    {
                        if (fupldElgCer.PostedFile.ContentLength < 102400)
                        {
                            q = Path.GetFileName(fupldElgCer.FileName);
                            fupldElgCer.SaveAs(Server.MapPath("~/Images/") + q);
                         //   Status.Text = "Upload status: File uploaded!";
                        }
                      //  else
                        //    Status.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                  //  else
                   //     Status.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                   // Status.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (rdoMale.Checked)
                sex = "Male";
            if (rdoFemale.Checked)
                sex = "Female";
            
            String sql = "insert into Tbl_Death values('" + txtfrmno.Text + "','" + drplstYear.SelectedValue + "/" + drplstMonth.SelectedValue + "/" + drplstDay.SelectedValue + "','" + txtfnamedd.Text + "','" + txtperaddr.Text + "','"+txtnmfh.Text+"','"+txthos.Text+"','"+sex+"','"+txtage.Text+"','"+rtxtinfrmrnmaddr.Text+"','" + f + "','" + p + "','" + q + "','Submitted')";
            SqlCommand com = new SqlCommand(sql,con); 
            int k = com.ExecuteNonQuery();
            if(k>0)
                Response.Write("<script> alert('Saved')</script>");
            con.Close();
        }
    }
}
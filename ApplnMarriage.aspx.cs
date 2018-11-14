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
    public partial class ApplnMarriage : System.Web.UI.Page
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
            for (int i = 1970; i <= 2020; i++)
            {
                drplstRegYear.Items.Add(i.ToString());
                DropDownList3.Items.Add(i.ToString());
                drplstYear.Items.Add(i.ToString());
            }
            con.Open();
            SqlCommand com = new SqlCommand("select count(*) from Tbl_Marriage;", con);
            Random randm = new Random();
            int r1 = randm.Next(1, 1000) + randm.Next(1, 1000);
            txtfrmno.Text = "MC" + r1 + Convert.ToString(com.ExecuteScalar());
        }
        String s1, s2,wc,p;
        protected void bttnSubmit_Click(object sender, EventArgs e)
        {
            if (fupSign1.HasFile)
            {
                try
                {
                    if (fupSign1.PostedFile.ContentType == "image/jpeg")
                    {
                        if (fupSign1.PostedFile.ContentLength < 102400)
                        {
                            s1 = Path.GetFileName(fupSign1.FileName);
                            fupSign1.SaveAs(Server.MapPath("~/Images/") + s1);
                            Status1.Text = "Upload status: File uploaded!";
                        }
                        else
                            Status1.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        Status1.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    Status1.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (fupSign2.HasFile)
            {
                try
                {
                    if (fupSign2.PostedFile.ContentType == "image/jpeg")
                    {
                        if (fupSign2.PostedFile.ContentLength < 102400)
                        {
                            s2 = Path.GetFileName(fupSign2.FileName);
                            fupSign2.SaveAs(Server.MapPath("~/Images/") + s2);
                            Status2.Text = "Upload status: File uploaded!";
                        }
                        else
                            Status2.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        Status2.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    Status2.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (fupWedCard.HasFile)
            {
                try
                {
                    if (fupWedCard.PostedFile.ContentType == "application/pdf")
                    {
                        if (fupWedCard.PostedFile.ContentLength < 102400)
                        {
                            wc = Path.GetFileName(fupWedCard.FileName);
                            fupWedCard.SaveAs(Server.MapPath("~/Images/") + wc);
                            Status3.Text = "Upload status: File uploaded!";
                        }
                        else
                            Status3.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        Status3.Text = "Upload status: Only PDF files are accepted!";
                }
                catch (Exception ex)
                {
                    Status3.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (fupRegProof.HasFile)
            {
                try
                {
                    if (fupRegProof.PostedFile.ContentType == "application/pdf")
                    {
                        if (fupRegProof.PostedFile.ContentLength < 102400)
                        {
                            p = Path.GetFileName(fupRegProof.FileName);
                            fupRegProof.SaveAs(Server.MapPath("~/Images/") + p);
                            Status4.Text = "Upload status: File uploaded!";
                        }
                        else
                            Status4.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        Status4.Text = "Upload status: Only PDF files are accepted!";
                }
                catch (Exception ex)
                {
                    Status4.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            
            String sql = "insert into Tbl_Marriage values('"+txtfrmno.Text+"','" + txthusname.Text + "','" + txtwifename.Text + "','" + DropDownList3.SelectedValue + "/" + DropDownList2.SelectedValue + "/" + DropDownList1.SelectedValue + "','" + drplstRegYear.SelectedValue + "/" + drplstRegMonth.SelectedValue + "/" + drplstRegDay.SelectedValue + "','" + drplstYear.SelectedValue + "/" + drplstMonth.SelectedValue + "/" + drplstDay.SelectedValue + "','" + txtmargplace.Text + "','"+s1+"','"+s2+"','"+wc+"','"+p+"','Submitted')";
            SqlCommand cmd = new SqlCommand(sql, con);
            int k = cmd.ExecuteNonQuery();
            if (k > 0)
            {
                Response.Write("<Script> alert('saved')</script>");
                //Response.Redirect("UDefault.aspx");
            }
            con.Close();
        }
    }
}
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
    public partial class ApplnBirth : System.Web.UI.Page
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
                drplstYear.Items.Add(i.ToString());
            con.Open();
            SqlCommand com = new SqlCommand("select count(*) from Tbl_Birth;", con);
            Random randm = new Random();
            int r1 = randm.Next(1, 1000) + randm.Next(1, 1000);
            txtfrmno.Text = "BC" + r1+ Convert.ToString(com.ExecuteScalar());
        }
        String proof,sex;
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fupProof.HasFile)
            {
                try
                {
                    if (fupProof.PostedFile.ContentType == "application/pdf")
                    {
                        if (fupProof.PostedFile.ContentLength < 102400)
                        {
                            proof = Path.GetFileName(fupProof.FileName);
                            fupProof.SaveAs(Server.MapPath("~/Images/") + proof);
                            Status.Text = "Upload status: File uploaded!";
                        }
                        else
                            Status.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        Status.Text = "Upload status: Only PDF files are accepted!";
                }
                catch (Exception ex)
                {
                    Status.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (rdoMale.Checked)
                sex = "Male";
            if (rdoFemale.Checked)
                sex = "Female";
            
            String sql = "insert into Tbl_Birth values('"+txtfrmno.Text+"','" + txtNameApplcnt.Text + "','" + txtAddr.Text + "','"+txtNeed.Text+"','"+txtRelation.Text+"','"+txtPlcofbrth.Text+"','"+txtNameofmthr.Text+"','"+txtNameoffthr.Text+"','"+sex+"','" + drplstYear.SelectedValue + "/" + drplstMonth.SelectedValue + "/" + drplstDay.SelectedValue + "','" + txtNameHsptl.Text + "','" + txtFadradr.Text + "','" + txtMthraddr.Text + "','" + proof + "','" + txtRqst.Text + "','Submitted')";
            SqlCommand cmd = new SqlCommand(sql, con);
            int k = cmd.ExecuteNonQuery();
            if (k > 0)
            {
                Response.Write("<script>alert('Application successful');</script>");
            }
            con.Close();
        }
    }
}
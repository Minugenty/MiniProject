using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace ProjectMMS.User
{
    public partial class ApplnStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.FindControl("l1").Visible = false;
                Master.FindControl("l2").Visible = true;
                string login = Session["log"].ToString();
                Session["ll"] = login;
            }
        }
        SqlConnection con = new SqlConnection("Data Source=ASUS-PC;Initial Catalog=mms;Integrated Security=True");
        protected void bttnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            if (rdoBirth.Checked)
            {
                String sql = "select status from Tbl_Birth where fno='" + txtfrmno.Text.ToString() + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    TextBox1.Text = sdr["status"].ToString();
            }
            if (rdoMarriage.Checked)
            {
                String sql = "select status from Tbl_Marriage where fno='" + txtfrmno.Text.ToString() + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    TextBox1.Text = sdr["status"].ToString();
            }
            if (rdoDeath.Checked)
            {
                String sql = "select status from Tbl_Death where fno='" + txtfrmno.Text.ToString() + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    TextBox1.Text = sdr["status"].ToString();
            }
            if (TextBox1.Text == "Approved")
            {
                Button1.Enabled = true;
            }
            con.Close();
        }
      /*  private DataTable GetData(string query)
        {
            // string conString = "Data Source=ASUS-PC;Initial Catalog=mms;Integrated Security=True";
           // SqlCommand cmd = new SqlCommand(query,con);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
           // sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        } */
        protected void btn_Download(object sender, EventArgs e)
        {
            con.Open();
            String query;

            Document document = new Document(PageSize.A4, 88f, 88f, 20f, 10f);
            FontFactory.RegisterDirectories();
            Font NormalFont = FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, BaseColor.BLACK);
            if (rdoBirth.Checked)
            {
                query = "select * from Tbl_Birth where fno='" + txtfrmno.Text.ToString() + "';";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.Rows[0];
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    BaseColor color = null;

                    document.Open();

                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    //Company Logo
                    cell = ImageCell("~/images/kg.png", 5f, PdfPCell.ALIGN_LEFT);
                    table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk("\nFORM No.5\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLDITALIC, BaseColor.BLACK)));
                    phrase.Add(new Chunk("GOVERNMENT OF KERALA\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("DEPARTMENT OF MUNICIPALITY\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("Name of Local Government issuing certificate : Kottayam Municipality\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                    DrawLine(writer, 25f, document.Top - 99f, document.PageSize.Width - 25f, document.Top - 99f, color);
                    DrawLine(writer, 25f, document.Top - 100f, document.PageSize.Width - 25f, document.Top - 100f, color);
                    document.Add(table);

                    table = new PdfPTable(2);
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 1f, 1f });
                    table.SpacingBefore = 20f;

                    //Employee Details
                    cell = PhraseCell(new Phrase("BIRTH CERTIFICATE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("(Issued Under Section 12)", FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("\n\n(Issued under Section 12 of the Registration of Births and Deaths Acts, 1969 and Rule 8 of the Kerala Registration of Births and Deaths Rules, 1999)\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("This is to certify that the following information has been taken from the original record of birth which is the register for (local area/ local body) Kottayam Municiplality of District Kottayam of State Kerala.\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    document.Add(table);
                   
                    table = new PdfPTable(2);
                    table.SetWidths(new float[] { 2f, 2f });
                    table.TotalWidth = 340f;
                    table.LockedWidth = true;
                    table.SpacingBefore = 20f;
                    table.HorizontalAlignment = Element.ALIGN_RIGHT;

                    //Name
                    table.AddCell(PhraseCell(new Phrase("Name:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["req_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Sex
                    table.AddCell(PhraseCell(new Phrase("Sex:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["sex"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Date of Birth
                    table.AddCell(PhraseCell(new Phrase("Date of Birth:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(Convert.ToDateTime(dr["dob"]).ToString("dd MMMM, yyyy") + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Place of Birth
                    table.AddCell(PhraseCell(new Phrase("Place of Birth:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["birth_place"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));

                    //Mother
                    table.AddCell(PhraseCell(new Phrase("Name of Mother:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["mother_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Father
                    table.AddCell(PhraseCell(new Phrase("Name of Father:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["father_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Address
                    table.AddCell(PhraseCell(new Phrase("Permanent Address\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    phrase = new Phrase(new Chunk(dr["father_addr"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)));
                    table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Date of Issue
                    table.AddCell(PhraseCell(new Phrase("Date of Issue\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(DateTime.Now.ToString() + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    table.AddCell(PhraseCell(new Phrase("Address of the Issuing Authority\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase("Registrar of Births and Deaths,\nKottayam Municipality\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    document.Add(table);

                    table = new PdfPTable(1);
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 1f });
                    table.SpacingBefore = 20f;
                    cell = PhraseCell(new Phrase("\n\nThis certificate is computer generated and does not require any Seal/Signature in original \nThe Govt.vide G.O.(Ms) No.202 / 2012 / LSGD dated 25 / 07 / 2012 has approved this certificate as a valid document for all official purposes", FontFactory.GetFont("Times New Roman", 8, Font.ITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    document.Add(table);

                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, false);
                    BaseColor bc = new BaseColor(0, 0, 0, 65);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 50F, iTextSharp.text.Font.ITALIC, bc);
                    ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, new Phrase("Kerala Government", times), 245.5F, 480.0F, 55);
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=BC.pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
            }
            else if (rdoDeath.Checked)
            {
                query = "select * from Tbl_Death where fno='" + txtfrmno.Text.ToString() + "';";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.Rows[0];
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    BaseColor color = null;

                    document.Open();

                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    //Company Logo
                    cell = ImageCell("~/images/kg.png", 5f, PdfPCell.ALIGN_LEFT);
                    table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk("\nFORM No.5\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLDITALIC, BaseColor.BLACK)));
                    phrase.Add(new Chunk("GOVERNMENT OF KERALA\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("DEPARTMENT OF MUNICIPALITY\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("Name of Local Government issuing certificate : Kottayam Municipality\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                    DrawLine(writer, 25f, document.Top - 99f, document.PageSize.Width - 25f, document.Top - 99f, color);
                    DrawLine(writer, 25f, document.Top - 100f, document.PageSize.Width - 25f, document.Top - 100f, color);
                    document.Add(table);

                    table = new PdfPTable(2);
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 1f, 1f });
                    table.SpacingBefore = 20f;

                    //Employee Details
                    cell = PhraseCell(new Phrase("DEATH CERTIFICATE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("(Issued Under Section 12)", FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("\n\n(Issued under Section 12 of the Registration of Births and Deaths Acts, 1969 and Rule 8 of the Kerala Registration of Births and Deaths Rules, 1999)\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("This is to certify that the following information has been taken from the original record of birth which is the register for (local area/ local body) Kottayam Municiplality of District Kottayam of State Kerala.\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    document.Add(table);


                    //  DrawLine(writer, 160f, 80f, 160f, 690f, BaseColor.BLACK);
                    // DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, BaseColor.BLACK);

                    table = new PdfPTable(2);
                    table.SetWidths(new float[] { 2f, 2f });
                    table.TotalWidth = 340f;
                    table.LockedWidth = true;
                    table.SpacingBefore = 20f;
                    table.HorizontalAlignment = Element.ALIGN_RIGHT;

                    //Name
                    table.AddCell(PhraseCell(new Phrase("Name:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["req_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Sex
                    table.AddCell(PhraseCell(new Phrase("Sex:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["sex"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Date of Birth
                    table.AddCell(PhraseCell(new Phrase("Date of Birth:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(Convert.ToDateTime(dr["dob"]).ToString("dd MMMM, yyyy") + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Place of Birth
                    table.AddCell(PhraseCell(new Phrase("Place of Birth:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["birth_place"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));

                    //Mother
                    table.AddCell(PhraseCell(new Phrase("Name of Mother:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["mother_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Father
                    table.AddCell(PhraseCell(new Phrase("Name of Father:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["father_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Address
                    table.AddCell(PhraseCell(new Phrase("Permanent Address\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    phrase = new Phrase(new Chunk(dr["father_addr"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)));
                    table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Date of Issue
                    table.AddCell(PhraseCell(new Phrase("Date of Issue\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(DateTime.Now.ToString() + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    table.AddCell(PhraseCell(new Phrase("Address of the Issuing Authority\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase("Registrar of Births and Deaths,\nKottayam Municipality\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    document.Add(table);

                    table = new PdfPTable(1);
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 1f });
                    table.SpacingBefore = 20f;
                    cell = PhraseCell(new Phrase("\n\nThis certificate is computer generated and does not require any Seal/Signature in original \nThe Govt.vide G.O.(Ms) No.202 / 2012 / LSGD dated 25 / 07 / 2012 has approved this certificate as a valid document for all official purposes", FontFactory.GetFont("Times New Roman", 8, Font.ITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    document.Add(table);

                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, false);
                    BaseColor bc = new BaseColor(0, 0, 0, 65);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 50F, iTextSharp.text.Font.ITALIC, bc);
                    ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, new Phrase("Kerala Government", times), 245.5F, 480.0F, 55);



                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=DC.pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
            }
            else
            {
                query = "select * from Tbl_Marriage where fno='" + txtfrmno.Text.ToString() + "';";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.Rows[0];
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    BaseColor color = null;

                    document.Open();

                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    //Company Logo
                    cell = ImageCell("~/images/kg.png", 5f, PdfPCell.ALIGN_LEFT);
                    table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk("\nFORM No.5\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLDITALIC, BaseColor.BLACK)));
                    phrase.Add(new Chunk("GOVERNMENT OF KERALA\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("DEPARTMENT OF MUNICIPALITY\n\n", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("Name of Local Government issuing certificate : Kottayam Municipality\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                    DrawLine(writer, 25f, document.Top - 99f, document.PageSize.Width - 25f, document.Top - 99f, color);
                    DrawLine(writer, 25f, document.Top - 100f, document.PageSize.Width - 25f, document.Top - 100f, color);
                    document.Add(table);

                    table = new PdfPTable(2);
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 1f, 1f });
                    table.SpacingBefore = 20f;

                    //Employee Details
                    cell = PhraseCell(new Phrase("BIRTH CERTIFICATE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("(Issued Under Section 12)", FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("\n\n(Issued under Section 12 of the Registration of Births and Deaths Acts, 1969 and Rule 8 of the Kerala Registration of Births and Deaths Rules, 1999)\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase("This is to certify that the following information has been taken from the original record of birth which is the register for (local area/ local body) Kottayam Municiplality of District Kottayam of State Kerala.\n\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    document.Add(table);


                    //  DrawLine(writer, 160f, 80f, 160f, 690f, BaseColor.BLACK);
                    // DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, BaseColor.BLACK);

                    table = new PdfPTable(2);
                    table.SetWidths(new float[] { 2f, 2f });
                    table.TotalWidth = 340f;
                    table.LockedWidth = true;
                    table.SpacingBefore = 20f;
                    table.HorizontalAlignment = Element.ALIGN_RIGHT;

                    //Name
                    table.AddCell(PhraseCell(new Phrase("Name:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["req_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Sex
                    table.AddCell(PhraseCell(new Phrase("Sex:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["sex"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Date of Birth
                    table.AddCell(PhraseCell(new Phrase("Date of Birth:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(Convert.ToDateTime(dr["dob"]).ToString("dd MMMM, yyyy") + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Place of Birth
                    table.AddCell(PhraseCell(new Phrase("Place of Birth:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["birth_place"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));

                    //Mother
                    table.AddCell(PhraseCell(new Phrase("Name of Mother:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["mother_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Father
                    table.AddCell(PhraseCell(new Phrase("Name of Father:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["father_name"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Address
                    table.AddCell(PhraseCell(new Phrase("Permanent Address\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    phrase = new Phrase(new Chunk(dr["father_addr"] + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)));
                    table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Date of Issue
                    table.AddCell(PhraseCell(new Phrase("Date of Issue\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(DateTime.Now.ToString() + "\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    table.AddCell(PhraseCell(new Phrase("Address of the Issuing Authority\t:", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase("Registrar of Births and Deaths,\nKottayam Municipality\n\n", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    document.Add(table);

                    table = new PdfPTable(1);
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 1f });
                    table.SpacingBefore = 20f;
                    cell = PhraseCell(new Phrase("\n\nThis certificate is computer generated and does not require any Seal/Signature in original \nThe Govt.vide G.O.(Ms) No.202 / 2012 / LSGD dated 25 / 07 / 2012 has approved this certificate as a valid document for all official purposes", FontFactory.GetFont("Times New Roman", 8, Font.ITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    document.Add(table);

                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, false);
                    BaseColor bc = new BaseColor(0, 0, 0, 65);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 50F, iTextSharp.text.Font.ITALIC, bc);
                    ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, new Phrase("Kerala Government", times), 245.5F, 480.0F, 55);



                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=MC.pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
            }
           
            
        }
        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SZRBD_web
{
    public partial class DodZada : System.Web.UI.Page
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\SZRBD-5SEM-Csharp\SZRBD web\SZRBD web\App_Data\BazaDanych.mdf;Integrated Security=True");
        SqlCommand Sq;

        DataTable Pracownik;

        String indexPracownika;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select IMIE, NAZWISKO, ID_PRACOWNIKA from PRACOWNIK", conn);
            Pracownik = new DataTable();
            sda.Fill(Pracownik);

            if (!IsPostBack)
            {
                divThankYou.Visible = false;

                int xTabeli1 = Pracownik.Rows.Count;
                for (int i = 0; i<xTabeli1; i++)
                {
                    DropDownListPodania2.Items.Add(Pracownik.Rows[i][0]+" "+ Pracownik.Rows[i][1]);
                }
            }
            SprawdzanieSesji();
        }

        protected void SprawdzanieSesji()
        {
            if (Session["INDEXP"] == null)
            {
                indexPracownika = "1";
            }
            else
            if (Session["INDEXP"] != null)
            {
                indexPracownika = Session["INDEXP"].ToString();
            }
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }

        protected void ButtonDodPrW_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }

        protected void ButtonDodPrD_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO ZADANIA (ID_PRACOWNIKA, NAZWA_ZADANIA, CZY_WYKONANE) VALUES ('" + indexPracownika + "','" + TextBox2.Text + "','false')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();


            ButtonDodPrD.Enabled = false;
            ButtonDodPrW.Enabled = false;

            lblmessage.Text = "Pomyślnie Dodano!";
            divThankYou.Visible = true;
        }

        protected void DropDownListPodania2_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexPracownika = Convert.ToString(Pracownik.Rows[DropDownListPodania2.SelectedIndex][2]);
            Session["INDEXP"] = indexPracownika;
        }
    }
}
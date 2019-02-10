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
    public partial class EdyZada : System.Web.UI.Page
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\SZRBD-5SEM-Csharp\SZRBD web\SZRBD web\App_Data\BazaDanych.mdf;Integrated Security=True");
        SqlCommand Sq;

        DataTable Pracownik;
        DataTable Zadanie;

        String indexPracownika;

        String IDPr;

        protected void Page_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select IMIE, NAZWISKO, ID_PRACOWNIKA from PRACOWNIK", conn);
            Pracownik = new DataTable();
            sda.Fill(Pracownik);

            IDPr = Convert.ToString(Session["IDwybrane"]);
            SprawdzanieSesji();
            if (!IsPostBack)
            {
                divThankYou.Visible = false;
                div1.Visible = false;
                div2.Visible = false;

                int xTabeli1 = Pracownik.Rows.Count;
                for (int i = 0; i < xTabeli1; i++)
                {
                    DropDownListPodania2.Items.Add(Pracownik.Rows[i][0] + " " + Pracownik.Rows[i][1]);
                }

                sda = new SqlDataAdapter("select * from ZADANIA where ID_ZADANIA='"+IDPr+"'", conn);
                Zadanie = new DataTable();
                sda.Fill(Zadanie);

                for (int i = 0; i < xTabeli1; i++)
                {
                    if(Convert.ToString(Zadanie.Rows[0][1]).Equals(Convert.ToString(Pracownik.Rows[i][2])))
                    {
                        DropDownListPodania2.SelectedIndex = i;
                        indexPracownika = Convert.ToString(Pracownik.Rows[i][2]);
                        Session["INDEXP"] = Convert.ToString(Pracownik.Rows[i][2]);
                    }
                }

                TextBox2.Text = Convert.ToString(Zadanie.Rows[0][2]);

                if (Convert.ToString(Zadanie.Rows[0][3]).Equals("True"))
                {
                    CheckBox1.Checked = true;
                }
            }           
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

        protected void ButtonDodPrU_Click(object sender, EventArgs e)
        {
            div2.Visible = true;
            Label7.Text = "Czy napewno chcesz usunąć tego Pracownika?";


            ButtonDodPrD0.Enabled = false;
            ButtonDodPrW.Enabled = false;
            ButtonDodPrD.Enabled = false;
        }

        protected void ButtonDodPrE_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE ZADANIA set ID_PRACOWNIKA='" + indexPracownika + "', NAZWA_ZADANIA='" + TextBox2.Text + "', CZY_WYKONANE='"+CheckBox1.Checked+"' where ID_ZADANIA='" + IDPr + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            ButtonDodPrD0.Enabled = false;
            ButtonDodPrW.Enabled = false;
            ButtonDodPrD.Enabled = false;

            lblmessage.Text = "Pomyślnie edytowano!";
            divThankYou.Visible = true;
        }

        protected void ButtonDodPrW_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }

        protected void DropDownListPodania2_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexPracownika = Convert.ToString(Pracownik.Rows[DropDownListPodania2.SelectedIndex][2]);
            Session["INDEXP"] = indexPracownika;
        }

        protected void ButtonPopUp1tak_Click1(object sender, EventArgs e)
        {
            div2.Visible = false;

            Sq = new SqlCommand("DELETE FROM ZADANIA WHERE ID_ZADANIA='" + IDPr + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            div1.Visible = true;
            Label3.Text = "Pomyślnie usunięto zadanie!";
        }

        protected void ButtonPopUp1nie_Click1(object sender, EventArgs e)
        {
            div2.Visible = false;
            ButtonDodPrD0.Enabled = true;
            ButtonDodPrW.Enabled = true;
            ButtonDodPrD.Enabled = true;
        }

        protected void ButtonPopUp_Click2(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }
    }
}
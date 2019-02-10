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
    public partial class MainMenu : System.Web.UI.Page
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\SZRBD-5SEM-Csharp\SZRBD web\SZRBD web\App_Data\BazaDanych.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable dtt;
        DataTable dtt2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sda = new SqlDataAdapter("select * from PRACOWNIK", conn);
                dtt = new DataTable();
                sda.Fill(dtt);
                DataTable dttbuff;

                DataTable PracownicyT = dtt.Clone();
                PracownicyT.Columns[2].DataType = typeof(String);
                PracownicyT.Columns[1].DataType = typeof(String);

                int xTabeliO = dtt.Rows.Count;

                for (int i = 0; i < xTabeliO; i++)
                {
                    PracownicyT.ImportRow(dtt.Rows[i]);
                    int yTabeli = dtt.Columns.Count;
                    for (int ii = 0; ii < yTabeli; ii++)
                    {
                        if (ii == 2)
                        {
                            sda = new SqlDataAdapter("select NAZWA_STANOWISKA from STANOWISKO where ID_STANOWISKA='" + Convert.ToString(dtt.Rows[i][ii]) + "'", conn);
                            dttbuff = new DataTable();
                            sda.Fill(dttbuff);
                            PracownicyT.Rows[i][ii] = dttbuff.Rows[0][0];
                        }
                        else
                        if (ii == 1)
                        {
                            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU='" + Convert.ToString(dtt.Rows[i][ii]) + "'", conn);
                            dttbuff = new DataTable();
                            sda.Fill(dttbuff);
                            PracownicyT.Rows[i][ii] = dttbuff.Rows[0][0];
                        }
                        else
                            PracownicyT.Rows[i][ii] = dtt.Rows[i][ii];
                    }

                }

                GridViewPrac.DataSource = PracownicyT;
                GridViewPrac.DataBind();

                wszystkie();
            }
        }

        protected void WybranyPracownik_Click(object sender, EventArgs e)
        {
            Session["IDwybrane"] = Convert.ToString((sender as LinkButton).CommandArgument);
            Response.Redirect("~/EdyPrac.aspx");
        }

        protected void WybranyPracownik2_Click(object sender, EventArgs e)
        {
            String wybranyPrac = Convert.ToString((sender as LinkButton).CommandArgument);

            sda = new SqlDataAdapter("select * from ZADANIA where ID_PRACOWNIKA='"+wybranyPrac+"' and CZY_WYKONANE='"+CheckBox1.Checked+"'", conn);
            dtt2 = new DataTable();
            sda.Fill(dtt2);
            DataTable dttbuff2;

            DataTable ZadaniaT = dtt2.Clone();
            ZadaniaT.Columns[1].DataType = typeof(String);

            int xTabeliO = dtt2.Rows.Count;
            for (int i = 0; i < xTabeliO; i++)
            {
                ZadaniaT.ImportRow(dtt2.Rows[i]);
                int yTabeli = dtt2.Columns.Count;
                for (int ii = 0; ii < yTabeli; ii++)
                {

                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select IMIE, NAZWISKO from PRACOWNIK where ID_PRACOWNIKA='" + Convert.ToString(dtt2.Rows[i][ii]) + "'", conn);
                        dttbuff2 = new DataTable();
                        sda.Fill(dttbuff2);
                        ZadaniaT.Rows[i][ii] = dttbuff2.Rows[0][0] + " " + dttbuff2.Rows[0][1];
                    }
                    else
                        ZadaniaT.Rows[i][ii] = dtt2.Rows[i][ii];
                }
            }

            GridView1.DataSource = ZadaniaT;
            GridView1.DataBind();
        }

        protected void WybraneZadanie_Click(object sender, EventArgs e)
        {
            Session["IDwybrane"] = Convert.ToString((sender as LinkButton).CommandArgument);
            Response.Redirect("~/EdyZada.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DodPrac.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DodZada.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            wszystkie();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            wszystkie();
        }

        private void wszystkie()
        {
            sda = new SqlDataAdapter("select * from ZADANIA where CZY_WYKONANE='" + CheckBox1.Checked + "'", conn);
            dtt2 = new DataTable();
            sda.Fill(dtt2);
            DataTable dttbuff2;

            DataTable ZadaniaT = dtt2.Clone();
            ZadaniaT.Columns[1].DataType = typeof(String);

            int xTabeliO = dtt2.Rows.Count;
            for (int i = 0; i < xTabeliO; i++)
            {
                ZadaniaT.ImportRow(dtt2.Rows[i]);
                int yTabeli = dtt2.Columns.Count;
                for (int ii = 0; ii < yTabeli; ii++)
                {

                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select IMIE, NAZWISKO from PRACOWNIK where ID_PRACOWNIKA='" + Convert.ToString(dtt2.Rows[i][ii]) + "'", conn);
                        dttbuff2 = new DataTable();
                        sda.Fill(dttbuff2);
                        ZadaniaT.Rows[i][ii] = dttbuff2.Rows[0][0] + " " + dttbuff2.Rows[0][1];
                    }
                    else
                        ZadaniaT.Rows[i][ii] = dtt2.Rows[i][ii];
                }
            }
        
            GridView1.DataSource = ZadaniaT;
            GridView1.DataBind();
        }
    }
}
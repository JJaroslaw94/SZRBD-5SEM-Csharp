using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZRBD_desk
{
    public partial class Form1 : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych1.mdf");

        

        public Form1()
        {
            InitializeComponent();

            //Lista Pracownika

            listView1.FullRowSelect = true;
            ListViewExtender extender1 = new ListViewExtender(listView1);
            ListViewButtonColumn buttonAction1 = new ListViewButtonColumn(5);
            buttonAction1.Click += buttonMulti1;
            buttonAction1.FixedWidth = true;
            extender1.AddColumn(buttonAction1);

            sda = new SqlDataAdapter("select * from PRACOWNIK", conn);
            DataTable Pracownicy = new DataTable();
            sda.Fill(Pracownicy);

            List<String> ListaID = new List<String>();
            List<Button> ListaPrzyciskow = new List<Button>();
            int xTabeli = Pracownicy.Rows.Count;
            for (int i = 0; i < xTabeli; i++)
            {
                ListViewItem dana = new ListViewItem(Convert.ToString(i + 1), 0);

                int yTabeli = Pracownicy.Columns.Count;
                for (int ii = 0; ii < yTabeli + 1; ii++)
                {
                    if (ii == 0)
                    {
                        ListaID.Add(Convert.ToString(Pracownicy.Rows[i][ii]));
                    }
                    else
                    if (ii == 2)
                    {
                        sda = new SqlDataAdapter("select NAZWA_STANOWISKA from STANOWISKO where ID_STANOWISKA ='" + Convert.ToString(Pracownicy.Rows[i][ii]) + "'", conn);
                        DataTable stanowisko = new DataTable();
                        sda.Fill(stanowisko);
                        dana.SubItems.Add(Convert.ToString(stanowisko.Rows[0][0]));
                    }
                    else
                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU ='" + Convert.ToString(Pracownicy.Rows[i][ii]) + "'", conn);
                        DataTable dzial = new DataTable();
                        sda.Fill(dzial);
                        dana.SubItems.Add(Convert.ToString(dzial.Rows[0][0]));
                    }
                    else
                    if (ii == yTabeli)
                    {
                        dana.SubItems.Add(Convert.ToString(Pracownicy.Rows[i][0]));
                    }
                    else
                    {
                        dana.SubItems.Add(Convert.ToString(Pracownicy.Rows[i][ii]));
                    }
                }

                listView1.Items.Add(dana);

            }

            //Lista Zadan

            WypelnianieZadan();

        }

        private void WypelnianieZadan()
        {
            listView2.Items.Clear();

            listView2.FullRowSelect = true;
            ListViewExtender extender2 = new ListViewExtender(listView2);
            ListViewButtonColumn buttonAction2 = new ListViewButtonColumn(4);
            buttonAction2.Click += buttonMulti2;
            buttonAction2.FixedWidth = true;
            extender2.AddColumn(buttonAction2);

            sda = new SqlDataAdapter("select * from ZADANIA where CZY_WYKONANE='"+checkBox1.Checked+"'", conn);
            DataTable Zadania = new DataTable();
            sda.Fill(Zadania);

            List<String> ListaID2 = new List<String>();
            List<Button> ListaPrzyciskow2 = new List<Button>();
            int xTabeli = Zadania.Rows.Count;
            for (int i = 0; i < xTabeli; i++)
            {
                ListViewItem dana = new ListViewItem(Convert.ToString(i + 1), 0);

                int yTabeli = Zadania.Columns.Count;
                for (int ii = 0; ii < yTabeli + 1; ii++)
                {
                    if (ii == 0)
                    {
                        ListaID2.Add(Convert.ToString(Zadania.Rows[i][ii]));
                    }
                    else
                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select IMIE, NAZWISKO from PRACOWNIK where ID_PRACOWNIKA ='" + Convert.ToString(Zadania.Rows[i][ii]) + "'", conn);
                        DataTable dzial = new DataTable();
                        sda.Fill(dzial);
                        dana.SubItems.Add(Convert.ToString(dzial.Rows[0][0]) + " " + Convert.ToString(dzial.Rows[0][1]));
                    }
                    else
                    if (ii == yTabeli)
                    {
                        dana.SubItems.Add(Convert.ToString(Zadania.Rows[i][0]));
                    }
                    else
                    {
                        dana.SubItems.Add(Convert.ToString(Zadania.Rows[i][ii]));
                    }
                }

                listView2.Items.Add(dana);

            }
        }

        private void buttonMulti2(object sender, ListViewColumnMouseEventArgs e)
        {
            String test = e.SubItem.Text;
            EdyZada EZ = new EdyZada(e.SubItem.Text);
            EZ.Show();
            this.Hide();
        }

        private void buttonMulti1(object sender, ListViewColumnMouseEventArgs e)
        {
            EdyPrac EP = new EdyPrac(e.SubItem.Text);
            EP.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            listView2.Items.Clear();

            listView2.FullRowSelect = true;
            ListViewExtender extender2 = new ListViewExtender(listView2);
            ListViewButtonColumn buttonAction2 = new ListViewButtonColumn(4);
            buttonAction2.Click += buttonMulti2;
            buttonAction2.FixedWidth = true;
            extender2.AddColumn(buttonAction2);

            string test = this.listView1.SelectedItems[0].Text;
            

            sda = new SqlDataAdapter("select * from ZADANIA where ID_PRACOWNIKA = '"+ test + "' and CZY_WYKONANE='" + checkBox1.Checked + "'", conn);
            DataTable Zadania = new DataTable();
            sda.Fill(Zadania);

            List<String> ListaID2 = new List<String>();
            List<Button> ListaPrzyciskow2 = new List<Button>();
            int xTabeli = Zadania.Rows.Count;
            for (int i = 0; i < xTabeli; i++)
            {
                ListViewItem dana = new ListViewItem(Convert.ToString(i + 1), 0);

                int yTabeli = Zadania.Columns.Count;
                for (int ii = 0; ii < yTabeli + 1; ii++)
                {
                    if (ii == 0)
                    {
                        ListaID2.Add(Convert.ToString(Zadania.Rows[i][ii]));
                    }
                    else
                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select IMIE, NAZWISKO from PRACOWNIK where ID_PRACOWNIKA ='" + Convert.ToString(Zadania.Rows[i][ii]) + "'", conn);
                        DataTable dzial = new DataTable();
                        sda.Fill(dzial);
                        dana.SubItems.Add(Convert.ToString(dzial.Rows[0][0]) + " " + Convert.ToString(dzial.Rows[0][1]));
                    }
                    else
                    if (ii == yTabeli)
                    {
                        dana.SubItems.Add(Convert.ToString(Zadania.Rows[i][0]));
                    }
                    else
                    {
                        dana.SubItems.Add(Convert.ToString(Zadania.Rows[i][ii]));
                    }
                }

                listView2.Items.Add(dana);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WypelnianieZadan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodawaniePracownika EP = new DodawaniePracownika();
            EP.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodawanieZadan DZ = new DodawanieZadan();
            DZ.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            WypelnianieZadan();
        }
    }
}

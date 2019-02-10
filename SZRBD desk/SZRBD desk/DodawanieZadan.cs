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
    public partial class DodawanieZadan : Form
    {

        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Pracownicy;
        

        
        String IDPRACOWNIKA ="1";

        public DodawanieZadan()
        {
            InitializeComponent();

            sda = new SqlDataAdapter("select IMIE, NAZWISKO, ID_PRACOWNIKA from PRACOWNIK", conn);
            Pracownicy = new DataTable();
            sda.Fill(Pracownicy);

            int xTab = Pracownicy.Rows.Count;
            for ( int i = 0; i < xTab; i++)
            {
                comboBox1.Items.Add(Convert.ToString(Pracownicy.Rows[i][0]) + " " + Convert.ToString(Pracownicy.Rows[i][1]));
            }

            IDPRACOWNIKA = "" + Pracownicy.Rows[0][2];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 PBDA = new Form1();
            PBDA.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO ZADANIA (ID_PRACOWNIKA, NAZWA_ZADANIA, CZY_WYKONANE) VALUES ('" + IDPRACOWNIKA + "','" + textBox1.Text + "','false')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Dodano Zadanie!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form1 PBDA = new Form1();
            PBDA.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDPRACOWNIKA = "" + Pracownicy.Rows[comboBox1.SelectedIndex][2];
        }
    }
}

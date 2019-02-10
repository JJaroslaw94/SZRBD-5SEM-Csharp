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
    public partial class DodawaniePracownika : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Stanowiska;
        String id;

        String IDDZIALU;
        String IDSTANOWISKA;

        public DodawaniePracownika()
        {
            InitializeComponent();

            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_STANOWISKA, ID_DZIALU from STANOWISKO", conn);
            Stanowiska = new DataTable();
            sda.Fill(Stanowiska);

            int ileStanowisk = Stanowiska.Rows.Count;
            for (int i = 0; i < ileStanowisk; i++)
            {
                comboBox1.Items.Add(Convert.ToString(Stanowiska.Rows[i][0]));
            }

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            int ileDzialow = Dzialy2.Rows.Count;
            for (int i = 0; i < ileDzialow; i++)
            {
                comboBox2.Items.Add(Convert.ToString(Dzialy2.Rows[i][0]));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO PRACOWNIK (ID_STANOWISKA, ID_DZIALU, IMIE, NAZWISKO) VALUES ('" + IDSTANOWISKA + "','" + IDDZIALU + "','" + textBox1.Text + "','" + textBox2.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Dodano Pracownika!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form1 PBDA = new Form1();
            PBDA.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 PBDA = new Form1();
            PBDA.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexWybranego = comboBox1.SelectedIndex;
            IDSTANOWISKA = Convert.ToString(Stanowiska.Rows[indexWybranego][1]);

            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + Convert.ToString(Stanowiska.Rows[indexWybranego][2]) + "'", conn);
            DataTable Dzialy = new DataTable();
            sda.Fill(Dzialy);

            nAZWA_DZIALULabel1.Text = Convert.ToString(Dzialy.Rows[0][0]);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexWybranego = comboBox2.SelectedIndex;

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            IDDZIALU = Convert.ToString(Dzialy2.Rows[indexWybranego][1]);
        }
    }
}

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
    

    public partial class EdyZada : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Pracownicy;

        String IDPRACOWNIKA = "1";
        String id;
        public EdyZada(String ID)
        {
            id = ID;
            InitializeComponent();

            sda = new SqlDataAdapter("select IMIE, NAZWISKO, ID_PRACOWNIKA from PRACOWNIK", conn);
            Pracownicy = new DataTable();
            sda.Fill(Pracownicy);

            int xTab = Pracownicy.Rows.Count;
            for (int i = 0; i < xTab; i++)
            {
                comboBox1.Items.Add(Convert.ToString(Pracownicy.Rows[i][0]) + " " + Convert.ToString(Pracownicy.Rows[i][1]));
            }

            sda = new SqlDataAdapter("select * from ZADANIA where ID_ZADANIA='"+id+"'", conn);
            DataTable Zadania = new DataTable();
            sda.Fill(Zadania);

            xTab = Pracownicy.Rows.Count;
            for (int i = 0; i < xTab; i++)
            {
                if (Convert.ToString(Zadania.Rows[0][1]).Equals(Convert.ToString(Pracownicy.Rows[i][2])))
                {
                    comboBox1.SelectedIndex = i;
                    String IDPRACOWNIKA = Convert.ToString(Pracownicy.Rows[i][2]);
                }
            }

            textBox1.Text = Convert.ToString(Zadania.Rows[0][2]);

            if (Convert.ToString(Zadania.Rows[0][3]).Equals("True"))
                checkBox1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 PBDA = new Form1();
            PBDA.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy napewno chcesz usunąć dane tego pracownika?", "Informacja", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Sq = new SqlCommand("DELETE FROM ZADANIA WHERE ID_ZADANIA='" + id + "'", conn);
                conn.Open();
                SqlDataReader SDR = Sq.ExecuteReader();
                conn.Close();

                MessageBox.Show("Usunięto Zadanie!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 PBDA = new Form1();
                PBDA.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE ZADANIA set ID_PRACOWNIKA='" + IDPRACOWNIKA + "', NAZWA_ZADANIA='" + textBox1.Text + "', CZY_WYKONANE='" + checkBox1.Checked + "' where ID_ZADANIA='" + id + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Zmieniono informacje!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

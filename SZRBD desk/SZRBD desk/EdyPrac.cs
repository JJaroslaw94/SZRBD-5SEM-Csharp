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
    public partial class EdyPrac : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Stanowiska;
        String id;

        String IDDZIALU;
        String IDSTANOWISKA;

        public EdyPrac(String ID)
        {
            id = ID;
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

            sda = new SqlDataAdapter("select ID_PRACOWNIKA, ID_STANOWISKA, ID_DZIALU, IMIE, NAZWISKO from PRACOWNIK where ID_PRACOWNIKA ='" + id + "'", conn);
            DataTable Pracownicy = new DataTable();
            sda.Fill(Pracownicy);


            for (int i = 0; i < ileStanowisk; i++)
            {
                if (Convert.ToString(Stanowiska.Rows[i][1]).Equals(Convert.ToString(Pracownicy.Rows[0][1])))
                {
                    comboBox1.SelectedIndex = i;
                    IDSTANOWISKA = Convert.ToString(Stanowiska.Rows[i][1]);

                    sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + Convert.ToString(Stanowiska.Rows[i][2]) + "'", conn);
                    DataTable Dzialy = new DataTable();
                    sda.Fill(Dzialy);

                    nAZWA_DZIALULabel1.Text = Convert.ToString(Dzialy.Rows[0][0]);
                }
            }


            for (int i = 0; i < ileDzialow; i++)
            {
                if (Convert.ToString(Dzialy2.Rows[i][1]).Equals(Convert.ToString(Pracownicy.Rows[0][2])))
                {
                    IDDZIALU = Convert.ToString(Dzialy2.Rows[i][1]);
                    comboBox2.SelectedIndex = i;
                }
            }

            textBox1.Text = Convert.ToString(Pracownicy.Rows[0][3]);
            textBox2.Text = Convert.ToString(Pracownicy.Rows[0][4]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE PRACOWNIK set ID_STANOWISKA='" + IDSTANOWISKA + "', ID_DZIALU='" + IDDZIALU + "', IMIE='" + textBox1.Text + "', NAZWISKO='" + textBox2.Text + "' where ID_PRACOWNIKA='" + id + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Zmieniono informacje!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form1 PBDA = new Form1();
            PBDA.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 PBDA = new Form1();
            PBDA.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int indexWybranego = comboBox1.SelectedIndex;
            IDSTANOWISKA = Convert.ToString(Stanowiska.Rows[indexWybranego][1]);

            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + Convert.ToString(Stanowiska.Rows[indexWybranego][2]) + "'", conn);
            DataTable Dzialy = new DataTable();
            sda.Fill(Dzialy);

            nAZWA_DZIALULabel1.Text = Convert.ToString(Dzialy.Rows[0][0]);
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int indexWybranego = comboBox2.SelectedIndex;

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            IDDZIALU = Convert.ToString(Dzialy2.Rows[indexWybranego][1]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select count(*) from ZADANIA where ID_PRACOWNIKA ='"+id+"'", conn);
            DataTable SprawdzanieZadan = new DataTable();
            sda.Fill(SprawdzanieZadan);

            if (Convert.ToString(SprawdzanieZadan.Rows[0][0]).Equals("0"))
            {
                if (MessageBox.Show("Czy napewno chcesz usunąć dane tego pracownika?", "Informacja",MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK )
                {
                    Sq = new SqlCommand("DELETE FROM PRACOWNIK WHERE ID_PRACOWNIKA='" + id + "'", conn);
                    conn.Open();
                    SqlDataReader SDR = Sq.ExecuteReader();
                    conn.Close();

                    MessageBox.Show("Usunięto Pracownika!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form1 PBDA = new Form1();
                    PBDA.Show();
                    this.Close();
                }
                

                
            }
            else
            {
                MessageBox.Show("Nie można usunąć pracownika! \nPracownik ten ma przypisane Zadania!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }
    }

    
}

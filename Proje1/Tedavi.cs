using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje1
{
    public partial class Tedavi : Form
    {
        public Tedavi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into TedaviTbl values('" + TedaviAdTb.Text + "','" + TutarTb.Text + "','" + AciklamaTb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show(" Tedavi Başarıyla Eklendi");
                uyeler();
                Reset();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        int key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncelenecek Tedaviyi seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update TedaviTbl set TAd='" + TedaviAdTb.Text + "',TUcret='" + TutarTb.Text + "',TAciklama='" + AciklamaTb.Text + "' where TId=" + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi işlemi başarıyla güncellendi");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("silinecek hastayı seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from TedaviTbl where TId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi başarıyla silindi");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from TedaviTbl";
            DataSet ds = Hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            TedaviAdTb.Text = "";
            TutarTb.Text = "";
            AciklamaTb.Text = "";

        }
        private void Tedavi_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
        }

        private void TedaviDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TedaviAdTb.Text = TedaviDGV.SelectedRows[0].Cells[1].Value.ToString();
            TutarTb.Text = TedaviDGV.SelectedRows[0].Cells[2].Value.ToString();
            AciklamaTb.Text = TedaviDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (TedaviAdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TedaviDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

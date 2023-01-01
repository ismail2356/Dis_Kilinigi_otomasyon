using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Proje1
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }
        ConnectionString Mycon = new ConnectionString();
        private void fillHasta()
        {
            SqlConnection baglanti = Mycon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HAd from HastaTbl",baglanti);
            SqlDataReader rdr;
            rdr=komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HAd", typeof(string));
            dt.Load(rdr);
            RadCb.ValueMember = "HAd";
            RadCb.DataSource = dt;
            baglanti.Close();

        }
        private void fillTedavi()
        {
            SqlConnection baglanti = Mycon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select TAd from TedaviTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TAd", typeof(string));
            dt.Load(rdr);
            RtedaviCb.ValueMember = "TAd";
            RtedaviCb.DataSource = dt;
            baglanti.Close();

        }
        private void Randevu_Load(object sender, EventArgs e)
        {
            fillHasta();
            fillTedavi();
            uyeler();
            Reset();
        }
        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from RandevuTbl";
            DataSet ds = Hs.ShowHasta(query);
            RandevuDgv.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            RadCb.SelectedIndex = -1;
            RtedaviCb.SelectedIndex = -1;
            Rtarih.Text = "";
            SaatCb.SelectedValue= "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("silinecek Randevuyu seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from RandevuTbl where RId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu  başarıyla silindi");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into RandevuTbl values('" + RadCb.Text + "','" + RtedaviCb.Text + "','" + Rtarih.Text + "','" + SaatCb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show(" Randevu Başarıyla Eklendi");
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
                MessageBox.Show("Güncelenecek randevuyu seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update RandevuTbl set Hasta='" + RadCb.Text + "',Tedavi='" + RtedaviCb.Text + "',RTarih='" + Rtarih.Text + "',RSaat='"+SaatCb.Text+"' where RId=" + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu işlemi başarıyla güncellendi");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void RandevuDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RadCb.SelectedValue = RandevuDgv.SelectedRows[0].Cells[1].Value.ToString();
            RtedaviCb.SelectedValue = RandevuDgv.SelectedRows[0].Cells[2].Value.ToString();
            Rtarih.Text = RandevuDgv.SelectedRows[0].Cells[3].Value.ToString();
            SaatCb.SelectedValue = RandevuDgv.SelectedRows[0].Cells[4].Value.ToString();
            if (RadCb.SelectedIndex == -1)
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(RandevuDgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void RandevuDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

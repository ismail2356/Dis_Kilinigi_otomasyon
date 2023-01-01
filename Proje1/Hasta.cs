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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into HastaTbl values('"+HAdSoyadTb.Text+"','"+HTelefonTb.Text+"','"+AdresTb.Text+"','"+HCinsiyetCb.Text+"','"+AlerjiTb.Text+"')";
            Hastalar Hs=new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show(" Hasta Başarıyla Eklendi");
                uyeler();
                Reset();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from HastaTbl";
            DataSet ds = Hs.ShowHasta(query);
            HastaDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            HAdSoyadTb.Text = "";
            HTelefonTb.Text = "";
            AdresTb.Text = "";
           
            HCinsiyetCb.SelectedItem = "";
            AlerjiTb.Text = "";
        }
        private void Hasta_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
        }
        int key = 0;
        private void HastaDGv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HTelefonTb.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            AdresTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
           
            HCinsiyetCb.Text= HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            AlerjiTb.Text = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (HAdSoyadTb.Text=="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if(key== 0)
            {
                MessageBox.Show("silinecek hastayı seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from HastaTbl where HId=" + key + "";
                   Hs.HastaSil(query);
                   MessageBox.Show("hasta başarıyla silindi");
                    uyeler();
                    Reset();

                }
                catch(Exception Ex) { 
                    MessageBox.Show(Ex.Message);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
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
                    string query = "Update HastaTbl set HAd='"+HAdSoyadTb.Text+"',HTelefon='"+HTelefonTb.Text+"',HAdres='"+AdresTb.Text+"',HCinsiyet='"+HCinsiyetCb.SelectedItem.ToString()+"',HAlerji='"+AlerjiTb.Text+"' where HId=" + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("hasta başarıyla Güncellendi");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}

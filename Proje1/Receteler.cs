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
using System.Data.SqlClient;
namespace Proje1
{
    public partial class Receteler : Form
    {
        public Receteler()
        {
            InitializeComponent();
        }
        ConnectionString Mycon = new ConnectionString();
        private void fillHasta()
        {
            SqlConnection baglanti = Mycon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HAd from HastaTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HAd", typeof(string));
            dt.Load(rdr);
            HastASCb.ValueMember = "HAd";
            HastASCb.DataSource = dt;
            baglanti.Close();

        }
        private void fillTedavi()
        {
            SqlConnection baglanti = Mycon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from RandevuTbl where Hasta='"+HastASCb.SelectedValue.ToString()+"'", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sd=new SqlDataAdapter(komut);
            sd.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                TedaviTb.Text = dr["Tedavi"].ToString();
            }
            baglanti.Close();

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Receteler_Load(object sender, EventArgs e)
        {
            fillHasta();
        }

        private void HastASCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillHasta();
        }
    }
}

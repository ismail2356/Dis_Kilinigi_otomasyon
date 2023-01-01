using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje1
{
    internal class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection baglanti=new SqlConnection();
            baglanti.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\OneDrive\Belgeler\DentalDbb.mdf;Integrated Security=True;Connect Timeout=30";
            return baglanti;
        }
    }
}

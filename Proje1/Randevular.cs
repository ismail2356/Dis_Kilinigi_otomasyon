﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1
{
    internal class Randevular
    {
        public void HastaEkle(string query)
        {
            ConnectionString Myconnection = new ConnectionString();
            SqlConnection baglanti = Myconnection.GetCon();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            baglanti.Open();
            komut.CommandText = query;
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public void HastaSil(string query)
        {

            ConnectionString Myconnection = new ConnectionString();
            SqlConnection baglanti = Myconnection.GetCon();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            baglanti.Open();
            komut.CommandText = query;
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public void HastaGuncelle(string query)
        {

            ConnectionString Myconnection = new ConnectionString();
            SqlConnection baglanti = Myconnection.GetCon();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            baglanti.Open();
            komut.CommandText = query;
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public DataSet ShowHasta(String query)
        {
            ConnectionString Myconnection = new ConnectionString();
            SqlConnection baglanti = Myconnection.GetCon();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALOgrenci
    {
        public static int OgrenciEkle(EntityOgrenci parametre)
        {
            SqlCommand komu1 = new SqlCommand("insert into TBLOGRENCI (OGRAD,OGRSOYAD,OGRNUMARA,OGRFOTO,OGRSIFRE) VALUES (@p1,@p2,@p3,@p4,@p5)", baglanti.bgl);
            if (komu1.Connection.State != ConnectionState.Open)
            {
                komu1.Connection.Open();
            }
            komu1.Parameters.AddWithValue("@p1", parametre.AD);
            komu1.Parameters.AddWithValue("@p2", parametre.SOYAD);
            komu1.Parameters.AddWithValue("@p3", parametre.NUMARA);
            komu1.Parameters.AddWithValue("@p4", parametre.FOTOGRAF);
            komu1.Parameters.AddWithValue("@p5", parametre.SIFRE);
            return komu1.ExecuteNonQuery();
        }
        public static List<EntityOgrenci> OgrenciListesi()
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut = new SqlCommand("Select * from TBLOGRENCI", baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.ID = Convert.ToInt32(dr["OGRID"].ToString());
                ent.AD = dr["OGRAD"].ToString();
                ent.SOYAD = dr["OGRSOYAD"].ToString();
                ent.NUMARA = dr["OGRNUMARA"].ToString();
                ent.FOTOGRAF = dr["OGRFOTO"].ToString();
                ent.SIFRE = dr["OGRSIFRE"].ToString();
                ent.BAKIYE = Convert.ToDouble(dr["OGRBAKIYE"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
        public static bool OgrenciSil(int parametre)
        {
            SqlCommand komut3 = new SqlCommand("Delete From TBLOGRENCI where OGRID=@P1", baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", parametre);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static List<EntityOgrenci> OgrenciDetay(int id)
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut4 = new SqlCommand("Select * from TBLOGRENCI where OGRID=@P1", baglanti.bgl);
            komut4.Parameters.AddWithValue("@P1", id);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            SqlDataReader dr = komut4.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.AD = dr["OGRAD"].ToString();
                ent.SOYAD = dr["OGRSOYAD"].ToString();
                ent.NUMARA = dr["OGRNUMARA"].ToString();
                ent.FOTOGRAF = dr["OGRFOTO"].ToString();
                ent.SIFRE = dr["OGRSIFRE"].ToString();
                ent.BAKIYE = Convert.ToDouble(dr["OGRBAKIYE"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static bool OgrenciGuncelle(EntityOgrenci deger)
        {
            SqlCommand komut5 = new SqlCommand("update TBLOGRENCI set OGRAD=@P1,OGRSOYAD=@P2,OGRNUMARA=@P3,OGRSIFRE=@P4,OGRFOTO=@P5 where OGRID=@P6", baglanti.bgl);
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            komut5.Parameters.AddWithValue("@P1", deger.AD);
            komut5.Parameters.AddWithValue("@P2", deger.SOYAD);
            komut5.Parameters.AddWithValue("@P3", deger.NUMARA);
            komut5.Parameters.AddWithValue("@P4", deger.SIFRE);
            komut5.Parameters.AddWithValue("@P5", deger.FOTOGRAF);
            komut5.Parameters.AddWithValue("@P6", deger.ID);
            return komut5.ExecuteNonQuery() > 0;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;
using DataAccessLayer;

namespace DataAccessLayer1
{
    public class DALDers
    {
        public static List<EntityDers> DersListesi()
        {
            List<EntityDers> degerler = new List<EntityDers>();
            SqlCommand komut = new SqlCommand("Select * from TBLDERSLER", baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityDers ent = new EntityDers();
                ent.ID = Convert.ToInt32(dr["DERSID"].ToString());
                ent.DERSAD = dr["DERSAD"].ToString();
                ent.MIN = Convert.ToInt32(dr["DERSMINKONT"].ToString());
                ent.MAX = Convert.ToInt32(dr["DERSMAKSKONT"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
        public static int TalepEkle(EntityBasvuruForm parametre)
        {
            SqlCommand komut = new SqlCommand("insert into TBLBASVURUFORM (OGRENCIID,DERSID) values(@P1,@P2)",baglanti.bgl);
            komut.Parameters.AddWithValue("@P1", parametre.BASOGRID);
            komut.Parameters.AddWithValue("@P2", parametre.BASDERSID);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            return komut.ExecuteNonQuery();
        }
    }
}

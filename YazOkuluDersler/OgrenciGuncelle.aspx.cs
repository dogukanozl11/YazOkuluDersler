using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

namespace YazOkuluDersler
{
    public partial class OgrenciGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Request.QueryString["OGRID"].ToString());
            Txtıd.Text = x.ToString();
            Txtıd.Enabled = false;
            if (Page.IsPostBack == false)
            {
                List<EntityOgrenci> OgrLİst = BLLOgrenci.BLLLDetay(x);
                TxtAd.Text = OgrLİst[0].AD.ToString();
                TxtSoyad.Text = OgrLİst[0].SOYAD.ToString();
                TxtNumara.Text = OgrLİst[0].NUMARA.ToString();
                TxtSifre.Text = OgrLİst[0].SIFRE.ToString();
                TxtFoto.Text = OgrLİst[0].FOTOGRAF.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci();
            ent.AD = TxtAd.Text;
            ent.SOYAD = TxtSoyad.Text;
            ent.SIFRE = TxtSifre.Text;
            ent.NUMARA = TxtNumara.Text;
            ent.FOTOGRAF = TxtFoto.Text;
            ent.ID = Convert.ToInt32(Txtıd.Text);
            BLLOgrenci.OgrenciGuncelleBLL(ent);
            Response.Redirect("OgrenciListesi.aspx");
        }
    }
}
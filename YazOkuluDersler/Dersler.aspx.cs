using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;
using EntityLayer;

namespace YazOkuluDersler
{
    public partial class Dersler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                List<EntityDers> EntDers = BLLDers.BLLListele();
                DropDownList1.DataSource = BLLDers.BLLListele();
                DropDownList1.DataTextField = "DERSAD";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //TextBox1.Text = DropDownList1.SelectedValue.ToString();
            EntityBasvuruForm ent = new EntityBasvuruForm();
            ent.BASOGRID = int.Parse(TextBox1.Text);
            ent.BASDERSID= int.Parse(DropDownList1.SelectedValue.ToString());
            BLLDers.TalepEkleBLL(ent);
        }
    }
}
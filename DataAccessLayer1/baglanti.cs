using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    internal class baglanti
    {
        public static SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-MJGGV3B;Initial Catalog=DbYazOkulu;Integrated Security=True;Encrypt=False");

    }
}

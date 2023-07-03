using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Windows.Forms;

namespace Birleştirme0205.AdminSayfa
{
    internal class GorevDetay
    {
        public class GorevDetayy
        {
            public int GorevID { get; set; }
            public string GorevVeren { get; set; }
            public string DepartmanAdi { get; set; }
            public string GorevAlan { get; set; }
            public string KategoriAdi { get; set; }
            public string GorevAdı { get; set; }
            public string Aciklama { get; set; }
            public string Durum { get; set; }
            public string EtiketAd { get; set; }
            public DateTime BaslamaTarihi { get; set; }
            public DateTime BitişTarih { get; set; }
        }
        public List<GorevDetayy> Listele()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");

            List<GorevDetayy> list = baglanti.Query<GorevDetayy>("DetaylıGorevGoruntuleme", commandType: CommandType.StoredProcedure).ToList<GorevDetayy>();
            return list;
            

        }

    }
}

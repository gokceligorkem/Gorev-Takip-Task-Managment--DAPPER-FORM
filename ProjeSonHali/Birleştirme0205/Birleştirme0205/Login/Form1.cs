using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Birleştirme0205.AdminSayfa;
using Birleştirme0205.KullanıcıSayfa;
using Dapper;
using static Birleştirme0205.AdminSayfa.Gorev;
using static Birleştirme0205.AdminSayfa.GorevDetay;

namespace Birleştirme0205
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            Init_Data();
        }
        
        public class myclass
        {
            public string AdSoyad { get; set; }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region CapsLock
            txtsifre.PasswordChar = '*';
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Caps Lock Açık");
            }
            #endregion

        }

        #region InıtData
        private void Init_Data()
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    txtkullanici.Text = Properties.Settings.Default.UserName;
                    chcHatirla.Checked = true;
                }
                else
                {
                    txtkullanici.Text = Properties.Settings.Default.UserName;
                }
            }
        }
        #endregion
        #region Save_Data
        private void Save_Data()
        {
            if (chcHatirla.Checked)
            {
                Properties.Settings.Default.UserName = txtkullanici.Text.Trim();
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }
        #endregion
        #region girisbuton
        private void btngiris_Click_1(object sender, EventArgs e)
        {
            Save_Data();

            string username = txtkullanici.Text;
            string password = txtsifre.Text;

            var parameters = new DynamicParameters();
            parameters.Add("@Ad", username);
            parameters.Add("@Sifre", password);
            var result = baglanti.QueryFirstOrDefault("LoginKosul", parameters, commandType: CommandType.StoredProcedure);
            
        
            if (result != null)
            {
                if (result.UserType) // Admin olarak giriş yapıldı
                {                  
                    AnaSayfa anasayfa = new AnaSayfa();
                    DynamicParameters ac = new DynamicParameters();
                    ac.Add("@LoginAd", txtkullanici.Text.Trim());
                    var result2 = baglanti.Query<string>("AdGetir", ac, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    anasayfa.label10.Text = "Hoşgeldin " + result2 ?? "Ad Bulunamadı";
                    anasayfa.Show();
                }
                else // Normal kullanıcı olarak giriş yapıldı
                {
                    // Girilen Kullanıcının Adını Sağ üste yazdırır
                    KullanıcıSayfa.KullanıcıSayfa ks = new KullanıcıSayfa.KullanıcıSayfa();
                    DynamicParameters cek = new DynamicParameters();
                    cek.Add("@LoginAd", txtkullanici.Text.Trim());
                    var result2 = baglanti.Query<string>("AdGetir", cek, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    ks.label3.Text = "Hoşgeldin " + result2 ?? "Ad Bulunamadı";

                    // Kullanıcının Departman Bilgisi
                    DynamicParameters dad = new DynamicParameters();
                    dad.Add("@LoginAd", txtkullanici.Text.Trim());
                    var reslt = baglanti.Query<string>("KullaniciDepartmanAdiCek", dad, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    ks.label9.Text = "Departmanı: "+ reslt ?? "Ad Bulunamadı";

                    // Tamamlanan Görevleri Göster


                    // Çalışana ait toplam görev sayısı
                    var tgs = new DynamicParameters();
                    tgs.Add("@LoginAd", txtkullanici.Text.Trim());
                    var tgsDegisken = baglanti.QueryFirstOrDefault<string>("CalisaninToplamGorevi", tgs, commandType: CommandType.StoredProcedure);
                    ks.label4.Text = tgsDegisken.ToString();

                    // Girilen Kullanıcının tamamlanan Görevlerinin Sayısını Verir
                    var parameterse = new DynamicParameters();
                    parameterse.Add("@LoginAd", txtkullanici.Text.Trim());
                    var result3 = baglanti.QueryFirstOrDefault<string>("CalisanaAitGorevler", parameterse, commandType: CommandType.StoredProcedure);
                    ks.label6.Text = result3.ToString();

                   //Girilen Kullanıcıya ait Görevleri Listele
                    DynamicParameters kag = new DynamicParameters();
                    kag.Add("@LoginAd", txtkullanici.Text.Trim());
                    List<GorevDetayy> list = baglanti.Query<GorevDetayy>("KullaniciyaAitGorevler", kag, commandType: CommandType.StoredProcedure).ToList<GorevDetayy>();
                    ks.dataGridView1.DataSource = list;
                    ks.dataGridView1.Columns[0].Visible = false;



                    ks.Show();
                }
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
                txtkullanici.Clear();
                txtsifre.Clear();
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

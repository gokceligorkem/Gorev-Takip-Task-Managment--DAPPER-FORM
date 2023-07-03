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
using Dapper;
using static Birleştirme0205.AdminSayfa.Departman;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.ObjectModel;

namespace Birleştirme0205.AdminSayfa
{
    public partial class Görevveren : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public Görevveren()
        {
            InitializeComponent();
        }
        private void Görevveren_Load(object sender, EventArgs e)
        {
            #region görevetiketcombobox
            string query = "SELECT EtiketAd FROM tblEtiket";
            List<string> etiketList = SqlCon.Query<string>(query).ToList();
            comboBox3.DataSource = etiketList;
            #endregion
            #region GorevenVeren
            string gorevveren = "select cd.Adı,cd.Soyadı from tblCalisanlar c right join tblLogin  l on l.LogınID=c.LoginID \r\ninner join tblCalisanDetay cd on cd.ID=c.CalisanDetayID where l.KullaniciTipi='True'  ";
            List<string> adminlist = new List<string>();
            foreach (var item in SqlCon.Query(gorevveren))
            {
                adminlist.Add(item.Adı + " " + item.Soyadı);
            }
            GorenVeren.DataSource = adminlist;
            #endregion
            #region Departman
            string Departman = "select DepartmanAdi from tblDepartmanlar ";
            List<string> Departmanlist = SqlCon.Query<string>(Departman).ToList();
            DepartmanCombobox.DataSource = Departmanlist;
            #endregion
            #region DurumTablosu
            string durumsorgusu = "Select Ad from tblDurumTablosu";
            List<string> durumList = SqlCon.Query<string>(durumsorgusu).ToList();
            comboBox1.DataSource = durumList;
            #endregion

            #region GorevKategorisi
            string gorevkategorisi = "select Ad from tblGorevKategori";
            List<string> gorevkategorisinilist = SqlCon.Query<string>(gorevkategorisi).ToList();
            GorevCombo.DataSource = gorevkategorisinilist;
            #endregion

        }
        class tblGorevEkleme
        {
            public string EtiketAdi { get; set; }
            public string DurumAdi { get; set; }
            public string GorevVeren { get; set; }
            public string GorevAlan { get; set; }
            public string DosyaAdı { get; set; }
            public string Aciklama { get; set; }
            public DateTime YuklemeTarihi { get; set; }
            public string GorevKategori { get; set; }
            public string GorevAd { get; set; }
            public DateTime BaslamaTarihi { get; set; }
            public DateTime BitisTarihi { get; set; }
            public string DepartmanAdi { get; set; }
        }
        public void GorevEkleme()
        {
            try
            {
                DynamicParameters ekle = new DynamicParameters();
                ekle.Add("@EtiketAdı", comboBox3.SelectedItem);
                ekle.Add("@DurumAdı", comboBox1.SelectedItem);
                ekle.Add("@GorevVeren", GorenVeren.Text.ToString());
                ekle.Add("@GorevAlan", GorevAlan.Text.ToString());
                ekle.Add("@DepartmanAdi", DepartmanCombobox.SelectedItem);

                ekle.Add("@Dosya", label4.Text);
                ekle.Add("@Aciklama", Aciklama.Text);
                ekle.Add("@YuklemeTarihi", DateTime.Now, DbType.DateTime);


                ekle.Add("@GorevKategori", GorevCombo.SelectedItem);
                ekle.Add("@GorevAd", comboBox2.SelectedItem);
                ekle.Add("@BaslamaTarihi", dateTimePicker1.Value);
                ekle.Add("@BitişTarihi", dateTimePicker2.Value);
                SqlCon.Execute("GorevAtama", ekle, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Görev Başarıyla İletildi.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
               
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            GorevEkleme();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Dosya seçin";
            openFileDialog1.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog1.FileName;
                label4.Text = openFileDialog1.FileName;
            }
        }
        public class Departmanlar
        {
            public string GorevAdı { get; set; }
        }
        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            DynamicParameters ekle = new DynamicParameters();
            ekle.Add("@GorevAd", GorevCombo.SelectedItem);


            List<Departmanlar> list = SqlCon.Query<Departmanlar>("GorevAdlarınıListele", ekle, commandType: CommandType.StoredProcedure).ToList<Departmanlar>();
            foreach (var item in list)
            {

                comboBox2.Items.Add(item.GorevAdı);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public class GorenAlanAd
        {
            public string DepartmanAdi { get; set; }
            public string AdSoyad { get; set; }



        }
        void GorevAlanListele()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DepartAdı", DepartmanCombobox.SelectedItem.ToString());

            var calisanlar = SqlCon.Query<string>("DepartmanaGorePersonelListele", parameters, commandType: CommandType.StoredProcedure).ToList();

            var gorenAlanlar = calisanlar.Select(c => new GorenAlanAd
            {
                AdSoyad = c
            }).ToList();

            GorevAlan.DataSource = new ReadOnlyCollection<GorenAlanAd>(gorenAlanlar);
            GorevAlan.DisplayMember = "AdSoyad";
            GorevAlan.ValueMember = "DepartmanAdi";


        }
        private void GorevAlan_Click(object sender, EventArgs e)
        {
            GorevAlanListele();
        }

        private void GorevAlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

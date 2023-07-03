using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birleştirme0205.AdminSayfa
{
    public partial class GorevDetayGoruntuleme : Form
    {
        // Veritabanına bağlantı kurmak için SqlConnection sınıfından bir örnek oluşturuluyor.

        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");

        // Form yüklendiğinde çalışacak olan event handler metodu
        public GorevDetayGoruntuleme()
        {
            InitializeComponent();
        }
        

        private void GorevDetayGoruntuleme_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GorevDetay GorevDetayListeleme = new GorevDetay();
            dataGridView1.DataSource = GorevDetayListeleme.Listele();
            // ComboBox kontrollerinin verileri veritabanından çekiliyor ve DataSource özelliğine atanıyor.
            #region ComboBox
            #region görevetiketcombobox
            string query = "SELECT EtiketAd FROM tblEtiket";
            List<string> etiketList = SqlCon.Query<string>(query).ToList();
            comboBox7.DataSource = etiketList;
            #endregion
            #region GorevenVeren
            string gorevveren = "select cd.Adı+ ' '+cd.Soyadı as 'AdSoyad' from tblCalisanlar c right join tblLogin  l on l.LogınID=c.LoginID \r\ninner join tblCalisanDetay cd on cd.ID=c.CalisanDetayID where l.KullaniciTipi='True'  ";
            List<string> departmanList = SqlCon.Query<string>(gorevveren).ToList();
            comboBox1.DataSource = departmanList;
            #endregion
            #region DurumTablosu
            string durumsorgusu = "Select Ad from tblDurumTablosu";
            List<string> durumList = SqlCon.Query<string>(durumsorgusu).ToList();
            comboBox6.DataSource = durumList;
            #endregion
            #region GorevKategorisi
            string gorevkategorisi = "select Ad from tblGorevKategori";
            List<string> gorevkategorisinilist = SqlCon.Query<string>(gorevkategorisi).ToList();
            comboBox4.DataSource = gorevkategorisinilist;
            #endregion
            #region Departman
            string departman = "select DepartmanAdi from tblDepartmanlar";
            List<string> departmanlist = SqlCon.Query<string>(departman).ToList();
            comboBox2.DataSource = departmanlist;
            #endregion
            #endregion
            dataGridView1.Columns[0].Visible = false;

        }

        // DataGridView1 kontrolünün hücresine çift tıklanıldığında çalışacak olan  metod
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label14.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[3].Value != null)
            {
                comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                comboBox2.Text = "";
            }
            comboBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[4].Value != null)
            {
                comboBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                comboBox5.Text = "";
            }

            textBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[8].Value != null)
            {
                comboBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            else
            {
                comboBox7.Text = "";
            }
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();


        }
        // Bu blok Departmanlar sınıfını tanımlar
        public class Departmanlar
        {
            public string GorevAdı { get; set; }
        }

        // SQL sorgusunu yürüt ve sonuçları bir Departmanlar listesinde depola
        private void comboBox5_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            DynamicParameters ekle = new DynamicParameters();
            ekle.Add("@GorevAd", comboBox4.SelectedItem);


           
            List<Departmanlar> list = SqlCon.Query<Departmanlar>("GorevAdlarınıListele", ekle, commandType: CommandType.StoredProcedure).ToList<Departmanlar>();
            // Listede dolaşarak comboBox5'e her bir Departmanlar nesnesinin GorevAdı özelliğini ekle

            foreach (var item in list)
            {

                comboBox5.Items.Add(item.GorevAdı);
            }
        }
        class GorenAlanAd
        {
            public string DepartmanAdi { get; set; }
            public string AdSoyad { get; set; }
        }
        void GorevAlanListele()
        {
            // SQL sorgusunu yürüt ve sonuçları bir string listesinde depola

            var parameters = new DynamicParameters();
            parameters.Add("@DepartAdı", comboBox2.SelectedItem.ToString());

            var calisanlar = SqlCon.Query<string>("DepartmanaGorePersonelListele", parameters, commandType: CommandType.StoredProcedure).ToList();

            // string listesinde dolaşarak her bir string değerini GorenAlanAd sınıfı için bir nesneye dönüştür
            var gorenAlanlar = calisanlar.Select(c => new GorenAlanAd
            {
                AdSoyad = c
            }).ToList();

            // comboBox3'e gorenAlanlar listesi ReadOnlyCollection olarak atanır
            // comboBox3'ün gösterilecek değeri AdSoyad özelliği ile, seçilecek değeri ise DepartmanAdi özelliği ile belirlenir.
            comboBox3.DataSource = new ReadOnlyCollection<GorenAlanAd>(gorenAlanlar);
            comboBox3.DisplayMember = "AdSoyad";
            comboBox3.ValueMember = "DepartmanAdi";

        }
        // comboBox3_Click olayı tetiklendiğinde çalışan kod bloğu
        private void comboBox3_Click(object sender, EventArgs e)
        {
            GorevAlanListele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            // Bir görevi güncellemek ve güncelleme işleminden sonra güncellenmiş görevi yeniden yükleme.
            // DynamicParameters sınıfından bir nesne oluşturarak  parametre eklenir. Sonra SqlCon.Execute() ile çağırılarak parametreler iletilir ve Görevdetaylisteleme ile listelenir.
            var parameters = new DynamicParameters();
            parameters.Add("@GorevVeren", comboBox1.SelectedItem.ToString());
            parameters.Add("@DepartmanAdi", comboBox2.SelectedItem.ToString());
            parameters.Add("@GorevAlan", comboBox3.Text.ToString());
            parameters.Add("@KategoriAdi", comboBox4.Text.ToString());
            parameters.Add("@GorevAdi", comboBox5.Text.ToString());
            parameters.Add("@Durum", comboBox6.SelectedItem.ToString());
            parameters.Add("@EtiketAd", comboBox7.SelectedItem.ToString());
            parameters.Add("@BaslamaTarihi", dateTimePicker1.Value);
            parameters.Add("@BitişTarih", dateTimePicker2.Value);
            parameters.Add("@Aciklama", textBox1.Text.ToString());
            parameters.Add("@GorevTakipID", label14.Text.ToString());
            SqlCon.Execute("GorevDetayGuncelleme", parameters, commandType: CommandType.StoredProcedure);

            GorevDetay GorevDetayListeleme = new GorevDetay();
            dataGridView1.DataSource = GorevDetayListeleme.Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

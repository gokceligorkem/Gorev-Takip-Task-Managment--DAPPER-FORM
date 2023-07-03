using Dapper;
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

namespace Birleştirme0205.AdminSayfa
{
    public partial class Zimmet : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public Zimmet()
        {
            InitializeComponent();
        }

        #region Personellere ait ürünleri listemele
        void ZimmetListele()
        {

            List<ZimmetUrunListele> list = SqlCon.Query<ZimmetUrunListele>("ZimmetUrunListele", commandType: CommandType.StoredProcedure).ToList<ZimmetUrunListele>();
            dataGridView1.DataSource = list;
            

        }
        class ZimmetUrunListele
        {
            public string Adı { get; set; }
            public string Soyadı { get; set; }
            public string UrunAdi { get; set; }
            public string KategoriAdi { get; set; }

        }
        #endregion
        private void Zimmet_Load_1(object sender, EventArgs e)
        {
            string gorevveren = "SELECT KategoriAdi FROM tblUrunKategori";
            List<string> departmanList = SqlCon.Query<string>(gorevveren).ToList();
            urunkategoriCombo.DataSource = departmanList;
        }

        #region Kategori Ekle
        public void KategoriUrunEkle()
        {
            try
            {
                DynamicParameters KategoriUrunEkle = new DynamicParameters();
                KategoriUrunEkle.Add("@KategoriAdı", KategoriTxt.Text);

                SqlCon.Execute("UrunKategoriEkle", KategoriUrunEkle, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Kategori Başarıyla Eklendi.");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        #endregion
        #region ürünü kategorisine göre ekle
        public void UrunveKategoriekle()
        {
            try
            {
                DynamicParameters urunekle = new DynamicParameters();
                urunekle.Add("@KategoriAdı", urunkategoriCombo.SelectedItem);
                urunekle.Add("@Urunadı", txtUrunadi.Text);

                SqlCon.Execute("UrunEkleme ", urunekle, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Ürün Başarıyla Eklendi.");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        #endregion
        private void KategoriEkleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                KategoriUrunEkle();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                ZimmetListele();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        class tblUrunEkleme
        {
            public string Urunadı { get; set; }
            public string KategoriAdı { get; set; }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Ürünleri ve kategorilerini listeleme
            string urunkategori = "select su.UrunAdi,uk.KategoriAdi from tblSirketUrunleri su inner join tblUrunKategori uk on su.UrunKategoriID=uk.ID";

            List<KeyValuePair<string, string>> urunkategorilist = new List<KeyValuePair<string, string>>();
            foreach (var item in SqlCon.Query(urunkategori))
            {
                urunkategorilist.Add(new KeyValuePair<string, string>(item.UrunAdi, item.KategoriAdi));
            }

            // Verileri DataGridView'e ekleme işlemi
            dataGridView1.DataSource = urunkategorilist;
            dataGridView1.Columns[0].HeaderText = "Ürün Adı";
            dataGridView1.Columns[1].HeaderText = "Kategori Adı";
        }

        private void UrunEkleBtn_Click(object sender, EventArgs e)
        {
            UrunveKategoriekle();

        }


        private void UrunAtaBtn_Click(object sender, EventArgs e)
        {
            lblPersonel.Show();
            personelCombobx.Show();

        }

        private void personelCombobx_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            urunLbl.Show();
            UrunCombobx.Show();
            KaydetBtn.Show();

        }

        private void personelCombobx_MouseClick(object sender, MouseEventArgs e)
        {
            //Personelleri listeleme
            string urunkategori = "SELECT Adı,Soyadı FROM tblCalisanDetay";

            List<string> urunkategorilist = new List<string>();
            foreach (var item in SqlCon.Query(urunkategori))
            {
                urunkategorilist.Add(item.Adı + " " + item.Soyadı);
            }

            personelCombobx.DataSource = urunkategorilist;
        }

        #region Personele ürün atama
        public void CalisanaUrunEkleme()
        {
            try
            {
                DynamicParameters personeleurunekle = new DynamicParameters();
                personeleurunekle.Add("@Adsoyad", personelCombobx.SelectedItem.ToString());
                personeleurunekle.Add("@Urunadi", UrunCombobx.SelectedItem.ToString());
                SqlCon.Execute("CalisanaUrunEkleme", personeleurunekle, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Ürün Başarıyla Eklendi.");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        #endregion
        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CalisanaUrunEkleme();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            try
            {
                ZimmetListele();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void UrunCombobx_MouseClick(object sender, MouseEventArgs e)
        {
            string gorevveren = "SELECT UrunAdi FROM tblSirketUrunleri";
            List<string> departmanList = SqlCon.Query<string>(gorevveren).ToList();
            UrunCombobx.DataSource = departmanList;
        }

        private void urunkategoriCombo_MouseClick(object sender, MouseEventArgs e)
        {
            string gorevveren = "SELECT KategoriAdi FROM tblUrunKategori";
            List<string> departmanList = SqlCon.Query<string>(gorevveren).ToList();
            urunkategoriCombo.DataSource = departmanList;
        }

        private void urunkategoriCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

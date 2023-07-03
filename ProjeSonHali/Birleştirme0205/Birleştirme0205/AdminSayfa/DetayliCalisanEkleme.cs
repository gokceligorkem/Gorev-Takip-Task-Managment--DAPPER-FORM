using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Birleştirme0205.AdminSayfa.Gorev;

namespace Birleştirme0205.AdminSayfa
{
    public partial class DetayliCalisanEkleme : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public DetayliCalisanEkleme()
        {
            InitializeComponent();
        }
        public class tblKategoriler
        {
            public string DepartmanAdi { get; set; }
        }
        void VerileriListe()
        {

            List<tblCalisanlar> list = SqlCon.Query<tblCalisanlar>("CalisanListeleme", commandType: CommandType.StoredProcedure).ToList<tblCalisanlar>();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;
        }
        class tblCalisanlar
        {
            public int ID { get; set; }
            public string Adı { get; set; }
            public string Soyadı { get; set; }
            public Int64 TC { get; set; }
            public string MedeniHal { get; set; }
            public DateTime DogumTarihi { get; set; }
            public DateTime GuncellemeTarihi { get; set; }
            public string Ülkesi { get; set; }
            public string Şehir { get; set; }
            public string İlçe { get; set; }
            public string PostaKodu { get; set; }
            public string Unvanı { get; set; }
            public Int64 Telefon { get; set; }
            public DateTime IseGirisTarihi { get; set; }
            public string KullaniciAdi { get; set; }
            public string KullaniciTipi { get; set; }
            public string Parola { get; set; }
            public string Email { get; set; }
            public string DepartmanAdi { get; set; }
            public string Aciklama { get; set; }
            public string Fotoğraf { get; set; }
            public string Durum { get; set; }
        }
        public void CalisanEkle()
        {
            try
            {
                char medenihal = ' ';
                if (txtMedeniHal.SelectedItem == "Evli")
                    medenihal = 'E';
                else
                    medenihal = 'B';
                DynamicParameters PersonelEkle = new DynamicParameters();
                PersonelEkle.Add("@Adı", txtAd.Text);
                PersonelEkle.Add("@Soyadı", txtSoyad.Text);
                PersonelEkle.Add("@TC", txtTc.Text);
                PersonelEkle.Add("@MedeniHal", medenihal);
                PersonelEkle.Add("@Ülkesi", txtUlke.Text);
                PersonelEkle.Add("@Şehir", txtSehir.SelectedItem);
                PersonelEkle.Add("@İlçe", txtİlce.SelectedItem);
                PersonelEkle.Add("@PostaKodu", txtPkodu.Text);
                PersonelEkle.Add("@DogumTarihi", dateTimePicker1.Value);
                PersonelEkle.Add("@IseGirisTarihi", dateTimePicker2.Value);
                PersonelEkle.Add("@Aciklama", txtAciklama.Text);
                PersonelEkle.Add("@DepartmanAdi", DepartmanCombobx.SelectedItem);
                PersonelEkle.Add("@KullaniciTipi", cmbKullaniciTipi.SelectedItem);
                PersonelEkle.Add("@Unvanı", txtUnvan.Text);
                PersonelEkle.Add("@Telefon", txtIletisim.Text);
                PersonelEkle.Add("@EmailAdress", txtEmail.Text);
                PersonelEkle.Add("@KullaniciAdi", txtLogin.Text);
                PersonelEkle.Add("@Parola", txtPas.Text);
                PersonelEkle.Add("@Aciklama", txtAciklama.Text);
                PersonelEkle.Add("@Fotoğraf", txtPicture.Text);
                DateTime guncellemeTarihi = DateTime.Now;
                PersonelEkle.Add("@GuncellemeTarihi", DateTime.Now, DbType.DateTime);

                SqlCon.Execute("CalisanEkle", PersonelEkle, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Çalışan Başarıyla Eklendi.");




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void DetayliCalisanEkleme_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            string query = "SELECT DepartmanAdi FROM tblDepartmanlar where Durum='True'";
            List<tblKategoriler> departmanlar = SqlCon.Query<tblKategoriler>(query).ToList<tblKategoriler>();

            foreach (var item in departmanlar)
            {
                DepartmanCombobx.Items.Add(item.DepartmanAdi);
            }

            VerileriListe();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog.FileName;
            txtPicture.Text = openFileDialog.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VerileriListe();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CalisanEkle();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        public void CalisanDetayDuzenle()
        {
            try
            {
                DynamicParameters guncelleme = new DynamicParameters();
                guncelleme.Add("@ID", txtID.Text);
                guncelleme.Add("@Adı", txtAd.Text);
                guncelleme.Add("@Soyadı", txtSoyad.Text);
                guncelleme.Add("@Telefon", txtIletisim.Text);
                guncelleme.Add("@TC", txtTc.Text);
                guncelleme.Add("@MedeniHal", txtMedeniHal.Text);
                guncelleme.Add("@Ülkesi", txtUlke.Text);
                guncelleme.Add("@PostaKodu", txtPkodu.Text);
                guncelleme.Add("@Şehir", txtSehir.SelectedItem);
                guncelleme.Add("@İlçe", txtİlce.SelectedItem);
                guncelleme.Add("@IseGirisTarihi", dateTimePicker2.Value);
                guncelleme.Add("@DogumTarihi", dateTimePicker1.Value);
                guncelleme.Add("@Email", txtEmail.Text);
                guncelleme.Add("@KullaniciAdi", txtLogin.Text);
                guncelleme.Add("@Parola", txtPas.Text);
                guncelleme.Add("@KullaniciTipi", cmbKullaniciTipi.Text);
                guncelleme.Add("@Aciklama", txtAciklama.Text);
                guncelleme.Add("@Unvan", txtUnvan.Text);
                guncelleme.Add("@DepartmanAdi", DepartmanCombobx.Text);
                DateTime guncellemeTarihi = DateTime.Now;
                guncelleme.Add("@GuncellemeTarihi", DateTime.Now, DbType.DateTime);
                guncelleme.Add("@Fotoğraf", txtPicture.Text);
                SqlCon.Execute("CalisanDetayDuzenle", guncelleme, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || txtAd.Text.Any(char.IsDigit) || txtAd.Text.Any(char.IsPunctuation) || txtAd.Text.Length < 2 || txtAd.Text.Length > 50)
            {
                MessageBox.Show("Lütfen geçerli bir Ad giriniz (2-50 karakter, özel karakter içermemeli ve rakam içermemeli).");

                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
            if (txtAd.Text == "" || txtSoyad.Text == "" || txtTc.Text == "" || txtIletisim.Text == "" || txtEmail.Text == "" || txtUlke.Text == "" || txtSehir.Text == "" || txtİlce.Text == "" || txtPkodu.Text == "" || txtUnvan.Text == "" || DepartmanCombobx.SelectedItem == null || cmbKullaniciTipi.SelectedItem == null || txtLogin.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Lütfen çalışan durumunu kontrol ettiğinize emin olun", "Çalışan durumu", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DialogResult dialogResultt = MessageBox.Show("İşlemi Yapmak İsteğinize emin misiniz?", "ÇalışanDetayDüzenleme", MessageBoxButtons.YesNo);
                        if (dialogResultt == DialogResult.Yes)
                        {
                            CalisanDetayDuzenle();
                            MessageBox.Show("İşleminiz başarıyla gerçekleşti.");
                        }
                        else if (dialogResultt == DialogResult.No)
                        {
                            //do something else
                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void txtTc_Leave(object sender, EventArgs e)
        {
            string input = txtTc.Text;

            if (Regex.IsMatch(input, @"^\d{11}$"))
            {
                // İşlem yapılacak kod buraya gelecek
            }
            else
            {
                MessageBox.Show("Lütfen sadece 11 haneli bir rakam giriniz.");
            }
        }

        private void txtSoyad_Leave(object sender, EventArgs e)
        {

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMedeniHal.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtUlke.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtSehir.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtİlce.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtPkodu.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtUnvan.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtIletisim.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtLogin.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            cmbKullaniciTipi.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            txtPas.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            DepartmanCombobx.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[19].Value != null)
            {
                txtAciklama.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            }
            else
            {
                txtAciklama.Text = "";
            }
            txtPicture.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbKullaniciTipi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Her bir seçili satır için veri nesnesini alın ve silme işlemini gerçekleştirin
            DynamicParameters sil = new DynamicParameters();
            sil.Add("@CalisanID", int.Parse(txtID.Text));
            SqlCon.Execute("CalisanDetaySilme", sil, commandType: CommandType.StoredProcedure);
            VerileriListe();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAd_Leave(object sender, EventArgs e)
        {

            // Sadece harfleri içeren bir Regex deseni
            string pattern = @"^[a-zA-Z\s]+$";
            // Girdi desene uyuyorsa temizleme işlemi yapma
            if (!Regex.IsMatch(txtAd.Text, pattern))
            {
                MessageBox.Show("Ad giriniz. Lütfen özel karakter ve rakam kullanmayın.");
                
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ilid = 0;
            if (txtSehir.SelectedItem.ToString() == "ANKARA")
                ilid = 1;
            else if (txtSehir.SelectedItem.ToString() == "İSTANBUL")
                ilid = 2;
            else if (txtSehir.SelectedItem.ToString() == "İZMİR")
                ilid = 3;
            string sorgu = "SELECT ilceadi FROM ilceler where sehirid=@IlId";
            List<string> ilcelist = SqlCon.Query<string>(sorgu, new { IlId = ilid }).ToList();
            txtİlce.DataSource = ilcelist;
        }

        private void txtUlke_Leave(object sender, EventArgs e)
        {
            txtAd.Text = txtAd.Text.Substring(0, 15);
            txtAd.SelectionStart = 20; // İmleci sona taşır
            MessageBox.Show("Maksimum 20 karaktere izin verilmektedir.");
        }

        private void txtIletisim_Leave(object sender, EventArgs e)
        {
            string input = txtTc.Text;

            if (Regex.IsMatch(input, @"^\d{10}$"))
            {
                // İşlem yapılacak kod buraya gelecek
            }
            else
            {
                MessageBox.Show("Lütfen sadece 10 (0 hariç) haneli telefon numaranızı giriniz.");
            }
        }

        private void txtSoyad_Leave_1(object sender, EventArgs e)
        {
            // Sadece harfleri içeren bir Regex deseni
            string pattern = @"^[a-zA-Z\s]+$";
            // Girdi desene uyuyorsa temizleme işlemi yapma
            if (!Regex.IsMatch(txtAd.Text, pattern))
            {
                MessageBox.Show("Soyad giriniz. Lütfen özel karakter ve rakam kullanmayın.");
                
            }
           
        }
    }

}


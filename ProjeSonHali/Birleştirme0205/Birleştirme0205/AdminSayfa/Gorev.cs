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
using static Birleştirme0205.AdminSayfa.Gorev;

namespace Birleştirme0205.AdminSayfa
{
    public partial class Gorev : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");

        public class tblGorev
        {
            public int ID { get; set; }
            public string GorevAdı { get; set; }
            public string KategoriAd { get; set; }
        }

        public class tblGorevKategori
        {
            public int CategoryID { get; set; }
            public string Ad { get; set; }
        }
        public class tblDurumTablosu
        {
            public int DurumID { get; set; }
            public string Ad { get; set; }
        }
        public class tblGorevAd
        {
            public int ID { get; set; }
            public string GorevAdı { get; set; }
            public int GorevCategoryID { get; set; }
        }
        public void GorevListele()
        {
            List<tblGorev> list = baglanti.Query<tblGorev>("GorevAdListeleme", commandType: CommandType.StoredProcedure).ToList<tblGorev>();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;

        }
        public Gorev()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmGorev_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Görev Listeleme
            GorevListele();

            // Görev Kategori Listele
            string query2 = "Select * from tblGorevKategori";
            List<tblGorevKategori> kategoriler = baglanti.Query<tblGorevKategori>(query2).ToList<tblGorevKategori>();
            foreach (var item in kategoriler)
            {
                cbGorevKategori.Items.Add(item.Ad); // görev ekleme kısmındaki kategori checkbox'ı
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            // görev ekleme 
            DynamicParameters ekle = new DynamicParameters();
            ekle.Add("@GorevAd", txtGorevAdi.Text);
            ekle.Add("@KategoriAd", cbGorevKategori.SelectedItem);

            baglanti.Execute("GorevAdEkle", ekle, commandType: CommandType.StoredProcedure);
            GorevListele();
        }

        public void GorevSil()
        {
            try
            {
                // görev silme metodu
                DialogResult result = MessageBox.Show("Görevi silmek istediğinize emin misiniz.", "Başlık", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    DynamicParameters sil = new DynamicParameters();
                    sil.Add("@ID", int.Parse(txtID.Text));
                    List<tblGorev> list = baglanti.Query<tblGorev>("GorevAdıSil", sil, commandType: CommandType.StoredProcedure).ToList<tblGorev>();
                    GorevListele();
                }
                else
                {
                    GorevListele();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public void GorevGuncelle()
        {

            DynamicParameters guncelle = new DynamicParameters();
            guncelle.Add("@ID", int.Parse(txtID.Text));
            guncelle.Add("@GorevAd", txtGorevAdi.Text.Trim());
            guncelle.Add("@GorevKategoriAd", cbGorevKategori.SelectedItem);
            List<tblGorev> list = baglanti.Query<tblGorev>("GorevAdıGuncelle", guncelle, commandType: CommandType.StoredProcedure).ToList<tblGorev>();
            dataGridView1.DataSource = list;
            GorevListele();
            // görev güncelleme



        }
        private void cbGorevKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // tıklanan veriyi textboxlara çektiğimiz yer
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtGorevAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            cbGorevKategori.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            GorevSil();
            GorevListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                GorevGuncelle();
                GorevListele();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

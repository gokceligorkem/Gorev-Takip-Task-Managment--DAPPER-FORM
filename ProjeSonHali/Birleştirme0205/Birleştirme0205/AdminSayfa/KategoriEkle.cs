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
    public partial class KategoriEkle : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public class tblGorevKategori
        {
            public int CategoryID { get; set; }
            public string Ad { get; set; }
        }
        public void KategoriListele()
        {
            string query2 = "Select * from tblGorevKategori order by CategoryID";
            List<tblGorevKategori> kategoriler = baglanti.Query<tblGorevKategori>(query2).ToList<tblGorevKategori>();
            dataGridView1.DataSource = kategoriler;
            dataGridView1.Columns[0].Visible = false;
        }
        public KategoriEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DynamicParameters kategoriEkle = new DynamicParameters();
            kategoriEkle.Add("KategoriAd", txtKategoriAd.Text);
            baglanti.Execute("GorevKategoriEkle", kategoriEkle, commandType: CommandType.StoredProcedure);

            KategoriListele();
        }

        private void KategoriEkle_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            KategoriListele();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DynamicParameters ksil = new DynamicParameters();
            ksil.Add("@ID", int.Parse(txtKategoriID.Text.Trim()));
            baglanti.Execute("KategoriSil",ksil,commandType: CommandType.StoredProcedure);
            KategoriListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKategoriID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtKategoriAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DynamicParameters kGuncelle = new DynamicParameters();
            kGuncelle.Add("@ID", int.Parse(txtKategoriID.Text));
            kGuncelle.Add("@KategoriAd", txtKategoriAd.Text);
            List<tblGorevKategori> list = baglanti.Query<tblGorevKategori>("KategoriGuncelle", kGuncelle, commandType: CommandType.StoredProcedure).ToList<tblGorevKategori>();
            dataGridView1.DataSource = list;
            KategoriListele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

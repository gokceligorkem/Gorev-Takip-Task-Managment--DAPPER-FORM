using Birleştirme0205.AdminSayfa;
using DevExpress.Xpo.DB.Helpers;
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
using System.Reflection.Emit;
using System.Web.UI.WebControls;
using static Birleştirme0205.AdminSayfa.GorevDetay;

namespace Birleştirme0205.KullanıcıSayfa
{
    public partial class KullanıcıSayfa : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        class tblCalisanDetay
        {
            public int ID { get; set; }
            public string Adı { get; set; }
            public string Soyadı { get; set; }
            public Int64 Telefon { get; set; }
            public string KullaniciAdi { get; set; }
            public string KullaniciTipi { get; set; }
            public string DepartmanAdi { get; set; }
            public string Parola { get; set; }
            public string Email { get; set; }
            public DateTime GuncellemeTarihi { get; set; }
            public DateTime IseGirisTarihi { get; set; }
            public string Fotoğraf { get; set; }
        }
        public class tblGorev
        {
            public int GorevID { get; set; }
            public string GorevAdi { get; set; }
            public string GorevKategoriAd { get; set; }
            //public string Aciklama { get; set; }
            //public string DurumAd { get; set; }
        }
        public KullanıcıSayfa()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }
        
        private void KullanıcıSayfa_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtID.Enabled = false;
            timer1.Start();

           


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        public void btnGorevler_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Dosya seçin";
            openFileDialog1.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog1.FileName;
                label7.Text = openFileDialog1.FileName;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            DynamicParameters tamamla = new DynamicParameters();
            tamamla.Add("@ID", int.Parse(txtID.Text));
            tamamla.Add("@Dosya", label7.Text);
            SqlCon.Execute("GorevTamamla", tamamla, commandType: CommandType.StoredProcedure);
            MessageBox.Show("Tebrikler Görev Tamamlandı!");


        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Duyuru du = new Duyuru();
            var result = du.DuyuruListeleme();
            MessageBox.Show(result.Item2, result.Item1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

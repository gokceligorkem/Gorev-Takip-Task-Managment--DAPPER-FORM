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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Dapper.SqlMapper;

namespace Birleştirme0205.AdminSayfa
{
    public partial class PersonelDetay : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public PersonelDetay Ad { get; set; }
        public PersonelDetay()
        {
            InitializeComponent();
        }
        public class Yetkinlik
        {
            public int ID { get; set; }
            public string Adı { get; set; }
            public string Soyadı { get; set; }
            public string Aciklama { get; set; }
        }
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

        public void Listeleme()
        {
            List<tblCalisanDetay> list = SqlCon.Query<tblCalisanDetay>("CalisanDetayListele", commandType: CommandType.StoredProcedure).ToList<tblCalisanDetay>();
            dataGridView1.DataSource = list;
            dataGridView2.DataSource = list;
            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[0].Visible = false;


        }

        private void listbtn_Click(object sender, EventArgs e)
        {
            Listeleme();
            yetkinliklistele();
            
        }
        public void ListeArama()
        {
            DynamicParameters param = new DynamicParameters();

            if (comboBox1.SelectedIndex == -1)
            {
                param.Add("@KullaniciTipi", ""); // Eğer ComboBox'ta seçili bir değer yoksa, boş bir parametre ekleyelim
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                param.Add("@KullaniciTipi", "Ad"); // ComboBox'ta ilk öğe seçiliyse, "Ad" parametresini ekleyelim
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                param.Add("@KullaniciTipi", "Soyad"); // ComboBox'ta ikinci öğe seçiliyse, "Soyad" parametresini ekleyelim
            }

            if (textBox1.Text != "")
            {
                param.Add("@Aramametni", textBox1.Text.Trim());

                List<tblCalisanDetay> list = SqlCon.Query<tblCalisanDetay>("CalisanDetayArama", param, commandType: CommandType.StoredProcedure).ToList<tblCalisanDetay>();
                dataGridView1.DataSource = list;
            }


        }
        

       
     
        public void yetkinliklistele()
        {
            List<Yetkinlik> list = SqlCon.Query<Yetkinlik>("yetkinliklistele", commandType: CommandType.StoredProcedure).ToList<Yetkinlik>();
            dataGridView2.DataSource = list;
            dataGridView2.Columns[0].Visible = false;

        }
        public void Yetkinlikgetir()
        {
            string aramaMetni = textBox1.Text.Trim();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Aramametni", aramaMetni);
            param.Add("@KullaniciTipi", "Ad");
            param.Add("@KullaniciTipi", "Soyad");

            List<Yetkinlik> list = SqlCon.Query<Yetkinlik>("YetkinlikGetirr", param, commandType: CommandType.StoredProcedure).ToList<Yetkinlik>();
            dataGridView2.DataSource = list;


        }

        private void PersonelDetay_Load(object sender, EventArgs e)
        {
         
            Listeleme();
            Yetkinlikgetir();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            ListeArama();
            Yetkinlikgetir();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button 2 ile duruma göre açıp/kapama 
            if (dataGridView2.Visible == true)
            {
                dataGridView2.Visible = false;
                button2.Text = "Yetkinlik Aç";
            }
            else
            {
                dataGridView2.Visible = true;
                
                button2.Text = "Yetkinlik Kapat";
            }


        }

        private void DataGridView1_Load(object sender, EventArgs e)
        {
            


        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Yetkinlik formuna çift tıklanıldığında hücrelerin textboxlara gönderilmesi 
            AdminSayfa.Yetkinlik frm2 = new AdminSayfa.Yetkinlik();
            frm2.textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            frm2.textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            if (dataGridView2.CurrentRow.Cells[3].Value != null)
            {
                frm2.textBox4.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                frm2.textBox4.Text = "";
            }
            
            frm2.textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            frm2.textBox2.Enabled = false;
            frm2.textBox3.Enabled = false;
            frm2.textBox5.Enabled = false;
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //geri dön butonu
            this.Close();
        }
        
      

     

     

        
    }
}

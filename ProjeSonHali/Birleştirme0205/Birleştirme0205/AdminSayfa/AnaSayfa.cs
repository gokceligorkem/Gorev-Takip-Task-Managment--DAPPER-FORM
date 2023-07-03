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

namespace Birleştirme0205.AdminSayfa
{
    public partial class AnaSayfa : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public AnaSayfa()
        {
            InitializeComponent();
        }
          
        public virtual System.Drawing.ContentAlignment TextAlign { get; set; }
        private void SetMyButtonProperties()
        {
            // Assign an image to the button.

            // Align the image and text on the button.
            btnAnaSayfa.TextAlign = ContentAlignment.BottomCenter;
            btnGorevler.TextAlign = ContentAlignment.BottomCenter;
            btnCalisanlar.TextAlign = ContentAlignment.BottomCenter;
            btnDepartmanlar.TextAlign = ContentAlignment.BottomCenter;
            btnKategoriler.TextAlign = ContentAlignment.BottomCenter;
            // Give the button a flat appearance.
            btnGorevler.FlatStyle = FlatStyle.Flat;
        }
        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            string gorevSayisi = "Select COUNT(GorevID) from tblGorev";
            label4.Text = SqlCon.ExecuteScalar<int>(gorevSayisi).ToString();

            string tamamlananGorevSayisi = "select COUNT(g.GorevID) from tblGorev g \r\n\tinner join tblGorevDetay gd on gd.GorevID = g.GorevID\r\n\tinner join tblCalisanDetay cd on cd.ID = gd.CalısanID\r\n\tinner join tblCalisanlar c on c.CalisanDetayID = cd.ID\r\n\tinner join tblDurumTablosu dt on dt.DurumID = g.DurumID\r\n\tinner join tblLogin l on l.LogınID = c.LoginID\r\n\twhere g.DurumID = 2";
            label6.Text = SqlCon.ExecuteScalar<int>(tamamlananGorevSayisi).ToString();

            string personelSayisi = "Select COUNT(ID) from tblCalisanlar";
            label8.Text = SqlCon.ExecuteScalar<int>(personelSayisi).ToString();

            string departmanSayisi = "Select COUNT(ID) from tblDepartmanlar";
            label3.Text = SqlCon.ExecuteScalar(departmanSayisi).ToString();


            timer1.Start();
            Form1 frm1 = new Form1();
            frm1.Close();
            SetMyButtonProperties();
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
        }
        private void btnGorevler_Click(object sender, EventArgs e)
        {
            
            if (btnGorevListele.Visible != true & btnGorevDetay.Visible != true)
            {
                btnGorevListele.Visible = true;
                btnGorevDetay.Visible = true;
                btnGorevVeren.Visible = true;
            }
            else
            {
                btnGorevListele.Visible = false;
                btnGorevDetay.Visible = false;
                btnGorevVeren.Visible = false;
            }

            #region visible

            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            #endregion
        }

        private void btnCalisanlar_Click(object sender, EventArgs e)
        {
            
            if (btnCalisanListele.Visible != true & btnCalisanEkle.Visible != true)
            {
                btnCalisanListele.Visible = true;
                btnCalisanEkle.Visible = true;
            }
            else
            {
                btnCalisanListele.Visible = false;
                btnCalisanEkle.Visible = false;
            }

            #region visible

            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void btnDepartmanlar_Click(object sender, EventArgs e)
        {
      
            Departman dep = new Departman();
            dep.MdiParent = this; // this ana sayfa formu
            dep.Show();


            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void btnGorevListele_Click(object sender, EventArgs e)
        {
            Gorev grv = new Gorev();
            grv.MdiParent = this;
            grv.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void btnDepartmanListele_Click(object sender, EventArgs e)
        {
            Departman dep = new Departman();
            dep.MdiParent = this; // this ana sayfa formu
            dep.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void btnCalisanEkle_Click_1(object sender, EventArgs e)
        {
            DetayliCalisanEkleme cal = new DetayliCalisanEkleme();
            cal.MdiParent = this;
            cal.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }


        private void btnCalisanListele_Click_1(object sender, EventArgs e)
        {
            PersonelDetay per = new PersonelDetay();
            per.MdiParent = this;
            per.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void btnKategoriler_Click(object sender, EventArgs e)
        {

            KategoriEkle klist = new KategoriEkle();
            klist.MdiParent = this;
            klist.Show();
            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            EtiketDurum ed = new EtiketDurum();
            ed.MdiParent = this;
            ed.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Zimmet z = new Zimmet();
            z.MdiParent = this;
            z.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void AnaSayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Performans per = new Performans();
            per.MdiParent = this;
            per.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnGorevVeren.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            #endregion
        }

        private void btnGorevDetay_Click(object sender, EventArgs e)
        {
            GorevDetayGoruntuleme gd = new GorevDetayGoruntuleme();
            gd.MdiParent = this;
            gd.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Duyuru duyuru = new Duyuru();
            duyuru.MdiParent = this;
            duyuru.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnGorevVeren.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            #endregion
        }

        private void btnGorevVeren_Click(object sender, EventArgs e)
        {
            Görevveren gv = new Görevveren();
            gv.MdiParent = this;
            gv.Show();

            #region visible
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            btnGorevListele.Visible = false;
            btnGorevDetay.Visible = false;
            btnCalisanListele.Visible = false;
            btnCalisanEkle.Visible = false;
            btnGorevVeren.Visible = false;
            #endregion
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Duyuru du = new Duyuru();
            var result = du.DuyuruListeleme();
            MessageBox.Show(result.Item2, result.Item1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            AdminSayfa.PersonelDetay personelDetay = new PersonelDetay();
            
            personelDetay.Show();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminSayfa.GorevDetayGoruntuleme gorevDetayGoruntuleme = new GorevDetayGoruntuleme();
           
            gorevDetayGoruntuleme.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AdminSayfa.Departman departman = new Departman();
            
            departman.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            AdminSayfa.GorevDetayGoruntuleme gorevDetayGoruntuleme = new GorevDetayGoruntuleme();
            
            gorevDetayGoruntuleme.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }    
}

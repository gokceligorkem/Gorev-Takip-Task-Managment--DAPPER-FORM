using Birleştirme0205.Class;
using Birleştirme0205.Siniflar;
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

namespace Birleştirme0205.AdminSayfa
{
    public partial class EtiketDurum : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public EtiketDurum()
        {
            InitializeComponent();
            etiket listele = new etiket();
            Durum durum = new Durum();
            listBox2.DataSource = listele.EtiketListeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(durumtxt.Text) || durumtxt.Text.Any(char.IsDigit) || durumtxt.Text.Any(char.IsPunctuation) || durumtxt.Text.Length < 2 || durumtxt.Text.Length > 35)
            {
                MessageBox.Show("Lütfen geçerli bir Ad giriniz (2-35 karakter, özel karakter içermemeli ve rakam içermemeli).");
                button1.Enabled = false;
            }
            else
            {
                #region DurumEkle

                Durum durumObj = new Durum();
                string durumValue = durumtxt.Text.Trim();
                durumObj.durumekle(durumValue);
                button1.Enabled = true;
                #endregion
            }

            Durum listele = new Durum();
            listBox1.DataSource = listele.DurumListele();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(etiketetkletxt.Text) || etiketetkletxt.Text.Any(char.IsDigit) || etiketetkletxt.Text.Any(char.IsPunctuation) || etiketetkletxt.Text.Length < 2 || etiketetkletxt.Text.Length > 35)
                {
                    MessageBox.Show("Lütfen geçerli bir Ad giriniz (2-35 karakter, özel karakter içermemeli ve rakam içermemeli).");
                    button2.Enabled = false;
                }
                else
                {
                    #region EtiketEkle
                    etiket etiketObj = new etiket();
                    string etiketValue = etiketetkletxt.Text.Trim();

                    etiketObj.etiketekle(etiketValue);
                    #endregion
                }
                etiket listele = new etiket();
                listBox2.DataSource = listele.EtiketListeleme();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            etiket listele = new etiket();
            listBox2.DataSource = listele.EtiketListeleme();

            Durum listeleme = new Durum();
            listBox1.DataSource = listeleme.DurumListele();

            listBox1.SelectionMode = SelectionMode.None;
            listBox2.SelectionMode = SelectionMode.None;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Seçiniz");
            }


            else
            {
                DialogResult result = MessageBox.Show("Etiketi silmek istediğinize emin misiniz.Bu Etiket başka yerlerde kullanılıyor olabilir", "Başlık", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (listBox2.SelectedIndex != -1)
                    {
                        string seciliEtiket = listBox2.SelectedItem.ToString();
                        etiket etiketObj = new etiket();
                        etiketObj.etiketcıkar(seciliEtiket);

                        etiket listele = new etiket();
                        listBox2.DataSource = listele.EtiketListeleme();
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Seçiniz");
            }
            else
            {
                DialogResult result = MessageBox.Show("Durum silmek istediğinize emin misiniz.Bu Durum başka yerlerde kullanılıyor olabilir.", "Dikkat", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (listBox1.SelectedIndex != -1)
                    {
                        string seciliDurum = listBox1.SelectedItem.ToString();
                        Durum durumObj = new Durum();
                        durumObj.durumsil(seciliDurum);
                        Durum listele = new Durum();
                        listBox1.DataSource = listele.DurumListele();
                    }

                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.One;
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            listBox2.SelectionMode = SelectionMode.One;
        }

        private void durumtxt_Leave(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

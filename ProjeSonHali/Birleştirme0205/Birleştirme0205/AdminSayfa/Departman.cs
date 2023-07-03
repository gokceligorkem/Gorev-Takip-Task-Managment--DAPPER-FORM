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
    public partial class Departman : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public class Departmanlar
        {
            public int ID { get; set; }
            public string DepartmanAdi { get; set; }

            public string Acıklama { get; set; }

            public bool Durum { get; set; }
        }
        public void DepartmanEkleme()
        {
            //Departman eklemek için gerekli dynamic proses 

            try
            {
                DynamicParameters ekle = new DynamicParameters();
                ekle.Add("@DepartmanAdi", textBox1.Text.Trim());
                //stored proc de durum bit olarak ifade edilmiştir. Aktif seçiliyse true olarak görür değilse false
                ekle.Add("@Durum", comboBox1.SelectedItem.ToString() == "Aktif" ? true : false);


                ekle.Add("@Aciklama", textBox4.Text.Trim());

                List<Departmanlar> list = SqlCon.Query<Departmanlar>("DepartmanEkleme", ekle, commandType: CommandType.StoredProcedure).ToList<Departmanlar>();

                dataGridView1.DataSource = list; 
                DepartmanListeleme();

            }
            catch (Exception)
            {

                throw;
            }
                
          

        }
        public Departman()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Departman_Load(this, null);

            try
            {
                DepartmanEkleme();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
                
            

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Datagridviewde çift tıklanıldığında textboxtlara yansıtma.
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Enabled = false;
            
        }
        public void DepartmanGuncelleme()
        {
            //Departman Eklemek için gerekli prosesler  
            try
            {
                DynamicParameters ekle = new DynamicParameters();
                ekle.Add("@DepartmanAdi", textBox1.Text.Trim());
                ekle.Add("@ID", int.Parse(textBox2.Text.Trim()));
                //stored proc de durum bit olarak ifade edilmiştir. Aktif seçiliyse true olarak görür değilse false

                ekle.Add("@Durum", comboBox1.SelectedItem.ToString() == "Aktif" ? true : false);
                ekle.Add("@Aciklama", textBox4.Text.Trim());

                List<Departmanlar> list = SqlCon.Query<Departmanlar>("DepartmanDuzenleme", ekle, commandType: CommandType.StoredProcedure).ToList<Departmanlar>();

                dataGridView1.DataSource = list;
                DepartmanListeleme();
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }
        }
        public void DepartmanListeleme()
        {
            //Departman Listeleme . Stored Procses ile  "DepartmanListeleme"
            List<Departmanlar> list = SqlCon.Query<Departmanlar>("DepartmanListeleme", commandType: CommandType.StoredProcedure).ToList<Departmanlar>();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;

        }
        public void DepartmanSilme()
        {//Departman Listeleme . Stored Procses ile  DepartmanSilme()
            try
            {
                DynamicParameters sil = new DynamicParameters();
                sil.Add("@ID", int.Parse(textBox2.Text.Trim()));

                List<Departmanlar> list = SqlCon.Query<Departmanlar>("DepartmanSilme", sil, commandType: CommandType.StoredProcedure).ToList<Departmanlar>();

                dataGridView1.DataSource = list;
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }
        }

        private void Departman_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepartmanGuncelleme();
            textBox2.Enabled = true;
            Departman_Load(this, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {//Silme butonu Dialoglu işlem
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show(" Silme işlemine devam etmek istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (sil == DialogResult.Yes)
            {
                DepartmanSilme();//departman silme metodu
                Departman_Load(this, null);
            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DepartmanListeleme();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Datagridviewden bir hücre seçiliyse temizleme butonunu kullanarak ekle butonu enable aktif edilir.
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            button1.Enabled = true;
            dataGridView1.ClearSelection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

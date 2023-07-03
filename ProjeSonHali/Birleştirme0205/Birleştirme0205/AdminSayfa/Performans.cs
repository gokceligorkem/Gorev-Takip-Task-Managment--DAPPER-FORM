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
    public partial class Performans : Form
    {
        public Performans()
        {
            InitializeComponent();
        }

        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");

        private void Performans_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //datagridview ekrana sığdırma
            //Listeleme
            PerformanPuan PerformansListeleme = new PerformanPuan();
            dataGridView1.DataSource = PerformansListeleme.Listele();
            //İDlerin gizlemesi
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;

            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DynamicParameters hesapla = new DynamicParameters();
                hesapla.Add("@GorevID", textBox3.Text.ToString());
                hesapla.Add("@gorevBitisTarihi", dateTimePicker2.Value);
                hesapla.Add("@gorevBitirmeTarihi", dateTimePicker3.Value);
                hesapla.Add("@AdSoyad", textBox1.Text.ToString());


                SqlCon.Execute("CalculatePerformansPuan", hesapla, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Puan sisteme eklendi ");

                PerformanPuan PerformansListeleme = new PerformanPuan();

                dataGridView1.DataSource = PerformansListeleme.Listele();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

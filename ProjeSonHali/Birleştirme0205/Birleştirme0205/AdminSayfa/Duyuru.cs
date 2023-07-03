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
    public partial class Duyuru : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public Duyuru()
        {
            InitializeComponent();
        }

        private void Duyuru_Load(object sender, EventArgs e)
        {

        }
        public (string, string) DuyuruListeleme()
        {
            string duyuru = "SELECT top(1) Başlık, Aciklama FROM tblDuyuru ORDER BY ID DESC";
            var result = SqlCon.Query<(string, string)>(duyuru).FirstOrDefault();
            return result;

        }
        private void button1_Click(object sender, EventArgs e)
        { 
            DynamicParameters duyuru = new DynamicParameters();
            duyuru.Add("@Baslik", textBox1.Text.ToString());
            duyuru.Add("@Aciklama", textBox2.Text.ToString());
            SqlCon.Execute("InsertDuyuru", duyuru, commandType: CommandType.StoredProcedure);

            string sonDuyuru = textBox1.Text + " " + textBox2.Text;
            listBox1.Items.Add(sonDuyuru);


            MessageBox.Show("Mesaj Başarıyla Eklendi.");
            DuyuruListeleme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = DuyuruListeleme();
            MessageBox.Show(result.Item2, result.Item1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

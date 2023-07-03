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
    public partial class Yetkinlik : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-0BO7DJ9\SQLEXPRESS;Initial Catalog= TaskManagmentSon;Integrated Security=True");
        public Yetkinlik()
        {
            InitializeComponent();
        }
        public void YetkinlikGüncelleme()
        {
            try
            {
                DynamicParameters guncelleme = new DynamicParameters();
                guncelleme.Add("@yetkinlik", textBox4.Text);
                guncelleme.Add("@ID", textBox5.Text);
                List<Yetkinlik> list = SqlCon.Query<Yetkinlik>("YetinlikInsert", guncelleme, commandType: CommandType.StoredProcedure).ToList<Yetkinlik>();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

          

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Devam etmek istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.Yes)
            {
                YetkinlikGüncelleme();
            }
            else
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Yetkinlik_Load(object sender, EventArgs e)
        {

        }
    }
}

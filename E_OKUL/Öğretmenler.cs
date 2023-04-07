using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace E_OKUL
{
    public partial class Öğretmenler : Form
    {
        public Öğretmenler()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-H2V6Q7S\SQLEXPRESS; Initial Catalog=EOkul; Integrated Security=True");
        DataSet1TableAdapters.tbl_OgretmenlerTableAdapter ds= new DataSet1TableAdapters.tbl_OgretmenlerTableAdapter();
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Ogretmenler", sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void Öğretmenler_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
            
            
            

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.ÖğretmenSil(byte.Parse(txtkulupıd.Text));
            MessageBox.Show("Öğretmen Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.ÖgretmenEkle(byte.Parse(txtbrans.Text), txtadsoy.Text); 
            MessageBox.Show("Öğretmen Eklendi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupıd.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtbrans.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); 
            txtadsoy.Text=dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.ÖğretmenGüncelle(byte.Parse(txtbrans.Text), txtadsoy.Text, byte.Parse(txtkulupıd.Text));
            MessageBox.Show("Öğretmen Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

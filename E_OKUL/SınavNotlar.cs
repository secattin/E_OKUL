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
    public partial class SınavNotlar : Form
    {
        public SınavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.tbl_NotlarTableAdapter();
        SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-H2V6Q7S\SQLEXPRESS; Initial Catalog=EOkul; Integrated Security=True");
        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListele(int.Parse(txtıd.Text));
        }
       
        private void SınavNotlar_Load(object sender, EventArgs e)
        {
            
            sql.Open();
            SqlCommand kmt = new SqlCommand("select * from tbl_Dersler", sql);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "DersAd";
            cmbders.ValueMember = "Dersıd";
            cmbders.DataSource = dt;
            sql.Close();
        }
        int notıd;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notıd = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtıd.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsnv1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsnv2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsnv3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtort.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
       

        int sınav1, sınav2, sınav3, proje;


        double ortalama;
        private void btnhesapla_Click(object sender, EventArgs e)
        {
           
            sınav1 = Convert.ToInt32(txtsnv1.Text);
            sınav2 = Convert.ToInt32(txtsnv2.Text);
            sınav3 = Convert.ToInt32(txtsnv3.Text);
            proje = Convert.ToInt32(txtproje.Text);

            ortalama =( sınav1*(0.4) + sınav2*(0.3)+ sınav3*(0.2) + proje*(0.1));
            txtort.Text = ortalama.ToString();
            
            if (ortalama <= 50)
            {
                txtdurum.Text = "False";


            }
            else
            {
                txtdurum.Text = "True";
            }
           
            if (sınav1 > 100)
            {
                MessageBox.Show("100 den büyük girilemez", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Not hesaplama işlemlerini burada gerçekleştirin
            }
            if (sınav2 > 100)
            {
                MessageBox.Show("100 den büyük girilemez", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Not hesaplama işlemlerini burada gerçekleştirin
            }
            if (sınav3 > 100)
            {
                MessageBox.Show("100 den büyük girilemez", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Not hesaplama işlemlerini burada gerçekleştirin
            }
            if (proje > 100)
            {
                MessageBox.Show("100 den büyük girilemez", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Not hesaplama işlemlerini burada gerçekleştirin
            }

           

        }
        private void btngüncelle_Click(object sender, EventArgs e)
        {
            
            ds.NotGüncelle(byte.Parse(cmbders.SelectedValue.ToString()),
                int.Parse(txtıd.Text),
                byte.Parse(txtsnv1.Text),
                byte.Parse(txtsnv2.Text),
                byte.Parse(txtsnv3.Text),
                byte.Parse(txtproje.Text),
                decimal.Parse(txtort.Text), 
                bool.Parse(txtdurum.Text), 
                notıd);
        }


        
        private void btntemizle_Click(object sender, EventArgs e)
        {
            ds.NotSil(byte.Parse(cmbders.SelectedValue.ToString()),
                int.Parse(txtıd.Text),
                byte.Parse(txtsnv1.Text),
                byte.Parse(txtsnv2.Text),
                byte.Parse(txtsnv3.Text), 
                byte.Parse(txtproje.Text), 
                decimal.Parse(txtort.Text),
                bool.Parse(txtdurum.Text),
                notıd);

        }
    }

}

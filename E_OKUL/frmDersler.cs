using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_OKUL
{
    public partial class frmDersler : Form
    {
        public frmDersler()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        DataSet1TableAdapters.tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.tbl_DerslerTableAdapter();
        private void frmDersler_Load(object sender, EventArgs e)
        {
            

            dataGridView1.DataSource = ds.DersListesi();



        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAd.Text);
            MessageBox.Show("Ders Ekleme işlemi Yapıldı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersID.Text));
            MessageBox.Show("Ders Kayıt İşlemi Silindi","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersID.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.DersGüncelle(txtDersAd.Text,byte.Parse(txtDersID.Text));
            MessageBox.Show("Ders Kayıt İşlemi Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

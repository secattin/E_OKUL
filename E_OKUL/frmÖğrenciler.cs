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
    public partial class frmÖğrenciler : Form
    {
        public frmÖğrenciler()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-H2V6Q7S\SQLEXPRESS; Initial Catalog=EOkul; Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void frmÖğrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            sql.Open();
            SqlCommand kmt = new SqlCommand("select * from tbl_Klupler", sql);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbklub.DisplayMember = "KLUPAD";
            cmbklub.ValueMember = "KLUPID";
            cmbklub.DataSource = dt;
        }


        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {

           
            ds.OgrenciEkle(txtad.Text, txtsoyad.Text, byte.Parse(cmbklub.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Eklendi", "BİGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OGRENCİ_SİL(int.Parse(txtıd.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbklub.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            if(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "erkek")
            {
                radioButton2.Checked = true;
            }
            if(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()== "kadın")
            {
                radioButton1.Checked = true;

            }
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGüncelle(txtad.Text,txtsoyad.Text,byte.Parse(cmbklub.SelectedValue.ToString()),c,int.Parse(txtıd.Text));
            MessageBox.Show("Öğrenciler Güncelleme yapıldı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                c = "erkek";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                c = "kız";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource=ds.OgrenciGetir(txtara.Text);
        }
    }
}

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
    public partial class frmKlüpler : Form
    {
        public frmKlüpler()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-H2V6Q7S\SQLEXPRESS; Initial Catalog=EOkul; Integrated Security=True");

        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Klupler", sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmKlüpler_Load(object sender, EventArgs e)
        {
            listele();           
        }

       

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand kmt = new SqlCommand("Insert Into tbl_Klupler (KLUPAD) values (@p1)",sql);
            kmt.Parameters.AddWithValue("@p1", txtkulupad.Text);
            kmt.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("işleminiz eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupıd.Text =dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text =dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand kmt = new SqlCommand("Delete from tbl_Klupler where KLUPID=@P1", sql);
            kmt.Parameters.AddWithValue("@p1", txtkulupıd.Text);
            kmt.ExecuteNonQuery();
            sql.Close ();
            MessageBox.Show("Kayıt Silindi","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele ();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            sql.Open ();
            SqlCommand kmt = new SqlCommand("Update tbl_Klupler set KLUPAD=@P1 Where KLUPID=@P2",sql);
            kmt.Parameters.AddWithValue("@p1",txtkulupad.Text);
            kmt.Parameters.AddWithValue("@p2", txtkulupıd.Text);
            kmt.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Kayıt Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }
    }
}

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
    public partial class frmÖgrenciNotlar : Form
    {
        public frmÖgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-H2V6Q7S\SQLEXPRESS; Initial Catalog=EOkul; Integrated Security=True");
        public string numara;
        private void frmÖgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("select DersAd,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum from tbl_Notlar inner join tbl_Dersler on tbl_Notlar.Dersıd = tbl_Dersler.Dersıd where OGRID = @p1", sql);

            kmt.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;




        }
    }
}

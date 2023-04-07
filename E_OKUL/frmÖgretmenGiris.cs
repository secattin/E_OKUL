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
    public partial class frmÖgretmenGiris : Form
    {
        public frmÖgretmenGiris()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKlüpler fr = new frmKlüpler();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDersler fr = new frmDersler();
            fr.Show();
        }

        private void btnogrenciİşlem_Click(object sender, EventArgs e)
        {
            frmÖğrenciler fr = new frmÖğrenciler();
            fr.Show();


        }

        private void btnSınavNot_Click(object sender, EventArgs e)
        {
            SınavNotlar sv= new SınavNotlar();
            sv.Show();
        }

        private void btnogretmen_Click(object sender, EventArgs e)
        {
            Öğretmenler og= new Öğretmenler();
            og.Show();
        }
    }
}

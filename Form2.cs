using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JualBeliLaptop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void Btn_upload_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO detail_transaksi(id_transaksi, id_laptop, stok_dibeli) VALUES ({TB_IdTransaksi.Text},{Id_lapTextBox2.Text},{TB_Jumlah.Text})";
            new DatabaseHelper().Execute(sql);
            new DatabaseHelper().Execute($"UPDATE laptop SET stok = stok - ({TB_Jumlah.Text}) WHERE id_laptop = {Id_lapTextBox2.Text}");
            InputBarang form = new InputBarang();
            form.ShowDialog();
            this.Close();
        }
    }
}

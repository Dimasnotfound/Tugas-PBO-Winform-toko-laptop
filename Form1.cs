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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JualBeliLaptop
{
    public partial class Form1 : Form
    {
        DatabaseHelper db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ShowDataTransaksi()
        {
            var db = new DatabaseHelper();
            var reader = db.Select("SELECT id_laptop, nama_laptop, harga_laptop, stok FROM public.laptop;");
            DataGridView1.Rows.Clear();


                while (reader.Read())
                {
                    DataGridView1.Rows.Add((int)reader["id_laptop"], (string)reader["nama_laptop"], (int)reader["harga_laptop"], (int)reader["stok"]);
                }

                reader.Close();
            
        }

        private void showdataDetailTransaksi()
        {
            var reader3 = new DatabaseHelper().Select("SELECT * from detail_transaksi order by id_detail_transaksi ASC");
            dataGridView3.Rows.Clear();
            while (reader3.Read())
            {
                dataGridView3.Rows.Add(reader3["id_detail_transaksi"], reader3["id_transaksi"], reader3["id_laptop"], reader3["stok_dibeli"]);
            }
        }

        private void showdataTransaksi()
        {
            var reader2 = new DatabaseHelper().Select("SELECT * from transaksi order by id_transaksi ASC");
            DataGridView2.Rows.Clear();
            while (reader2.Read())
            {
                DataGridView2.Rows.Add(reader2["id_transaksi"], reader2["nama_pembeli"], reader2["tanggal_transaksi"]);
            }
        }

        private void showdataLaptop()
        {
            var reader = new DatabaseHelper().Select("SELECT * from laptop order by id_laptop ASC");
            DataGridView1.Rows.Clear();
            while (reader.Read())
            {
                DataGridView1.Rows.Add(reader["id_laptop"], reader["nama_laptop"], reader["harga_laptop"], reader["stok"]);
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            var db = new DatabaseHelper();
            db.Execute($"INSERT INTO laptop(id_laptop, nama_laptop, harga_laptop, stok) VALUES ({textBox1.Text},'{textBox2.Text}',{textBox3.Text}, {textBox4.Text})");
            ShowDataTransaksi();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            var db = new DatabaseHelper();
            db.Execute($"UPDATE laptop SET nama_laptop = '{textBox2.Text}', harga_laptop = {textBox3.Text}, stok = {textBox4.Text} WHERE id_laptop = {textBox1.Text}");
            ShowDataTransaksi();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            var db = new DatabaseHelper();
            db.Execute($"DELETE FROM laptop WHERE id_laptop = '{textBox1.Text}'");
            ShowDataTransaksi();
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {
            var db = new DatabaseHelper();
            var reader = db.Select($"SELECT * FROM laptop WHERE nama_laptop LIKE '%{bunifuTextBox5.Text}%'");
            DataGridView1.Rows.Clear();
            while (reader.Read())
            {
                DataGridView1.Rows.Add((int)reader["id_laptop"], (string)reader["nama_laptop"], (int)reader["harga_laptop"], (int)reader["stok"]);
            }
            reader.Close();
        }




        private void Btn_upload_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO transaksi(id_transaksi, nama_pembeli) VALUES ({TB_IdTransaksi.Text}, '{TB_Pembeli.Text}')";
            new DatabaseHelper().Execute(sql);
            Form2 form = new Form2();
            form.ShowDialog();
            showdataTransaksi();
            showdataDetailTransaksi();
            showdataLaptop();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ShowDataTransaksi();
            showdataTransaksi();
            showdataDetailTransaksi();
        }
    }
}

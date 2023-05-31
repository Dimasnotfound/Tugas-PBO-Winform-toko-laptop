using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JualBeliLaptop
{
    public partial class InputBarang : Form
    {
        public InputBarang()
        {
            InitializeComponent();
        }



        private void Btn_YES_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            this.Close();
        }

        private void btn_NO_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUCModel
{
    public partial class Form9 : Form
    {
        public int confirm = 0;
        public Form9(string name)
        {
            InitializeComponent();
            this.Text = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            confirm = 1;
            this.Close();
        }
    }
}

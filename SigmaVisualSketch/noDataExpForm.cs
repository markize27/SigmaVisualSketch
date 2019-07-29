using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigmaVisualSketch
{
    public partial class noDataExpForm : Form
    {
        public noDataExpForm()
        {
            InitializeComponent();
        }
        public void txtval(String txt) { labelForException.Text = txt; }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

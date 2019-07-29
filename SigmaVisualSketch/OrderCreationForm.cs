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
    public partial class OrderCreationForm : Form
    {
        public OrderCreationForm()
        {
            InitializeComponent();
        }
        public string SetAddEditOrderShortDescription = "";
        public string SetAddEditOrderDescription = "";

        private void button1_Click(object sender, EventArgs e)
        {
            noDataExpForm newExpForm = new noDataExpForm();
            if ((textBoxForShortDescription.Text == "") || (rtextBoxForDescription.Text == ""))
            {
                newExpForm.txtval("Введены не все данные!");
                newExpForm.Show();
            }

            else
            {
                Form1.SetAddEditOrderShortDescription = textBoxForShortDescription.Text;
                Form1.SetAddEditOrderDescription = rtextBoxForDescription.Text;
                
                Close();
            }

        }
    }
}

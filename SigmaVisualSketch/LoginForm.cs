using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigmaVisualSketch
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            conn = DBUtils.GetDBConnection();
            conn.Open();

           
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from usersTable where userName = '"+tbLogin.Text+"' and pass='"+tbPassword.Text+"'", conn );

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Form1 main = new Form1();
                    SqlDataAdapter sda2 = new SqlDataAdapter("select * from usersTable where userName = '" + tbLogin.Text + "' and pass='" + tbPassword.Text + "'", conn);
                    sda2.Fill(dt);
                    DataRow drow = dt.Rows[1];
                Int32 userIdValue = drow.Field<Int32>("userID");
                main.setUserID(userIdValue);
                    main.Show();
                }
                else
                {
                    MessageBox.Show("please enter correct username or password ","alert",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            conn.Close();
            // Разрушить объект, освободить ресурс.
            conn.Dispose();
            
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

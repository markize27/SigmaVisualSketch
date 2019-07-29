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
    public partial class OrderInfo : Form
    {
        public OrderInfo()
        {
            InitializeComponent();
        }
        SqlConnection conn;

        int orderID;
        string viewType;
      public void fillOrder(int orderID,string orderCreator, string orderExecutor, string orderDescription, string orderShortDescription,DateTime creationDate, string viewType)
        {
            this.orderID = orderID;
            this.viewType = viewType;
            if (viewType  == "AllOrders")
            {
                label7.Visible = false;
                label8.Visible = false;
                btnDeleteOrder.Visible = false;
                btnChangeStatus.Visible = false;
                
            }
            if(viewType == "MyOrders")
            {
                btnTakeOrder.Visible = false;
                btnChangeStatus.Visible = false;

            }
            if(viewType == "MyTakenOrders"){
                btnDeleteOrder.Visible = false;
                btnTakeOrder.Text = "Finish Order";
            }

            groupBox1.Text = Convert.ToString(orderID) + " " + orderShortDescription;
            label3.Text = orderCreator;
            label4.Text = orderExecutor;
            label6.Text = Convert.ToString(creationDate);
            richTextBox1.Text = orderDescription;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTakeOrder_Click(object sender, EventArgs e)
        {

            if(viewType == "AllOrders")
            {
            int executorId = Form1.userID;

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "Update ordersTable Set orderExecutor = " + executorId + 
                "Where orderId = "+ orderID;
            conn = DBUtils.GetDBConnection();
            conn.Open();
            cmd.Connection = conn;
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            conn.Close();
            btnTakeOrder.Enabled = false;
            }
            else
            {
                int executorId = Form1.userID;

                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = "Update ordersTable Set orderExecutor = " + 0 +
                    "Where orderId = " + orderID;
                conn = DBUtils.GetDBConnection();
                conn.Open();
                cmd.Connection = conn;
                adapter.InsertCommand = new SqlCommand(sql, conn);
                adapter.InsertCommand.ExecuteNonQuery();
                conn.Close();
                btnTakeOrder.Enabled = false;
            }
            
            
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "Delete from ordersTable where orderId = " + orderID;
            conn = DBUtils.GetDBConnection();
            conn.Open();
            cmd.Connection = conn;
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            conn.Close();
            btnDeleteOrder.Enabled = false;
        }
    }
}

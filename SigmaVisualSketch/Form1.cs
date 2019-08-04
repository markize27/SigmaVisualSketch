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
ffffff
namespace SigmaVisualSketch
{
    public partial class Form1 : Form
    {
        public static Int32 userID;
        public String userFullName;
        public string userRole;
        SqlConnection conn;
        public void setUserID(int id) {
            userID = id;
        }

        public void refreshList()
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                createListOfOrders(getDataTableWithAllAvaliblbeOrders(), flpForAllAvalibleOrders, "AllOrders");

            }
            if (tabControl1.SelectedTab == tabPage2)
            {
                createListOfOrders(getDataTableWithMyCreatedOrders(), flpForMyCreatedOrders, "MyOrders");
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                createListOfOrders(getDataTableWithOrdersToExecute(), flpForOrdersToExecute, "MyTakenOrders");
            }
        }

        public static string SetAddEditOrderShortDescription = "";
        public static string SetAddEditOrderDescription = "";
        public static string SetAddEditStudentPatronymic = "";
        public static DateTime SetAddEditStudentBirthDate;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void createListOfOrders(DataTable dt, FlowLayoutPanel flp, string viewType)
        {
            conn = DBUtils.GetDBConnection();
            conn.Open();


            string ExecutorFullName;
            string CreatorFullName;
            SqlDataAdapter sda;
            DataTable dt2 = new DataTable(); ;
            DataRow drow2;
            flp.Controls.Clear();
            for(int i = 0; i < dt.Rows.Count; i++) { 
            
                    DataRow drow = dt.Rows[i];
                    int orderID = drow.Field<int>("orderId");
                String orderDescription = drow.Field<String>("orderDescription");
                String orderShortDescription = drow.Field<String>("orderShortdescription");
                int orderCreatorID = drow.Field<int>("orderCreator");
                int orderExecutorID = drow.Field<int>("orderExecutor");
                DateTime orderCreationDate = drow.Field<DateTime>("OrderCreationDate");

                if (drow.Field<int>("orderExecutor")== 0)
                {
                    ExecutorFullName = "None";
                }
                else
                {
                   

                    sda = new SqlDataAdapter("select * from usersTable where userID = '" + orderExecutorID + "'", conn);
                    sda.Fill(dt2);
                    drow2 = dt2.Rows[0];
                    ExecutorFullName = drow2.Field<String>("fullName");
                    dt2.Clear();
                }


                sda = new SqlDataAdapter("select * from usersTable where userID = '" + orderCreatorID + "'", conn);
                sda.Fill(dt2);
                drow2 = dt2.Rows[0];    
                CreatorFullName = drow2.Field<String>("fullName");
                dt2.Clear();

                OrderInfo orderInf = new OrderInfo();
                orderInf.TopLevel = false;

                flp.Controls.Add(orderInf);
                orderInf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                orderInf.Show();
                orderInf.fillOrder(orderID, CreatorFullName, ExecutorFullName, orderDescription, orderShortDescription, orderCreationDate, viewType);
            }
            
        }

        private void fillOrderCard(int orderID)
        {
            OrderInfo orderInf = new OrderInfo();
            orderInf.TopLevel = false;
            
            flpForAllAvalibleOrders.Controls.Add(orderInf);
            orderInf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            orderInf.Show();

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            OrderInfo orderInf = new OrderInfo();
            orderInf.TopLevel = false;
            flpForAllAvalibleOrders.Controls.Add(orderInf);
            orderInf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
          
            orderInf.Show();
        }


        private DataTable getDataTableWithAllAvaliblbeOrders()
        {
            DataTable dt = new DataTable();
            conn = DBUtils.GetDBConnection();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from ordersTable where orderExecutor = 0 ", conn);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        private DataTable getDataTableWithMyCreatedOrders()
        {
            DataTable dt = new DataTable();
            conn = DBUtils.GetDBConnection();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from ordersTable where orderCreator = '" + userID + "'", conn);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        private DataTable getDataTableWithOrdersToExecute()
        {
            DataTable dt = new DataTable();
            conn = DBUtils.GetDBConnection();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from ordersTable where orderExecutor = '" + userID + "'", conn);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
           // toolStripSplitButton2.Visible = false;
            conn = DBUtils.GetDBConnection();
            conn.Open();

           
            SqlDataAdapter sda = new SqlDataAdapter("select * from usersTable where userID = '" + userID + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow drow = dt.Rows[0];
            userFullName = drow.Field<String>("fullName");
            userRole = drow.Field<String>("type");

            if (userRole == "admin")
            {
               // toolStripSplitButton2.Visible = true;
               // toolStripSplitButton2.Enabled = true;
            }
            tsslUserName.Text = userFullName + " " +userRole;

           
            createListOfOrders(getDataTableWithAllAvaliblbeOrders(), flpForAllAvalibleOrders, "AllOrders");
            conn.Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                createListOfOrders(getDataTableWithAllAvaliblbeOrders(), flpForAllAvalibleOrders, "AllOrders");

            }
            if (tabControl1.SelectedTab == tabPage2)
            {
                createListOfOrders(getDataTableWithMyCreatedOrders(), flpForMyCreatedOrders, "MyOrders");
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                createListOfOrders(getDataTableWithOrdersToExecute(), flpForOrdersToExecute, "MyTakenOrders");
            }
            if (tabControl1.SelectedTab == tabPage5)
            {
              
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            OrderCreationForm addForm = new OrderCreationForm();
            //addForm.Show()
            addForm.ShowDialog();

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "Insert into ordersTable (orderShortDescription,orderCreator,orderExecutor,orderDescription,orderCreationDate) " +
                "Values ('" + SetAddEditOrderShortDescription + "','" + userID + "', '0', '" + SetAddEditOrderDescription + "','" + DateTime.Now + "')";
            conn = DBUtils.GetDBConnection();
            conn.Open();
            cmd.Connection = conn;
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();
           // createListOfOrders(getDataTableWithAllAvaliblbeOrders(), flpForMyCreatedOrders);
            conn.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
          
           
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {

        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

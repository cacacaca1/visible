using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using capstonebook.Models;
using System.IO.Ports;
using System.Data;

namespace capstonebook
{
    public partial class Login : System.Web.UI.Page
    {
        SerialPort mySerialPort;
        Int32 finger=-1;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserID", IDText.Text);
            Response.Cookies.Add(cookie);
            Response.Cookies["UserID"].Value = IDText.Text;
            
            mySerialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            mySerialPort.RtsEnable = true;
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        private void DataReceivedHandler(
                       object sender,
                       SerialDataReceivedEventArgs e)
        {
            try
            {
                finger = Convert.ToInt32(mySerialPort.ReadLine());
            }
            catch (InvalidOperationException)
            {
                string fail = @"<script language='JavaScript'>
                                window.alert('다시 시도해주세요 !');
                                </script>";
                Response.Write(fail);
            }
        }
        protected void LoginButton1_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                id = IDText.Text,
                password = PWText.Text
            };

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"select * From dbo.[user] where id = @userid and password = @password";
            cmd.Parameters.AddWithValue("@userid", user.id);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((string)reader["id"] == IDText.Text && (string)reader["password"] == PWText.Text)
                {
                    reader.Close();
                    con.Close();
                    Response.Redirect("userMain.aspx");
                }
            }
            reader.Close();
            con.Close();
            
        }

        protected void RegisterButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/register.aspx");
        }

        protected void FingerLogin_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen == false)
            {
                mySerialPort.Open();
                mySerialPort.Write("2");
            }
            while (true)
            {
                User user = new User
                {
                    delayday = finger
                };
                if (finger != -1)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"select id, password, delayday From dbo.[user] where delayday = @delayday";
                    cmd.Parameters.AddWithValue("@delayday", user.delayday);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if(user.delayday==0)
                        {
                            user.delayday++;
                        }
                        if ((int)reader["delayday"] == user.delayday )
                        {
                            Response.Cookies["UserID"].Value = (string)reader["id"];
                            reader.Close();
                            con.Close();    
                            Response.Redirect("userMain.aspx");
                        }
                    }
                    reader.Close();
                    con.Close();
                    if (mySerialPort.IsOpen == true)
                    {
                        mySerialPort.Close();
                    }
                    return;
                }
            }
        }
    }
}
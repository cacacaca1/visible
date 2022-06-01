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
        private SerialPort insSerialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserID", IDText.Text);
            Response.Cookies.Add(cookie);
            Response.Cookies["UserID"].Value = IDText.Text;
            cookie.Expires = DateTime.Now.AddDays(1);
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
            if (insSerialPort.IsOpen)
            {
                insSerialPort.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            insSerialPort.Open();
            String data = insSerialPort.ReadLine();
            int finger = Int32.Parse(data);
            Label1.Text = data;
            insSerialPort.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            insSerialPort.Open();
            insSerialPort.Write("0");

            Label1.Text = "LED 꺼짐";
            Button1.Enabled = true;
            Button2.Enabled = false;
            if (insSerialPort.IsOpen)
            {
                insSerialPort.Close();
            }
        }
    }
}
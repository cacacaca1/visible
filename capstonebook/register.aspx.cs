using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using capstonebook.Models;

namespace capstonebook
{
    public partial class regiseter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private SerialPort insSerialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.id = id.Text;
            user.password = pw.Text;
            user.name = name.Text;
            user.phonenumber = phone.Text;
            user.email = email.Text;
            

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"
                                            insert into dbo.[user]
                                            (id, password, name, phonenumber, email) 
                                             VALUES ( @id, @pw, @name, @phone, @email);";
            cmd.Parameters.AddWithValue("@id", user.id);
            cmd.Parameters.AddWithValue("@pw", user.password);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@phone", user.phonenumber);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            string str = @"<script language='JavaScript'>
                                window.alert('가입이 완료되었습니다.');
                                </script>";
            Response.Write(str);
            con.Close();
            Response.Redirect("/Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void FingerprintEnroll_Click(object sender, EventArgs e)
        {
            while(true)
            {
                insSerialPort.Open();
                insSerialPort.Write("2");
                insSerialPort.Write(Fingerbox.Text);
                String data = insSerialPort.ReadLine();
                Label1.Text = data;
                /*int finger = Int32.Parse(data);
                if (finger > 0)
                {
                    Label1.Text = data;
                }*/
                insSerialPort.Close();
                return;
            }
        }
    }
}
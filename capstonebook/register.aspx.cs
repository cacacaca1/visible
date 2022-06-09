using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using capstonebook.Models;

namespace capstonebook
{
    public partial class regiseter : System.Web.UI.Page
    {
        SerialPort mySerialPort;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                this.Fingerbox.Text = mySerialPort.ReadLine();
            }
            catch (InvalidOperationException)
            {
                string fail = @"<script language='JavaScript'>
                                window.alert('다시 시도해주세요 !');
                                </script>";
                Response.Write(fail);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.id = id.Text;
            user.password = pw.Text;
            user.name = name.Text;
            user.phonenumber = phone.Text;
            user.email = email.Text;
            user.delayday = Convert.ToInt32(Fingerbox.Text);

            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"
                                            insert into dbo.[user]
                                            (id, password, name, phonenumber, email, delayday) 
                                             VALUES ( @id, @pw, @name, @phone, @email, @delayday);";
            cmd.Parameters.AddWithValue("@id", user.id);
            cmd.Parameters.AddWithValue("@pw", user.password);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@phone", user.phonenumber);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@delayday", user.delayday);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            string str = @"<script language='JavaScript'>
                                window.alert('가입이 완료되었습니다.');
                                </script>";
            Response.Write(str);
            Response.Redirect("/Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void FingerprintEnroll_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen == false)
            {
                mySerialPort.Open();
                mySerialPort.WriteLine("1");
                mySerialPort.WriteLine(savefinger.Text);
            }
            while (true)
            {
                if (Fingerbox.Text != "")
                {
                    string goodfinger = @"<script language='JavaScript'>
                                window.alert('등록이 완료되었습니다.');
                                </script>";
                    Response.Write(goodfinger);
                    mySerialPort.Close();   
                    return;
                }
            }
        }
    }
}
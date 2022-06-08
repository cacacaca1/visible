using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace capstonebook
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen == false)
            {
                mySerialPort.Open();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(mySerialPort.IsOpen == true)
            {
                mySerialPort.Close();
            }
        }
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
                this.TextBox3.Text = "DATA RECEIVED!";
                TextBox2.Text = mySerialPort.ReadLine();
            }
            catch (InvalidOperationException)
            {
                TextBox3.Text = "datareceived오류";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen == false)
            {
                mySerialPort.Open();
            }
            mySerialPort.Write("1");
            while (true)
            {
                if (TextBox2.Text != "")
                {
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

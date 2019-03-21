using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace GonnaWorkThisTime
{
    public partial class Form1 : Form
    {
        int time = 0;
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox1.BringToFront();
            List<String> tList = new List<String>();

            comboBox1.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                tList.Add(s);
            }
            for (int i = 0; i < tList.Count; i++)
            {
                comboBox1.Items.Add(tList[i]);
            }


            comboBox1.Enabled = false;
            

            this.CenterToScreen();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            port = new SerialPort(comboBox1.Text, 9600, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.None;
            port.RtsEnable = true;
            port.DtrEnable = true;
            port.Open();
            port.DataReceived += new SerialDataReceivedEventHandler(MyDataReceivedHandler);
            button1.Enabled = false;
           
        }
        private void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            
            
            SerialPort sp = (SerialPort)sender;
            string x = "hello";
            while (x != null)
            {
                x = sp.ReadLine();
                char[] y = x.ToCharArray();
                if (y[0] != '?')
                {
                    Thread.Sleep(10);
                    x = sp.ReadLine();
                    chart1.Series[0].Points.AddXY(time, Convert.ToDouble(x));
                    time++;
                }
                else {
                    Thread.Sleep(10);
                }
            }
            port.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}

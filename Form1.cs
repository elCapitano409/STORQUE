<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO.Ports;

namespace HOpefullythisworks
{
    public partial class Form1 : Form
    {
        private Thread cpuThread;

        private double[] cpuArray = new double[60];


        public Form1()
        {
            InitializeComponent();
        }

        private void getPerformanceCounters()
            //object sender, System.IO.Ports.SerialDataReceivedEventArgs e
        {
            SerialPort sp = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            try
            {
                sp.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Checkport");
                return;
            }
            
                

            //var cpuPerfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");



            while (true)

            {
                string data = sp.ReadExisting();
                ;
                cpuArray[cpuArray.Length - 1] = Convert.ToDouble(data);
                    //Math.Round(cpuPerfCounter.NextValue(), 0);



                Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);



                if (cpuChart.IsHandleCreated)

                {

                    this.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });

                }

                else

                {

                    //......

                }



                Thread.Sleep(100);

            }

        }



        private void UpdateCpuChart()

        {

            cpuChart.Series["Series1"].Points.Clear();



            for (int i = 0; i < cpuArray.Length - 1; ++i)

            {

                cpuChart.Series["Series1"].Points.AddY(cpuArray[i]);

            }

        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {

                cpuThread = new Thread(new ThreadStart(this.getPerformanceCounters));

                cpuThread.IsBackground = true;

                cpuThread.Start();

            }
        }
    }
}
>>>>>>> 63c5a9c5119e10c0b026c41ab7e42831c3b380e0

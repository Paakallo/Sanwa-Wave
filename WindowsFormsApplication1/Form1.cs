using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string COM_p;
        bool rtsState;

        public Form1()
        {
            InitializeComponent();
            serialPort1 = new System.IO.Ports.SerialPort();
            // serialPort1.PortName = "COM5";
            serialPort1.BaudRate = 9600;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.DataBits = 8;
            serialPort1.Parity = System.IO.Ports.Parity.None;

            // receive data in a different thread
            // serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);

        }

        private void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = serialPort1.ReadLine();
            this.Invoke(new MethodInvoker(delegate
            {
                Data.AppendText(data + Environment.NewLine);
            }
            ));
        }

        // write COM
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     
        
        // assign COM port and change label
        private void Confirm_Click(object sender, EventArgs e)
        {
            COM_p = textBox1.Text;
            serialPort1.PortName = COM_p;
            COM_port.Text = textBox1.Text;

        }

        // stop recording
        private void Stop_Click(object sender, EventArgs e)
        {

        }

        // start recording
        private void Start_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            Data.Text = "Otwieram";
            
            //timer.Start();
            //System.Threading.Thread.Sleep(1000);
            //serialPort1.Open();
            //System.Threading.Thread.Sleep(1000);
            Data.Text = "Czytam";
            //serialPort1.Close();
         }


        public void komunizm(object sender, EventArgs e)
        {
            serialPort1.ReadTimeout = 5000; //read timeout
            serialPort1.WriteTimeout = 200; //write timeout
            serialPort1.RtsEnable = false;
            serialPort1.DtrEnable = false;

            serialPort1.Open();
            System.Threading.Thread.Sleep(100);
            //timer1.Interval = 1000;
            //timer1.Tick += timer1_Tick;
            //timer1.Start();

            serialPort1.RtsEnable = true;
            System.Threading.Thread.Sleep(100);
            serialPort1.RtsEnable = false;
            System.Threading.Thread.Sleep(100);
            serialPort1.RtsEnable = true;
            System.Threading.Thread.Sleep(100);


            bool close_con = true;

            string exanple = "$10$02$00$00$00$00$10$03";

            int data;
            int[] read_data;
            byte[] bytes = new byte[] {0x10, 0x02, 0x00, 0x00, 0x00, 0x00, 0x10, 0x03};
          
            //{ 00010000, 00000010, 00000000, 00000000, 00000000, 00000000, 00010000, 00000011 };
            serialPort1.Write(bytes, 0, bytes.Length);

            

            for (int i =0; i<22; i++){
                data = serialPort1.ReadByte();
                read_data[i] = data; //pozniej dokonczymy!!!
                Data.AppendText(data.ToString());
            }
            //22

            //ToString(serialPort1.ReadExisting())
            //response = bytes.ToString() ;
            //Data.AppendText(response);
            //Data.Text = response;

            int len = bytes.Length;
            //Data.Text = len.ToString();
            // Data.Text = BitConverter.ToString(bytes2);
            if (close_con)
            {
                serialPort1.Close();
            }
        }

        private void COM_port_Click(object sender, EventArgs e)
        {

        }

        private void Data_TextChanged(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rtsState = !rtsState;
            serialPort1.RtsEnable = rtsState;
        }


    }
}

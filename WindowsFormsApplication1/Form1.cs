using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string COM_p;
        bool rtsState;
        byte[] buffer1;

        public Form1()
        {
            InitializeComponent();
            serialPort1 = new System.IO.Ports.SerialPort();
            serialPort1.BaudRate = 9600;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.DataBits = 8;
            serialPort1.Parity = System.IO.Ports.Parity.None;

            measurementTimer = new System.Windows.Forms.Timer();
            measurementTimer.Interval = 1000; // co 1 sekunda
            measurementTimer.Tick += MeasurementTimer_Tick;


        }

        private void MeasurementTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                read_data();
            }
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
            serialPort1.Close();
            Data1.Text = "";
            Data.Text = "";
            Unit.Text = "";

            measurementTimer.Stop();
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
         }


        public void init_rts()
        {
            serialPort1.ReadTimeout = 5000; //read timeout
            serialPort1.WriteTimeout = 200; //write timeout
            serialPort1.RtsEnable = false;
            serialPort1.DtrEnable = false;

            serialPort1.Open();
            System.Threading.Thread.Sleep(100);

            serialPort1.RtsEnable = true;
            System.Threading.Thread.Sleep(100);
            serialPort1.RtsEnable = false;
            System.Threading.Thread.Sleep(100);
            serialPort1.RtsEnable = true;
            System.Threading.Thread.Sleep(100);
        }


        public void read_data()
        {
            Data1.Text = "";
            Data.Text = "";
            Unit.Text = "";
            int[] read_data = new int[] { };
            byte[] bytes = new byte[] { 0x10, 0x02, 0x00, 0x00, 0x00, 0x00, 0x10, 0x03 };

            //{ 00010000, 00000010, 00000000, 00000000, 00000000, 00000000, 00010000, 00000011 };

            // Send command to Sanwa
            serialPort1.Write(bytes, 0, bytes.Length);
                        
            byte[] buffer = new byte[22];
            buffer1 = buffer;


            int bytesRead = 0;

            while (bytesRead < 22)
            {
                bytesRead += serialPort1.Read(buffer, bytesRead, 22 - bytesRead);
            }

            string hex = BitConverter.ToString(buffer);
            Data.AppendText(hex + Environment.NewLine);

            string asciiPart = "";
            for (int i = 8; i <= 18; i++)
            {
                asciiPart += (char)buffer[i];
            }

            Data1.AppendText(asciiPart);
            assignUnit();
            Save_Click(null, null);
        }

        // start recording
        public void komunizm(object sender, EventArgs e)
        {
            init_rts();
            measurementTimer.Start();
        }


        // assign unit according to multimeter option
        private void assignUnit()
        {
            int byteUnit = buffer1[4];

            switch (byteUnit)
            {
                case 128:
                    Unit.Text = "Ohm";
                    break;
                case 05:
                    Unit.Text = "AcV";
                    break;
                case 06:
                    Unit.Text = "DcV";
                    break;
                case 1:
                    Unit.Text = "AcA";
                    break;
                case 2:
                    Unit.Text = "DcA";
                    break;
                case 0:
                    Unit.Text = "Hz";
                    break;

            }

        }


        private void COM_port_Click(object sender, EventArgs e)
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

        // add current value to the file
        private void Save_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("dane.txt", FileMode.Append, FileAccess.Write))
            {
                string linia = "Wartosc: " + Data1.Text + Unit.Text + Environment.NewLine;
                byte[] dane = System.Text.Encoding.ASCII.GetBytes(linia);
                fs.Write(dane, 0, dane.Length);
            }
        }
    }
}

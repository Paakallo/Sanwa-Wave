namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Start = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.COM_port = new System.Windows.Forms.Label();
            this.Read_value = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.TextBox();
            this.Close = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(469, 128);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.komunizm);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(165, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "COM6";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // COM_port
            // 
            this.COM_port.AutoSize = true;
            this.COM_port.Location = new System.Drawing.Point(179, 99);
            this.COM_port.Name = "COM_port";
            this.COM_port.Size = new System.Drawing.Size(63, 13);
            this.COM_port.TabIndex = 3;
            this.COM_port.Text = "Current Port";
            this.COM_port.Click += new System.EventHandler(this.COM_port_Click);
            // 
            // Read_value
            // 
            this.Read_value.AutoSize = true;
            this.Read_value.Location = new System.Drawing.Point(492, 98);
            this.Read_value.Name = "Read_value";
            this.Read_value.Size = new System.Drawing.Size(33, 13);
            this.Read_value.TabIndex = 4;
            this.Read_value.Text = "None";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(165, 170);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 5;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(613, 128);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 6;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(593, 83);
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Size = new System.Drawing.Size(100, 20);
            this.Data.TabIndex = 7;
            this.Data.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(620, 215);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 8;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 392);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Read_value);
            this.Controls.Add(this.COM_port);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TextChanged += new System.EventHandler(this.Close_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label COM_port;
        private System.Windows.Forms.Label Read_value;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.TextBox Data;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Timer timer1;
    }
}


namespace Mach3_Client
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
            this.table_mach3mill_info = new System.Windows.Forms.TableLayoutPanel();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.textbox_customer_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_job_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._groupBox_mach3mill_info = new System.Windows.Forms.GroupBox();
            this.label_mach3mill_status = new System.Windows.Forms.Label();
            this.pictureBox_Loading_Mach3Mill = new System.Windows.Forms.PictureBox();
            this.picture_discovery_mode_spinner = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.table_broadcast_port_info = new System.Windows.Forms.TableLayoutPanel();
            this.label_tcp_receive_port = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_broadcast_listen_port = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_udpBroadcastGroupBox_message = new System.Windows.Forms.Label();
            this.button_discovery_mode_OnOff = new System.Windows.Forms.Button();
            this.table_general_connection_info = new System.Windows.Forms.TableLayoutPanel();
            this.label_server_ip = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_connect_status = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_myIP = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox_tcp = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label_tcp_target_port = new System.Windows.Forms.Label();
            this.label_tcp_local_port = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox_udpBroadcast = new System.Windows.Forms.GroupBox();
            this.label_udp_local_port = new System.Windows.Forms.Label();
            this.label_udp_target_port = new System.Windows.Forms.Label();
            this.groupBox_udp = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button_disconFromServer = new System.Windows.Forms.Button();
            this.table_mach3mill_info.SuspendLayout();
            this._groupBox_mach3mill_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading_Mach3Mill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_discovery_mode_spinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.table_broadcast_port_info.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.table_general_connection_info.SuspendLayout();
            this.groupBox_tcp.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox_udpBroadcast.SuspendLayout();
            this.groupBox_udp.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_mach3mill_info
            // 
            this.table_mach3mill_info.ColumnCount = 2;
            this.table_mach3mill_info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.05882F));
            this.table_mach3mill_info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.94118F));
            this.table_mach3mill_info.Controls.Add(this.textbox_password, 1, 2);
            this.table_mach3mill_info.Controls.Add(this.textbox_customer_name, 1, 1);
            this.table_mach3mill_info.Controls.Add(this.label7, 0, 2);
            this.table_mach3mill_info.Controls.Add(this.label4, 0, 1);
            this.table_mach3mill_info.Controls.Add(this.label2, 0, 0);
            this.table_mach3mill_info.Controls.Add(this.textbox_job_name, 1, 0);
            this.table_mach3mill_info.Location = new System.Drawing.Point(11, 65);
            this.table_mach3mill_info.Name = "table_mach3mill_info";
            this.table_mach3mill_info.RowCount = 3;
            this.table_mach3mill_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_mach3mill_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_mach3mill_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_mach3mill_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.table_mach3mill_info.Size = new System.Drawing.Size(272, 95);
            this.table_mach3mill_info.TabIndex = 4;
            this.table_mach3mill_info.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // textbox_password
            // 
            this.textbox_password.BackColor = System.Drawing.SystemColors.Control;
            this.textbox_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_password.Enabled = false;
            this.textbox_password.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textbox_password.Location = new System.Drawing.Point(130, 64);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.Size = new System.Drawing.Size(139, 23);
            this.textbox_password.TabIndex = 15;
            this.textbox_password.Text = "*Click to Edit*";
            // 
            // textbox_customer_name
            // 
            this.textbox_customer_name.BackColor = System.Drawing.SystemColors.Control;
            this.textbox_customer_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_customer_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_customer_name.Enabled = false;
            this.textbox_customer_name.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_customer_name.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textbox_customer_name.Location = new System.Drawing.Point(130, 33);
            this.textbox_customer_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_customer_name.Name = "textbox_customer_name";
            this.textbox_customer_name.Size = new System.Drawing.Size(139, 23);
            this.textbox_customer_name.TabIndex = 14;
            this.textbox_customer_name.Text = "*Click to Edit*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(3, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Password";
            this.label7.Click += new System.EventHandler(this.label_PASSWORD_TEXT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Customer: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Job Name: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textbox_job_name
            // 
            this.textbox_job_name.BackColor = System.Drawing.SystemColors.Control;
            this.textbox_job_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_job_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_job_name.Enabled = false;
            this.textbox_job_name.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_job_name.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textbox_job_name.Location = new System.Drawing.Point(130, 2);
            this.textbox_job_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_job_name.Name = "textbox_job_name";
            this.textbox_job_name.Size = new System.Drawing.Size(139, 23);
            this.textbox_job_name.TabIndex = 13;
            this.textbox_job_name.Text = "*Click to Edit*";
            this.textbox_job_name.TextChanged += new System.EventHandler(this.textbox_job_name_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(132)))), ((int)(((byte)(172)))));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(135, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "CloudMill Mach3 Client";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _groupBox_mach3mill_info
            // 
            this._groupBox_mach3mill_info.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._groupBox_mach3mill_info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._groupBox_mach3mill_info.Controls.Add(this.label_mach3mill_status);
            this._groupBox_mach3mill_info.Controls.Add(this.pictureBox_Loading_Mach3Mill);
            this._groupBox_mach3mill_info.Controls.Add(this.table_mach3mill_info);
            this._groupBox_mach3mill_info.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._groupBox_mach3mill_info.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._groupBox_mach3mill_info.ForeColor = System.Drawing.Color.Red;
            this._groupBox_mach3mill_info.Location = new System.Drawing.Point(14, 148);
            this._groupBox_mach3mill_info.Name = "_groupBox_mach3mill_info";
            this._groupBox_mach3mill_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._groupBox_mach3mill_info.Size = new System.Drawing.Size(305, 238);
            this._groupBox_mach3mill_info.TabIndex = 6;
            this._groupBox_mach3mill_info.TabStop = false;
            this._groupBox_mach3mill_info.Text = "Mach3Mill Info";
            this._groupBox_mach3mill_info.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label_mach3mill_status
            // 
            this.label_mach3mill_status.AutoSize = true;
            this.label_mach3mill_status.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mach3mill_status.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label_mach3mill_status.Location = new System.Drawing.Point(34, 168);
            this.label_mach3mill_status.Name = "label_mach3mill_status";
            this.label_mach3mill_status.Size = new System.Drawing.Size(209, 23);
            this.label_mach3mill_status.TabIndex = 9;
            this.label_mach3mill_status.Text = "Searching for Mach3Mill...";
            this.label_mach3mill_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_Loading_Mach3Mill
            // 
            this.pictureBox_Loading_Mach3Mill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Loading_Mach3Mill.Image = global::Mach3_Client.Properties.Resources.giphy;
            this.pictureBox_Loading_Mach3Mill.Location = new System.Drawing.Point(79, 202);
            this.pictureBox_Loading_Mach3Mill.Name = "pictureBox_Loading_Mach3Mill";
            this.pictureBox_Loading_Mach3Mill.Size = new System.Drawing.Size(141, 32);
            this.pictureBox_Loading_Mach3Mill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Loading_Mach3Mill.TabIndex = 9;
            this.pictureBox_Loading_Mach3Mill.TabStop = false;
            // 
            // picture_discovery_mode_spinner
            // 
            this.picture_discovery_mode_spinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picture_discovery_mode_spinner.Image = global::Mach3_Client.Properties.Resources.giphy;
            this.picture_discovery_mode_spinner.Location = new System.Drawing.Point(66, 149);
            this.picture_discovery_mode_spinner.Name = "picture_discovery_mode_spinner";
            this.picture_discovery_mode_spinner.Size = new System.Drawing.Size(206, 32);
            this.picture_discovery_mode_spinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_discovery_mode_spinner.TabIndex = 7;
            this.picture_discovery_mode_spinner.TabStop = false;
            this.picture_discovery_mode_spinner.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mach3_Client.Properties.Resources.RemoteNCLogo;
            this.pictureBox1.Location = new System.Drawing.Point(14, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Discovery Mode: ";
            // 
            // table_broadcast_port_info
            // 
            this.table_broadcast_port_info.ColumnCount = 2;
            this.table_broadcast_port_info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.table_broadcast_port_info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_broadcast_port_info.Controls.Add(this.label_tcp_receive_port, 1, 1);
            this.table_broadcast_port_info.Controls.Add(this.label6, 0, 1);
            this.table_broadcast_port_info.Controls.Add(this.label13, 0, 0);
            this.table_broadcast_port_info.Controls.Add(this.label_broadcast_listen_port, 1, 0);
            this.table_broadcast_port_info.Location = new System.Drawing.Point(6, 201);
            this.table_broadcast_port_info.Name = "table_broadcast_port_info";
            this.table_broadcast_port_info.RowCount = 2;
            this.table_broadcast_port_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_broadcast_port_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.table_broadcast_port_info.Size = new System.Drawing.Size(327, 65);
            this.table_broadcast_port_info.TabIndex = 11;
            this.table_broadcast_port_info.Visible = false;
            // 
            // label_tcp_receive_port
            // 
            this.label_tcp_receive_port.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_tcp_receive_port.AutoSize = true;
            this.label_tcp_receive_port.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tcp_receive_port.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_tcp_receive_port.Location = new System.Drawing.Point(221, 35);
            this.label_tcp_receive_port.Name = "label_tcp_receive_port";
            this.label_tcp_receive_port.Size = new System.Drawing.Size(41, 23);
            this.label_tcp_receive_port.TabIndex = 11;
            this.label_tcp_receive_port.Text = "N/A";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(67, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "TCP Receive Port: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label13.Location = new System.Drawing.Point(46, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 23);
            this.label13.TabIndex = 2;
            this.label13.Text = "UDP Broadcast Port: ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label_broadcast_listen_port
            // 
            this.label_broadcast_listen_port.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_broadcast_listen_port.AutoSize = true;
            this.label_broadcast_listen_port.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_broadcast_listen_port.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_broadcast_listen_port.Location = new System.Drawing.Point(221, 3);
            this.label_broadcast_listen_port.Name = "label_broadcast_listen_port";
            this.label_broadcast_listen_port.Size = new System.Drawing.Size(41, 23);
            this.label_broadcast_listen_port.TabIndex = 4;
            this.label_broadcast_listen_port.Text = "N/A";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.06779F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.93221F));
            this.tableLayoutPanel1.Controls.Add(this.label_udpBroadcastGroupBox_message, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_discovery_mode_OnOff, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(29, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(279, 99);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // label_udpBroadcastGroupBox_message
            // 
            this.label_udpBroadcastGroupBox_message.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_udpBroadcastGroupBox_message.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label_udpBroadcastGroupBox_message, 2);
            this.label_udpBroadcastGroupBox_message.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_udpBroadcastGroupBox_message.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_udpBroadcastGroupBox_message.ForeColor = System.Drawing.Color.DarkRed;
            this.label_udpBroadcastGroupBox_message.Location = new System.Drawing.Point(11, 69);
            this.label_udpBroadcastGroupBox_message.Name = "label_udpBroadcastGroupBox_message";
            this.label_udpBroadcastGroupBox_message.Size = new System.Drawing.Size(257, 23);
            this.label_udpBroadcastGroupBox_message.TabIndex = 10;
            this.label_udpBroadcastGroupBox_message.Text = "Please Ensure Mach3 is Running";
            this.label_udpBroadcastGroupBox_message.Click += new System.EventHandler(this.label8_Click);
            // 
            // button_discovery_mode_OnOff
            // 
            this.button_discovery_mode_OnOff.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_discovery_mode_OnOff.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_discovery_mode_OnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_discovery_mode_OnOff.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_discovery_mode_OnOff.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_discovery_mode_OnOff.Location = new System.Drawing.Point(181, 12);
            this.button_discovery_mode_OnOff.Name = "button_discovery_mode_OnOff";
            this.button_discovery_mode_OnOff.Size = new System.Drawing.Size(87, 37);
            this.button_discovery_mode_OnOff.TabIndex = 11;
            this.button_discovery_mode_OnOff.Text = "On";
            this.button_discovery_mode_OnOff.UseVisualStyleBackColor = true;
            this.button_discovery_mode_OnOff.Click += new System.EventHandler(this.button_discovery_mode_OnOff_Click_1);
            // 
            // table_general_connection_info
            // 
            this.table_general_connection_info.ColumnCount = 2;
            this.table_general_connection_info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.64357F));
            this.table_general_connection_info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.35644F));
            this.table_general_connection_info.Controls.Add(this.label_server_ip, 1, 2);
            this.table_general_connection_info.Controls.Add(this.label5, 0, 2);
            this.table_general_connection_info.Controls.Add(this.label_connect_status, 1, 1);
            this.table_general_connection_info.Controls.Add(this.label9, 0, 1);
            this.table_general_connection_info.Controls.Add(this.label_myIP, 1, 0);
            this.table_general_connection_info.Controls.Add(this.label14, 0, 0);
            this.table_general_connection_info.Location = new System.Drawing.Point(355, 32);
            this.table_general_connection_info.Name = "table_general_connection_info";
            this.table_general_connection_info.RowCount = 3;
            this.table_general_connection_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_general_connection_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_general_connection_info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_general_connection_info.Size = new System.Drawing.Size(303, 92);
            this.table_general_connection_info.TabIndex = 9;
            // 
            // label_server_ip
            // 
            this.label_server_ip.AutoSize = true;
            this.label_server_ip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_server_ip.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label_server_ip.Location = new System.Drawing.Point(111, 60);
            this.label_server_ip.Name = "label_server_ip";
            this.label_server_ip.Size = new System.Drawing.Size(142, 28);
            this.label_server_ip.TabIndex = 7;
            this.label_server_ip.Text = "Not Available";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 28);
            this.label5.TabIndex = 6;
            this.label5.Text = "Server IP: ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label_connect_status
            // 
            this.label_connect_status.AutoSize = true;
            this.label_connect_status.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_connect_status.ForeColor = System.Drawing.Color.DarkRed;
            this.label_connect_status.Location = new System.Drawing.Point(111, 30);
            this.label_connect_status.Name = "label_connect_status";
            this.label_connect_status.Size = new System.Drawing.Size(154, 28);
            this.label_connect_status.TabIndex = 5;
            this.label_connect_status.Text = "Not Connected";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(3, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 28);
            this.label9.TabIndex = 4;
            this.label9.Text = "Status: ";
            // 
            // label_myIP
            // 
            this.label_myIP.AutoSize = true;
            this.label_myIP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_myIP.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_myIP.Location = new System.Drawing.Point(111, 0);
            this.label_myIP.Name = "label_myIP";
            this.label_myIP.Size = new System.Drawing.Size(147, 28);
            this.label_myIP.TabIndex = 3;
            this.label_myIP.Text = "192.168.31.42";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 28);
            this.label14.TabIndex = 0;
            this.label14.Text = "My IP:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // groupBox_tcp
            // 
            this.groupBox_tcp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_tcp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_tcp.Controls.Add(this.tableLayoutPanel3);
            this.groupBox_tcp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_tcp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_tcp.ForeColor = System.Drawing.Color.Red;
            this.groupBox_tcp.Location = new System.Drawing.Point(336, 149);
            this.groupBox_tcp.Name = "groupBox_tcp";
            this.groupBox_tcp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox_tcp.Size = new System.Drawing.Size(326, 138);
            this.groupBox_tcp.TabIndex = 7;
            this.groupBox_tcp.TabStop = false;
            this.groupBox_tcp.Text = "TCP/IP Receiving";
            this.groupBox_tcp.Visible = false;
            this.groupBox_tcp.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.19672F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.80328F));
            this.tableLayoutPanel3.Controls.Add(this.label_tcp_target_port, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label_tcp_local_port, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label19, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(22, 29);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(227, 105);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // label_tcp_target_port
            // 
            this.label_tcp_target_port.AutoSize = true;
            this.label_tcp_target_port.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tcp_target_port.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_tcp_target_port.Location = new System.Drawing.Point(135, 35);
            this.label_tcp_target_port.Name = "label_tcp_target_port";
            this.label_tcp_target_port.Size = new System.Drawing.Size(43, 23);
            this.label_tcp_target_port.TabIndex = 4;
            this.label_tcp_target_port.Text = "N/A";
            // 
            // label_tcp_local_port
            // 
            this.label_tcp_local_port.AutoSize = true;
            this.label_tcp_local_port.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tcp_local_port.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_tcp_local_port.Location = new System.Drawing.Point(135, 0);
            this.label_tcp_local_port.Name = "label_tcp_local_port";
            this.label_tcp_local_port.Size = new System.Drawing.Size(43, 23);
            this.label_tcp_local_port.TabIndex = 3;
            this.label_tcp_local_port.Text = "N/A";
            this.label_tcp_local_port.Click += new System.EventHandler(this.label18_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label19.Location = new System.Drawing.Point(3, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 23);
            this.label19.TabIndex = 2;
            this.label19.Text = "Target Port: ";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.button1, 2);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(22, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "See Recent Packets";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Enabled = false;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label20.Location = new System.Drawing.Point(3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 23);
            this.label20.TabIndex = 0;
            this.label20.Text = "Local Port: ";
            // 
            // groupBox_udpBroadcast
            // 
            this.groupBox_udpBroadcast.Controls.Add(this.table_broadcast_port_info);
            this.groupBox_udpBroadcast.Controls.Add(this.picture_discovery_mode_spinner);
            this.groupBox_udpBroadcast.Controls.Add(this.tableLayoutPanel1);
            this.groupBox_udpBroadcast.Enabled = false;
            this.groupBox_udpBroadcast.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_udpBroadcast.Location = new System.Drawing.Point(336, 148);
            this.groupBox_udpBroadcast.Name = "groupBox_udpBroadcast";
            this.groupBox_udpBroadcast.Size = new System.Drawing.Size(333, 291);
            this.groupBox_udpBroadcast.TabIndex = 10;
            this.groupBox_udpBroadcast.TabStop = false;
            this.groupBox_udpBroadcast.Text = "UDP Broadcast";
            // 
            // label_udp_local_port
            // 
            this.label_udp_local_port.AutoSize = true;
            this.label_udp_local_port.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_udp_local_port.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_udp_local_port.Location = new System.Drawing.Point(135, 0);
            this.label_udp_local_port.Name = "label_udp_local_port";
            this.label_udp_local_port.Size = new System.Drawing.Size(43, 23);
            this.label_udp_local_port.TabIndex = 3;
            this.label_udp_local_port.Text = "N/A";
            // 
            // label_udp_target_port
            // 
            this.label_udp_target_port.AutoSize = true;
            this.label_udp_target_port.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_udp_target_port.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_udp_target_port.Location = new System.Drawing.Point(135, 35);
            this.label_udp_target_port.Name = "label_udp_target_port";
            this.label_udp_target_port.Size = new System.Drawing.Size(43, 23);
            this.label_udp_target_port.TabIndex = 4;
            this.label_udp_target_port.Text = "N/A";
            // 
            // groupBox_udp
            // 
            this.groupBox_udp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_udp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_udp.Controls.Add(this.tableLayoutPanel2);
            this.groupBox_udp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_udp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_udp.ForeColor = System.Drawing.Color.Red;
            this.groupBox_udp.Location = new System.Drawing.Point(336, 295);
            this.groupBox_udp.Name = "groupBox_udp";
            this.groupBox_udp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox_udp.Size = new System.Drawing.Size(326, 145);
            this.groupBox_udp.TabIndex = 8;
            this.groupBox_udp.TabStop = false;
            this.groupBox_udp.Text = "UDP Streaming";
            this.groupBox_udp.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.19672F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.80328F));
            this.tableLayoutPanel2.Controls.Add(this.label_udp_target_port, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label_udp_local_port, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(22, 29);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(227, 105);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label11.Location = new System.Drawing.Point(3, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 23);
            this.label11.TabIndex = 2;
            this.label11.Text = "Target Port: ";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.button2, 2);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(22, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "See Recent Packets";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 23);
            this.label15.TabIndex = 0;
            this.label15.Text = "Local Port: ";
            // 
            // button_disconFromServer
            // 
            this.button_disconFromServer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_disconFromServer.Enabled = false;
            this.button_disconFromServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_disconFromServer.ForeColor = System.Drawing.Color.DarkRed;
            this.button_disconFromServer.Location = new System.Drawing.Point(56, 396);
            this.button_disconFromServer.Name = "button_disconFromServer";
            this.button_disconFromServer.Size = new System.Drawing.Size(222, 42);
            this.button_disconFromServer.TabIndex = 11;
            this.button_disconFromServer.Text = "Disconnect from Server";
            this.button_disconFromServer.UseVisualStyleBackColor = true;
            this.button_disconFromServer.Click += new System.EventHandler(this.button_disconFromServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 459);
            this.Controls.Add(this.button_disconFromServer);
            this.Controls.Add(this.groupBox_udp);
            this.Controls.Add(this.groupBox_udpBroadcast);
            this.Controls.Add(this._groupBox_mach3mill_info);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.table_general_connection_info);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox_tcp);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "RemoteNC Mach3 Remote Control Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.table_mach3mill_info.ResumeLayout(false);
            this.table_mach3mill_info.PerformLayout();
            this._groupBox_mach3mill_info.ResumeLayout(false);
            this._groupBox_mach3mill_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading_Mach3Mill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_discovery_mode_spinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.table_broadcast_port_info.ResumeLayout(false);
            this.table_broadcast_port_info.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.table_general_connection_info.ResumeLayout(false);
            this.table_general_connection_info.PerformLayout();
            this.groupBox_tcp.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox_udpBroadcast.ResumeLayout(false);
            this.groupBox_udp.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel table_mach3mill_info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox _groupBox_mach3mill_info;
        private System.Windows.Forms.PictureBox picture_discovery_mode_spinner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel table_general_connection_info;
        private System.Windows.Forms.Label label_broadcast_listen_port;
        private System.Windows.Forms.Label label_myIP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_connect_status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox_tcp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label_tcp_target_port;
        private System.Windows.Forms.Label label_tcp_local_port;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label_mach3mill_status;
        private System.Windows.Forms.PictureBox pictureBox_Loading_Mach3Mill;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_server_ip;
        private System.Windows.Forms.TableLayoutPanel table_broadcast_port_info;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_udpBroadcastGroupBox_message;
        private System.Windows.Forms.GroupBox groupBox_udpBroadcast;
        private System.Windows.Forms.Label label_tcp_receive_port;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_discovery_mode_OnOff;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_udp_local_port;
        private System.Windows.Forms.Label label_udp_target_port;
        private System.Windows.Forms.GroupBox groupBox_udp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button button_disconFromServer;
        private System.Windows.Forms.TextBox textbox_job_name;
        private System.Windows.Forms.TextBox textbox_customer_name;
        private System.Windows.Forms.TextBox textbox_password;
    }
}


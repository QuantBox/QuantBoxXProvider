namespace QuantBox.Design
{
    partial class XApiSettingsDialog
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XApiSettingsDialog));
            this.pnlList = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstConnection = new System.Windows.Forms.ListBox();
            this.connectionInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddConnection = new System.Windows.Forms.Button();
            this.btnRemoveConnection = new System.Windows.Forms.Button();
            this.btnCopyConnection = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstServer = new System.Windows.Forms.ListBox();
            this.serverInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.btnRemoveServer = new System.Windows.Forms.Button();
            this.btnCopyServer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.userInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnCopyUser = new System.Windows.Forms.Button();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.pnlList.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionInfoBindingSource)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoBindingSource)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.groupBox3);
            this.pnlList.Controls.Add(this.groupBox2);
            this.pnlList.Controls.Add(this.groupBox1);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlList.Location = new System.Drawing.Point(0, 0);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(416, 430);
            this.pnlList.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstConnection);
            this.groupBox3.Controls.Add(this.flowLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 138);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connections";
            // 
            // lstConnection
            // 
            this.lstConnection.DataSource = this.connectionInfoBindingSource;
            this.lstConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConnection.FormattingEnabled = true;
            this.lstConnection.ItemHeight = 17;
            this.lstConnection.Location = new System.Drawing.Point(3, 19);
            this.lstConnection.Name = "lstConnection";
            this.lstConnection.Size = new System.Drawing.Size(292, 116);
            this.lstConnection.TabIndex = 0;
            this.lstConnection.SelectedIndexChanged += new System.EventHandler(this.lstConnection_SelectedIndexChanged);
            // 
            // connectionInfoBindingSource
            // 
            this.connectionInfoBindingSource.DataSource = typeof(ConnectionInfo);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnAddConnection);
            this.flowLayoutPanel3.Controls.Add(this.btnRemoveConnection);
            this.flowLayoutPanel3.Controls.Add(this.btnCopyConnection);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(295, 19);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(118, 116);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // btnAddConnection
            // 
            this.btnAddConnection.Location = new System.Drawing.Point(3, 3);
            this.btnAddConnection.Name = "btnAddConnection";
            this.btnAddConnection.Size = new System.Drawing.Size(108, 26);
            this.btnAddConnection.TabIndex = 0;
            this.btnAddConnection.Text = "Add";
            this.btnAddConnection.UseVisualStyleBackColor = true;
            this.btnAddConnection.Click += new System.EventHandler(this.btnAddConnection_Click);
            // 
            // btnRemoveConnection
            // 
            this.btnRemoveConnection.Location = new System.Drawing.Point(3, 35);
            this.btnRemoveConnection.Name = "btnRemoveConnection";
            this.btnRemoveConnection.Size = new System.Drawing.Size(108, 26);
            this.btnRemoveConnection.TabIndex = 0;
            this.btnRemoveConnection.Text = "Remove";
            this.btnRemoveConnection.UseVisualStyleBackColor = true;
            this.btnRemoveConnection.Click += new System.EventHandler(this.btnRemoveConnection_Click);
            // 
            // btnCopyConnection
            // 
            this.btnCopyConnection.Location = new System.Drawing.Point(3, 67);
            this.btnCopyConnection.Name = "btnCopyConnection";
            this.btnCopyConnection.Size = new System.Drawing.Size(108, 26);
            this.btnCopyConnection.TabIndex = 0;
            this.btnCopyConnection.Text = "Copy";
            this.btnCopyConnection.UseVisualStyleBackColor = true;
            this.btnCopyConnection.Click += new System.EventHandler(this.btnCopyConnection_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstServer);
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servers";
            // 
            // lstServer
            // 
            this.lstServer.DataSource = this.serverInfoBindingSource;
            this.lstServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstServer.FormattingEnabled = true;
            this.lstServer.ItemHeight = 17;
            this.lstServer.Location = new System.Drawing.Point(3, 19);
            this.lstServer.Name = "lstServer";
            this.lstServer.Size = new System.Drawing.Size(292, 116);
            this.lstServer.TabIndex = 0;
            this.lstServer.SelectedIndexChanged += new System.EventHandler(this.lstServer_SelectedIndexChanged);
            // 
            // serverInfoBindingSource
            // 
            this.serverInfoBindingSource.DataSource = typeof(ServerInfo);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnAddServer);
            this.flowLayoutPanel2.Controls.Add(this.btnRemoveServer);
            this.flowLayoutPanel2.Controls.Add(this.btnCopyServer);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(295, 19);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(118, 116);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnAddServer
            // 
            this.btnAddServer.Location = new System.Drawing.Point(3, 3);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(108, 26);
            this.btnAddServer.TabIndex = 0;
            this.btnAddServer.Text = "Add";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // btnRemoveServer
            // 
            this.btnRemoveServer.Location = new System.Drawing.Point(3, 35);
            this.btnRemoveServer.Name = "btnRemoveServer";
            this.btnRemoveServer.Size = new System.Drawing.Size(108, 26);
            this.btnRemoveServer.TabIndex = 0;
            this.btnRemoveServer.Text = "Remove";
            this.btnRemoveServer.UseVisualStyleBackColor = true;
            this.btnRemoveServer.Click += new System.EventHandler(this.btnRemoveServer_Click);
            // 
            // btnCopyServer
            // 
            this.btnCopyServer.Location = new System.Drawing.Point(3, 67);
            this.btnCopyServer.Name = "btnCopyServer";
            this.btnCopyServer.Size = new System.Drawing.Size(108, 26);
            this.btnCopyServer.TabIndex = 0;
            this.btnCopyServer.Text = "Copy";
            this.btnCopyServer.UseVisualStyleBackColor = true;
            this.btnCopyServer.Click += new System.EventHandler(this.btnCopyServer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstUser);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users";
            // 
            // lstUser
            // 
            this.lstUser.DataSource = this.userInfoBindingSource;
            this.lstUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 17;
            this.lstUser.Location = new System.Drawing.Point(3, 19);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(292, 116);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            // 
            // userInfoBindingSource
            // 
            this.userInfoBindingSource.DataSource = typeof(UserInfo);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddUser);
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveUser);
            this.flowLayoutPanel1.Controls.Add(this.btnCopyUser);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(295, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(118, 116);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(3, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(108, 26);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(3, 35);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(108, 26);
            this.btnRemoveUser.TabIndex = 0;
            this.btnRemoveUser.Text = "Remove";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnCopyUser
            // 
            this.btnCopyUser.Location = new System.Drawing.Point(3, 67);
            this.btnCopyUser.Name = "btnCopyUser";
            this.btnCopyUser.Size = new System.Drawing.Size(108, 26);
            this.btnCopyUser.TabIndex = 0;
            this.btnCopyUser.Text = "Copy";
            this.btnCopyUser.UseVisualStyleBackColor = true;
            this.btnCopyUser.Click += new System.EventHandler(this.btnCopyUser_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGrid.Location = new System.Drawing.Point(524, 66);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(231, 184);
            this.propertyGrid.TabIndex = 5;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // XApiSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 430);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.pnlList);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XApiSettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XApiSettings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XApiSettingsDialogs_FormClosed);
            this.Load += new System.EventHandler(this.XApiSettingsDialog_Load);
            this.pnlList.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectionInfoBindingSource)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoBindingSource)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstConnection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnAddConnection;
        private System.Windows.Forms.Button btnRemoveConnection;
        private System.Windows.Forms.Button btnCopyConnection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstServer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.Button btnRemoveServer;
        private System.Windows.Forms.Button btnCopyServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnCopyUser;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.BindingSource userInfoBindingSource;
        private System.Windows.Forms.BindingSource serverInfoBindingSource;
        private System.Windows.Forms.BindingSource connectionInfoBindingSource;
    }
}
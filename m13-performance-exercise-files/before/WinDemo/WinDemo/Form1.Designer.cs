namespace WinDemo
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEID = new System.Windows.Forms.TextBox();
            this.buttonGetEmployee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFName = new System.Windows.Forms.TextBox();
            this.textBoxLName = new System.Windows.Forms.TextBox();
            this.textBoxDName = new System.Windows.Forms.TextBox();
            this.buttonDeleteLog = new System.Windows.Forms.Button();
            this.linkLabelUpdateDepartmentName = new System.Windows.Forms.LinkLabel();
            this.labelDeptId = new System.Windows.Forms.Label();
            this.dataGridViewAppLog = new System.Windows.Forms.DataGridView();
            this.buttonUpdateLog = new System.Windows.Forms.Button();
            this.listViewStats = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelOldName = new System.Windows.Forms.Label();
            this.buttonViewLogXML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppLog)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Employee ID:";
            // 
            // textBoxEID
            // 
            this.textBoxEID.Location = new System.Drawing.Point(117, 10);
            this.textBoxEID.Name = "textBoxEID";
            this.textBoxEID.Size = new System.Drawing.Size(100, 20);
            this.textBoxEID.TabIndex = 1;
            // 
            // buttonGetEmployee
            // 
            this.buttonGetEmployee.Location = new System.Drawing.Point(232, 8);
            this.buttonGetEmployee.Name = "buttonGetEmployee";
            this.buttonGetEmployee.Size = new System.Drawing.Size(40, 23);
            this.buttonGetEmployee.TabIndex = 2;
            this.buttonGetEmployee.Text = "GO";
            this.buttonGetEmployee.UseVisualStyleBackColor = true;
            this.buttonGetEmployee.Click += new System.EventHandler(this.buttonGetEmployee_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Department:";
            // 
            // textBoxFName
            // 
            this.textBoxFName.Location = new System.Drawing.Point(117, 73);
            this.textBoxFName.Name = "textBoxFName";
            this.textBoxFName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFName.TabIndex = 1;
            // 
            // textBoxLName
            // 
            this.textBoxLName.Location = new System.Drawing.Point(117, 99);
            this.textBoxLName.Name = "textBoxLName";
            this.textBoxLName.Size = new System.Drawing.Size(100, 20);
            this.textBoxLName.TabIndex = 1;
            // 
            // textBoxDName
            // 
            this.textBoxDName.Location = new System.Drawing.Point(117, 126);
            this.textBoxDName.Name = "textBoxDName";
            this.textBoxDName.Size = new System.Drawing.Size(100, 20);
            this.textBoxDName.TabIndex = 1;
            // 
            // buttonDeleteLog
            // 
            this.buttonDeleteLog.Location = new System.Drawing.Point(19, 321);
            this.buttonDeleteLog.Name = "buttonDeleteLog";
            this.buttonDeleteLog.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteLog.TabIndex = 3;
            this.buttonDeleteLog.Text = "Delete Log";
            this.buttonDeleteLog.UseVisualStyleBackColor = true;
            this.buttonDeleteLog.Click += new System.EventHandler(this.buttonDeleteLog_Click);
            // 
            // linkLabelUpdateDepartmentName
            // 
            this.linkLabelUpdateDepartmentName.AutoSize = true;
            this.linkLabelUpdateDepartmentName.Location = new System.Drawing.Point(223, 129);
            this.linkLabelUpdateDepartmentName.Name = "linkLabelUpdateDepartmentName";
            this.linkLabelUpdateDepartmentName.Size = new System.Drawing.Size(42, 13);
            this.linkLabelUpdateDepartmentName.TabIndex = 4;
            this.linkLabelUpdateDepartmentName.TabStop = true;
            this.linkLabelUpdateDepartmentName.Text = "Update";
            this.linkLabelUpdateDepartmentName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUpdateDepartmentName_LinkClicked);
            // 
            // labelDeptId
            // 
            this.labelDeptId.AutoSize = true;
            this.labelDeptId.Location = new System.Drawing.Point(16, 181);
            this.labelDeptId.Name = "labelDeptId";
            this.labelDeptId.Size = new System.Drawing.Size(13, 13);
            this.labelDeptId.TabIndex = 5;
            this.labelDeptId.Text = "0";
            // 
            // dataGridViewAppLog
            // 
            this.dataGridViewAppLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppLog.Location = new System.Drawing.Point(19, 194);
            this.dataGridViewAppLog.Name = "dataGridViewAppLog";
            this.dataGridViewAppLog.Size = new System.Drawing.Size(426, 121);
            this.dataGridViewAppLog.TabIndex = 6;
            this.dataGridViewAppLog.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewAppLog_DataError);
            // 
            // buttonUpdateLog
            // 
            this.buttonUpdateLog.Location = new System.Drawing.Point(117, 321);
            this.buttonUpdateLog.Name = "buttonUpdateLog";
            this.buttonUpdateLog.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateLog.TabIndex = 7;
            this.buttonUpdateLog.Text = "Update Log";
            this.buttonUpdateLog.UseVisualStyleBackColor = true;
            this.buttonUpdateLog.Click += new System.EventHandler(this.buttonUpdateLog_Click);
            // 
            // listViewStats
            // 
            this.listViewStats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewStats.Location = new System.Drawing.Point(453, 8);
            this.listViewStats.Name = "listViewStats";
            this.listViewStats.Size = new System.Drawing.Size(194, 307);
            this.listViewStats.TabIndex = 8;
            this.listViewStats.UseCompatibleStateImageBehavior = false;
            this.listViewStats.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Statistic";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 90;
            // 
            // labelOldName
            // 
            this.labelOldName.AutoSize = true;
            this.labelOldName.Location = new System.Drawing.Point(114, 149);
            this.labelOldName.Name = "labelOldName";
            this.labelOldName.Size = new System.Drawing.Size(0, 13);
            this.labelOldName.TabIndex = 9;
            this.labelOldName.Visible = false;
            // 
            // buttonViewLogXML
            // 
            this.buttonViewLogXML.Location = new System.Drawing.Point(334, 321);
            this.buttonViewLogXML.Name = "buttonViewLogXML";
            this.buttonViewLogXML.Size = new System.Drawing.Size(111, 23);
            this.buttonViewLogXML.TabIndex = 10;
            this.buttonViewLogXML.Text = "View Log XML";
            this.buttonViewLogXML.UseVisualStyleBackColor = true;
            this.buttonViewLogXML.Click += new System.EventHandler(this.buttonViewLogXML_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 356);
            this.Controls.Add(this.buttonViewLogXML);
            this.Controls.Add(this.labelOldName);
            this.Controls.Add(this.listViewStats);
            this.Controls.Add(this.buttonUpdateLog);
            this.Controls.Add(this.dataGridViewAppLog);
            this.Controls.Add(this.labelDeptId);
            this.Controls.Add(this.linkLabelUpdateDepartmentName);
            this.Controls.Add(this.buttonDeleteLog);
            this.Controls.Add(this.buttonGetEmployee);
            this.Controls.Add(this.textBoxDName);
            this.Controls.Add(this.textBoxLName);
            this.Controls.Add(this.textBoxFName);
            this.Controls.Add(this.textBoxEID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEID;
        private System.Windows.Forms.Button buttonGetEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFName;
        private System.Windows.Forms.TextBox textBoxLName;
        private System.Windows.Forms.TextBox textBoxDName;
        private System.Windows.Forms.Button buttonDeleteLog;
        private System.Windows.Forms.LinkLabel linkLabelUpdateDepartmentName;
        private System.Windows.Forms.Label labelDeptId;
        private System.Windows.Forms.DataGridView dataGridViewAppLog;
        private System.Windows.Forms.Button buttonUpdateLog;
        private System.Windows.Forms.ListView listViewStats;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label labelOldName;
        private System.Windows.Forms.Button buttonViewLogXML;
    }
}


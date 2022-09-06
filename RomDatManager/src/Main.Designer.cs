namespace RomDatManager
{
    partial class frmMain
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
            this.txtRomsDataFile = new System.Windows.Forms.TextBox();
            this.txtRomsVerified = new System.Windows.Forms.TextBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnRemoveUnknown = new System.Windows.Forms.Button();
            this.btnReloadFiles = new System.Windows.Forms.Button();
            this.btnGenerateDat = new System.Windows.Forms.Button();
            this.txtDatFile = new System.Windows.Forms.TextBox();
            this.txtFolderRoms = new System.Windows.Forms.TextBox();
            this.cboFileCompression = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDatRomsTxt = new System.Windows.Forms.Label();
            this.lblRomsFolderTxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRomsDataFile
            // 
            this.txtRomsDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRomsDataFile.Location = new System.Drawing.Point(12, 28);
            this.txtRomsDataFile.Multiline = true;
            this.txtRomsDataFile.Name = "txtRomsDataFile";
            this.txtRomsDataFile.ReadOnly = true;
            this.txtRomsDataFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRomsDataFile.Size = new System.Drawing.Size(211, 330);
            this.txtRomsDataFile.TabIndex = 2;
            this.txtRomsDataFile.WordWrap = false;
            // 
            // txtRomsVerified
            // 
            this.txtRomsVerified.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRomsVerified.Location = new System.Drawing.Point(229, 28);
            this.txtRomsVerified.Multiline = true;
            this.txtRomsVerified.Name = "txtRomsVerified";
            this.txtRomsVerified.ReadOnly = true;
            this.txtRomsVerified.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRomsVerified.Size = new System.Drawing.Size(211, 330);
            this.txtRomsVerified.TabIndex = 3;
            this.txtRomsVerified.WordWrap = false;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(446, 292);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(113, 23);
            this.btnRename.TabIndex = 4;
            this.btnRename.Text = "Rename Roms";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnRemoveUnknown
            // 
            this.btnRemoveUnknown.Location = new System.Drawing.Point(446, 321);
            this.btnRemoveUnknown.Name = "btnRemoveUnknown";
            this.btnRemoveUnknown.Size = new System.Drawing.Size(113, 37);
            this.btnRemoveUnknown.TabIndex = 5;
            this.btnRemoveUnknown.Text = "Remove Unknown Roms";
            this.btnRemoveUnknown.UseVisualStyleBackColor = true;
            this.btnRemoveUnknown.Click += new System.EventHandler(this.btnRemoveUnknown_Click);
            // 
            // btnReloadFiles
            // 
            this.btnReloadFiles.Location = new System.Drawing.Point(446, 263);
            this.btnReloadFiles.Name = "btnReloadFiles";
            this.btnReloadFiles.Size = new System.Drawing.Size(113, 23);
            this.btnReloadFiles.TabIndex = 6;
            this.btnReloadFiles.Text = "Reload Roms";
            this.btnReloadFiles.UseVisualStyleBackColor = true;
            this.btnReloadFiles.Click += new System.EventHandler(this.btnReloadFiles_Click);
            // 
            // btnGenerateDat
            // 
            this.btnGenerateDat.Location = new System.Drawing.Point(447, 133);
            this.btnGenerateDat.Name = "btnGenerateDat";
            this.btnGenerateDat.Size = new System.Drawing.Size(113, 23);
            this.btnGenerateDat.TabIndex = 7;
            this.btnGenerateDat.Text = "Generate Dat";
            this.btnGenerateDat.UseVisualStyleBackColor = true;
            this.btnGenerateDat.Click += new System.EventHandler(this.btnGenerateDat_Click);
            // 
            // txtDatFile
            // 
            this.txtDatFile.Location = new System.Drawing.Point(447, 28);
            this.txtDatFile.Name = "txtDatFile";
            this.txtDatFile.Size = new System.Drawing.Size(113, 20);
            this.txtDatFile.TabIndex = 8;
            // 
            // txtFolderRoms
            // 
            this.txtFolderRoms.Location = new System.Drawing.Point(447, 67);
            this.txtFolderRoms.Name = "txtFolderRoms";
            this.txtFolderRoms.Size = new System.Drawing.Size(113, 20);
            this.txtFolderRoms.TabIndex = 9;
            // 
            // cboFileCompression
            // 
            this.cboFileCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileCompression.FormattingEnabled = true;
            this.cboFileCompression.Items.AddRange(new object[] {
            "Zip",
            "Uncompressed",
            "7z"});
            this.cboFileCompression.Location = new System.Drawing.Point(447, 106);
            this.cboFileCompression.Name = "cboFileCompression";
            this.cboFileCompression.Size = new System.Drawing.Size(112, 21);
            this.cboFileCompression.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "DataFile Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Roms Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Roms Compression";
            // 
            // lblDatRomsTxt
            // 
            this.lblDatRomsTxt.AutoSize = true;
            this.lblDatRomsTxt.Location = new System.Drawing.Point(12, 12);
            this.lblDatRomsTxt.Name = "lblDatRomsTxt";
            this.lblDatRomsTxt.Size = new System.Drawing.Size(76, 13);
            this.lblDatRomsTxt.TabIndex = 14;
            this.lblDatRomsTxt.Text = "DataFile Roms";
            // 
            // lblRomsFolderTxt
            // 
            this.lblRomsFolderTxt.AutoSize = true;
            this.lblRomsFolderTxt.Location = new System.Drawing.Point(226, 12);
            this.lblRomsFolderTxt.Name = "lblRomsFolderTxt";
            this.lblRomsFolderTxt.Size = new System.Drawing.Size(77, 13);
            this.lblRomsFolderTxt.TabIndex = 15;
            this.lblRomsFolderTxt.Text = "Roms in Folder";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 370);
            this.Controls.Add(this.lblRomsFolderTxt);
            this.Controls.Add(this.lblDatRomsTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboFileCompression);
            this.Controls.Add(this.txtFolderRoms);
            this.Controls.Add(this.txtDatFile);
            this.Controls.Add(this.btnGenerateDat);
            this.Controls.Add(this.btnReloadFiles);
            this.Controls.Add(this.btnRemoveUnknown);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.txtRomsDataFile);
            this.Controls.Add(this.txtRomsVerified);
            this.Name = "frmMain";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRomsDataFile;
        private System.Windows.Forms.TextBox txtRomsVerified;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnRemoveUnknown;
        private System.Windows.Forms.Button btnReloadFiles;
        private System.Windows.Forms.Button btnGenerateDat;
        private System.Windows.Forms.TextBox txtDatFile;
        private System.Windows.Forms.TextBox txtFolderRoms;
        private System.Windows.Forms.ComboBox cboFileCompression;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDatRomsTxt;
        private System.Windows.Forms.Label lblRomsFolderTxt;

    }
}


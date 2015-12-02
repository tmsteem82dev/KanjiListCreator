namespace KanjiListCreator
{
    partial class Main
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
            this.btnData = new System.Windows.Forms.Button();
            this.lvwData = new System.Windows.Forms.ListView();
            this.btnScrape = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveKanjiDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openKanjiDialog = new System.Windows.Forms.OpenFileDialog();
            this.chkJLPT1 = new System.Windows.Forms.CheckBox();
            this.chkJLPT2 = new System.Windows.Forms.CheckBox();
            this.chkJLPT3 = new System.Windows.Forms.CheckBox();
            this.chkJLPT4 = new System.Windows.Forms.CheckBox();
            this.chkJLPT5 = new System.Windows.Forms.CheckBox();
            this.lblGetData = new System.Windows.Forms.Label();
            this.lblKanjiCount = new System.Windows.Forms.Label();
            this.lblSelectedKanjiCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(16, 425);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(75, 23);
            this.btnData.TabIndex = 0;
            this.btnData.Text = "Get Data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // lvwData
            // 
            this.lvwData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwData.CheckBoxes = true;
            this.lvwData.Location = new System.Drawing.Point(143, 12);
            this.lvwData.Name = "lvwData";
            this.lvwData.Size = new System.Drawing.Size(553, 491);
            this.lvwData.TabIndex = 1;
            this.lvwData.UseCompatibleStateImageBehavior = false;
            this.lvwData.View = System.Windows.Forms.View.Details;
            // 
            // btnScrape
            // 
            this.btnScrape.Location = new System.Drawing.Point(12, 156);
            this.btnScrape.Name = "btnScrape";
            this.btnScrape.Size = new System.Drawing.Size(75, 23);
            this.btnScrape.TabIndex = 2;
            this.btnScrape.Text = "Scrape";
            this.btnScrape.UseVisualStyleBackColor = true;
            this.btnScrape.Click += new System.EventHandler(this.btnScrape_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(13, 284);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openKanjiDialog
            // 
            this.openKanjiDialog.FileName = "openFileDialog";
            // 
            // chkJLPT1
            // 
            this.chkJLPT1.AutoSize = true;
            this.chkJLPT1.Location = new System.Drawing.Point(13, 41);
            this.chkJLPT1.Name = "chkJLPT1";
            this.chkJLPT1.Size = new System.Drawing.Size(60, 17);
            this.chkJLPT1.TabIndex = 5;
            this.chkJLPT1.Text = "JLPT 1";
            this.chkJLPT1.UseVisualStyleBackColor = true;
            // 
            // chkJLPT2
            // 
            this.chkJLPT2.AutoSize = true;
            this.chkJLPT2.Location = new System.Drawing.Point(13, 64);
            this.chkJLPT2.Name = "chkJLPT2";
            this.chkJLPT2.Size = new System.Drawing.Size(60, 17);
            this.chkJLPT2.TabIndex = 6;
            this.chkJLPT2.Text = "JLPT 2";
            this.chkJLPT2.UseVisualStyleBackColor = true;
            // 
            // chkJLPT3
            // 
            this.chkJLPT3.AutoSize = true;
            this.chkJLPT3.Location = new System.Drawing.Point(12, 87);
            this.chkJLPT3.Name = "chkJLPT3";
            this.chkJLPT3.Size = new System.Drawing.Size(60, 17);
            this.chkJLPT3.TabIndex = 7;
            this.chkJLPT3.Text = "JLPT 3";
            this.chkJLPT3.UseVisualStyleBackColor = true;
            // 
            // chkJLPT4
            // 
            this.chkJLPT4.AutoSize = true;
            this.chkJLPT4.Location = new System.Drawing.Point(13, 110);
            this.chkJLPT4.Name = "chkJLPT4";
            this.chkJLPT4.Size = new System.Drawing.Size(60, 17);
            this.chkJLPT4.TabIndex = 8;
            this.chkJLPT4.Text = "JLPT 4";
            this.chkJLPT4.UseVisualStyleBackColor = true;
            // 
            // chkJLPT5
            // 
            this.chkJLPT5.AutoSize = true;
            this.chkJLPT5.Location = new System.Drawing.Point(12, 133);
            this.chkJLPT5.Name = "chkJLPT5";
            this.chkJLPT5.Size = new System.Drawing.Size(60, 17);
            this.chkJLPT5.TabIndex = 9;
            this.chkJLPT5.Text = "JLPT 5";
            this.chkJLPT5.UseVisualStyleBackColor = true;
            // 
            // lblGetData
            // 
            this.lblGetData.AutoSize = true;
            this.lblGetData.Location = new System.Drawing.Point(13, 22);
            this.lblGetData.Name = "lblGetData";
            this.lblGetData.Size = new System.Drawing.Size(91, 13);
            this.lblGetData.TabIndex = 10;
            this.lblGetData.Text = "Select data to get";
            // 
            // lblKanjiCount
            // 
            this.lblKanjiCount.AutoSize = true;
            this.lblKanjiCount.Location = new System.Drawing.Point(143, 510);
            this.lblKanjiCount.Name = "lblKanjiCount";
            this.lblKanjiCount.Size = new System.Drawing.Size(72, 13);
            this.lblKanjiCount.TabIndex = 11;
            this.lblKanjiCount.Text = "Kanji count: 0";
            // 
            // lblSelectedKanjiCount
            // 
            this.lblSelectedKanjiCount.AutoSize = true;
            this.lblSelectedKanjiCount.Location = new System.Drawing.Point(143, 527);
            this.lblSelectedKanjiCount.Name = "lblSelectedKanjiCount";
            this.lblSelectedKanjiCount.Size = new System.Drawing.Size(116, 13);
            this.lblSelectedKanjiCount.TabIndex = 12;
            this.lblSelectedKanjiCount.Text = "Selected kanji count: 0";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 547);
            this.Controls.Add(this.lblSelectedKanjiCount);
            this.Controls.Add(this.lblKanjiCount);
            this.Controls.Add(this.lblGetData);
            this.Controls.Add(this.chkJLPT5);
            this.Controls.Add(this.chkJLPT4);
            this.Controls.Add(this.chkJLPT3);
            this.Controls.Add(this.chkJLPT2);
            this.Controls.Add(this.chkJLPT1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnScrape);
            this.Controls.Add(this.lvwData);
            this.Controls.Add(this.btnData);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.ListView lvwData;
        private System.Windows.Forms.Button btnScrape;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveKanjiDialog;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openKanjiDialog;
        private System.Windows.Forms.CheckBox chkJLPT1;
        private System.Windows.Forms.CheckBox chkJLPT2;
        private System.Windows.Forms.CheckBox chkJLPT3;
        private System.Windows.Forms.CheckBox chkJLPT4;
        private System.Windows.Forms.CheckBox chkJLPT5;
        private System.Windows.Forms.Label lblGetData;
        private System.Windows.Forms.Label lblKanjiCount;
        private System.Windows.Forms.Label lblSelectedKanjiCount;
    }
}


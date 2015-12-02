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
            this.saveKanjiDialog = new System.Windows.Forms.SaveFileDialog();
            this.openKanjiDialog = new System.Windows.Forms.OpenFileDialog();
            this.chkJLPT1 = new System.Windows.Forms.CheckBox();
            this.chkJLPT2 = new System.Windows.Forms.CheckBox();
            this.chkJLPT3 = new System.Windows.Forms.CheckBox();
            this.chkJLPT4 = new System.Windows.Forms.CheckBox();
            this.chkJLPT5 = new System.Windows.Forms.CheckBox();
            this.lblGetData = new System.Windows.Forms.Label();
            this.lblKanjiCount = new System.Windows.Forms.Label();
            this.lblSelectedKanjiCount = new System.Windows.Forms.Label();
            this.btnProcessAll = new System.Windows.Forms.Button();
            this.folderKanjiDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLoadFromJson = new System.Windows.Forms.Button();
            this.btnAddFromJson = new System.Windows.Forms.Button();
            this.btnSaveToJson = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
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
            this.lvwData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwData.Location = new System.Drawing.Point(143, 12);
            this.lvwData.Name = "lvwData";
            this.lvwData.Size = new System.Drawing.Size(553, 491);
            this.lvwData.TabIndex = 1;
            this.lvwData.UseCompatibleStateImageBehavior = false;
            this.lvwData.View = System.Windows.Forms.View.Details;
            this.lvwData.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwData_ItemChecked);
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
            this.lblKanjiCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKanjiCount.AutoSize = true;
            this.lblKanjiCount.Location = new System.Drawing.Point(143, 510);
            this.lblKanjiCount.Name = "lblKanjiCount";
            this.lblKanjiCount.Size = new System.Drawing.Size(72, 13);
            this.lblKanjiCount.TabIndex = 11;
            this.lblKanjiCount.Text = "Kanji count: 0";
            // 
            // lblSelectedKanjiCount
            // 
            this.lblSelectedKanjiCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedKanjiCount.AutoSize = true;
            this.lblSelectedKanjiCount.Location = new System.Drawing.Point(143, 527);
            this.lblSelectedKanjiCount.Name = "lblSelectedKanjiCount";
            this.lblSelectedKanjiCount.Size = new System.Drawing.Size(116, 13);
            this.lblSelectedKanjiCount.TabIndex = 12;
            this.lblSelectedKanjiCount.Text = "Selected kanji count: 0";
            // 
            // btnProcessAll
            // 
            this.btnProcessAll.Location = new System.Drawing.Point(12, 196);
            this.btnProcessAll.Name = "btnProcessAll";
            this.btnProcessAll.Size = new System.Drawing.Size(75, 23);
            this.btnProcessAll.TabIndex = 13;
            this.btnProcessAll.Text = "ProcessAll";
            this.btnProcessAll.UseVisualStyleBackColor = true;
            this.btnProcessAll.Click += new System.EventHandler(this.btnProcessAll_Click);
            // 
            // btnLoadFromJson
            // 
            this.btnLoadFromJson.Location = new System.Drawing.Point(14, 314);
            this.btnLoadFromJson.Name = "btnLoadFromJson";
            this.btnLoadFromJson.Size = new System.Drawing.Size(104, 23);
            this.btnLoadFromJson.TabIndex = 14;
            this.btnLoadFromJson.Text = "Load from Json...";
            this.btnLoadFromJson.UseVisualStyleBackColor = true;
            this.btnLoadFromJson.Click += new System.EventHandler(this.btnLoadFromJson_Click);
            // 
            // btnAddFromJson
            // 
            this.btnAddFromJson.Location = new System.Drawing.Point(16, 285);
            this.btnAddFromJson.Name = "btnAddFromJson";
            this.btnAddFromJson.Size = new System.Drawing.Size(102, 23);
            this.btnAddFromJson.TabIndex = 15;
            this.btnAddFromJson.Text = "Add from Json...";
            this.btnAddFromJson.UseVisualStyleBackColor = true;
            this.btnAddFromJson.Click += new System.EventHandler(this.btnAddFromJson_Click);
            // 
            // btnSaveToJson
            // 
            this.btnSaveToJson.Location = new System.Drawing.Point(16, 246);
            this.btnSaveToJson.Name = "btnSaveToJson";
            this.btnSaveToJson.Size = new System.Drawing.Size(102, 23);
            this.btnSaveToJson.TabIndex = 16;
            this.btnSaveToJson.Text = "Save to Json...";
            this.btnSaveToJson.UseVisualStyleBackColor = true;
            this.btnSaveToJson.Click += new System.EventHandler(this.btnSaveToJson_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(16, 362);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 547);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveToJson);
            this.Controls.Add(this.btnAddFromJson);
            this.Controls.Add(this.btnLoadFromJson);
            this.Controls.Add(this.btnProcessAll);
            this.Controls.Add(this.lblSelectedKanjiCount);
            this.Controls.Add(this.lblKanjiCount);
            this.Controls.Add(this.lblGetData);
            this.Controls.Add(this.chkJLPT5);
            this.Controls.Add(this.chkJLPT4);
            this.Controls.Add(this.chkJLPT3);
            this.Controls.Add(this.chkJLPT2);
            this.Controls.Add(this.chkJLPT1);
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
        private System.Windows.Forms.SaveFileDialog saveKanjiDialog;
        private System.Windows.Forms.OpenFileDialog openKanjiDialog;
        private System.Windows.Forms.CheckBox chkJLPT1;
        private System.Windows.Forms.CheckBox chkJLPT2;
        private System.Windows.Forms.CheckBox chkJLPT3;
        private System.Windows.Forms.CheckBox chkJLPT4;
        private System.Windows.Forms.CheckBox chkJLPT5;
        private System.Windows.Forms.Label lblGetData;
        private System.Windows.Forms.Label lblKanjiCount;
        private System.Windows.Forms.Label lblSelectedKanjiCount;
        private System.Windows.Forms.Button btnProcessAll;
        private System.Windows.Forms.FolderBrowserDialog folderKanjiDialog;
        private System.Windows.Forms.Button btnLoadFromJson;
        private System.Windows.Forms.Button btnAddFromJson;
        private System.Windows.Forms.Button btnSaveToJson;
        private System.Windows.Forms.Button btnClear;
    }
}


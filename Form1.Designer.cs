namespace Codebutton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.current_directory = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.TextBox1 = new System.Windows.Forms.RichTextBox();
            this.commandRequester = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.appInfo = new System.Windows.Forms.RichTextBox();
            this.currentScript = new System.Windows.Forms.RichTextBox();
            this.activeAliasesText = new System.Windows.Forms.RichTextBox();
            this.title = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.title)).BeginInit();
            this.SuspendLayout();
            // 
            // current_directory
            // 
            this.current_directory.AutoSize = true;
            this.current_directory.Location = new System.Drawing.Point(5, 30);
            this.current_directory.Name = "current_directory";
            this.current_directory.Size = new System.Drawing.Size(216, 20);
            this.current_directory.TabIndex = 0;
            this.current_directory.Text = ".topleft_currentdir_box";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.progressBar1.Location = new System.Drawing.Point(1, 27);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(929, 23);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // TextBox1
            // 
            this.TextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.TextBox1.Font = new System.Drawing.Font("Cascadia Code", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.ForeColor = System.Drawing.Color.White;
            this.TextBox1.Location = new System.Drawing.Point(0, 21);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.Size = new System.Drawing.Size(925, 548);
            this.TextBox1.TabIndex = 2;
            this.TextBox1.Text = "";
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // commandRequester
            // 
            this.commandRequester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.commandRequester.ForeColor = System.Drawing.Color.White;
            this.commandRequester.Location = new System.Drawing.Point(0, 569);
            this.commandRequester.Name = "commandRequester";
            this.commandRequester.Size = new System.Drawing.Size(924, 41);
            this.commandRequester.TabIndex = 3;
            this.commandRequester.Text = "";
            this.commandRequester.TextChanged += new System.EventHandler(this.commandRequester_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(123, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(675, 200);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(861, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(10, 10);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // appInfo
            // 
            this.appInfo.Location = new System.Drawing.Point(845, 34);
            this.appInfo.Name = "appInfo";
            this.appInfo.Size = new System.Drawing.Size(10, 10);
            this.appInfo.TabIndex = 6;
            this.appInfo.Text = "";
            this.appInfo.Visible = false;
            // 
            // currentScript
            // 
            this.currentScript.Location = new System.Drawing.Point(453, 34);
            this.currentScript.Name = "currentScript";
            this.currentScript.Size = new System.Drawing.Size(10, 10);
            this.currentScript.TabIndex = 8;
            this.currentScript.Text = "";
            this.currentScript.Visible = false;
            // 
            // activeAliasesText
            // 
            this.activeAliasesText.Location = new System.Drawing.Point(437, 34);
            this.activeAliasesText.Name = "activeAliasesText";
            this.activeAliasesText.Size = new System.Drawing.Size(10, 10);
            this.activeAliasesText.TabIndex = 9;
            this.activeAliasesText.Text = "";
            this.activeAliasesText.Visible = false;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(1, -2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(923, 23);
            this.title.TabIndex = 10;
            this.title.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "🔴";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(20, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "🔴";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(38, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "🔴";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "MbConsole@dev";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(925, 609);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.activeAliasesText);
            this.Controls.Add(this.currentScript);
            this.Controls.Add(this.appInfo);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandRequester);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.current_directory);
            this.Font = new System.Drawing.Font("Cascadia Code", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "MbConsole@dev";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.title)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label current_directory;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox TextBox1;
        private System.Windows.Forms.RichTextBox commandRequester;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox appInfo;
        private System.Windows.Forms.RichTextBox currentScript;
        private System.Windows.Forms.RichTextBox activeAliasesText;
        private System.Windows.Forms.PictureBox title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}


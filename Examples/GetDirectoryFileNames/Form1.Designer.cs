namespace GetDirectoryFileNames
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_getFileNames = new System.Windows.Forms.Button();
            this.txt_Regex = new System.Windows.Forms.TextBox();
            this.regex = new System.Windows.Forms.Label();
            this.txt_fileNames = new System.Windows.Forms.RichTextBox();
            this.btn_chooseDir = new System.Windows.Forms.Button();
            this.txt_DirectoryPath = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.txt_nameHead = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_getFileNames
            // 
            this.btn_getFileNames.Location = new System.Drawing.Point(17, 282);
            this.btn_getFileNames.Name = "btn_getFileNames";
            this.btn_getFileNames.Size = new System.Drawing.Size(155, 23);
            this.btn_getFileNames.TabIndex = 0;
            this.btn_getFileNames.Text = "GetDirectoryFileNames";
            this.btn_getFileNames.UseVisualStyleBackColor = true;
            this.btn_getFileNames.Click += new System.EventHandler(this.btn_getFileNames_Click);
            // 
            // txt_Regex
            // 
            this.txt_Regex.Location = new System.Drawing.Point(15, 92);
            this.txt_Regex.Name = "txt_Regex";
            this.txt_Regex.Size = new System.Drawing.Size(155, 21);
            this.txt_Regex.TabIndex = 1;
            this.txt_Regex.Text = ".*?d.lib";
            this.txt_Regex.TextChanged += new System.EventHandler(this.txt_Regex_TextChanged);
            // 
            // regex
            // 
            this.regex.AutoSize = true;
            this.regex.Location = new System.Drawing.Point(15, 67);
            this.regex.Name = "regex";
            this.regex.Size = new System.Drawing.Size(41, 12);
            this.regex.TabIndex = 2;
            this.regex.Text = "Regex:";
            // 
            // txt_fileNames
            // 
            this.txt_fileNames.Location = new System.Drawing.Point(234, 64);
            this.txt_fileNames.Name = "txt_fileNames";
            this.txt_fileNames.Size = new System.Drawing.Size(708, 489);
            this.txt_fileNames.TabIndex = 3;
            this.txt_fileNames.Text = "";
            // 
            // btn_chooseDir
            // 
            this.btn_chooseDir.Location = new System.Drawing.Point(17, 13);
            this.btn_chooseDir.Name = "btn_chooseDir";
            this.btn_chooseDir.Size = new System.Drawing.Size(153, 23);
            this.btn_chooseDir.TabIndex = 4;
            this.btn_chooseDir.Text = "ChooseDirectory";
            this.btn_chooseDir.UseVisualStyleBackColor = true;
            this.btn_chooseDir.Click += new System.EventHandler(this.btn_chooseDir_Click);
            // 
            // txt_DirectoryPath
            // 
            this.txt_DirectoryPath.Location = new System.Drawing.Point(234, 13);
            this.txt_DirectoryPath.Name = "txt_DirectoryPath";
            this.txt_DirectoryPath.Size = new System.Drawing.Size(669, 21);
            this.txt_DirectoryPath.TabIndex = 5;
            this.txt_DirectoryPath.Text = "C:\\Program Files\\PCL 1.12.0\\3rdParty\\VTK\\lib";
            // 
            // btn_clear
            // 
            this.btn_clear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_clear.Location = new System.Drawing.Point(17, 479);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(155, 23);
            this.btn_clear.TabIndex = 6;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // txt_nameHead
            // 
            this.txt_nameHead.Location = new System.Drawing.Point(12, 375);
            this.txt_nameHead.Name = "txt_nameHead";
            this.txt_nameHead.Size = new System.Drawing.Size(211, 21);
            this.txt_nameHead.TabIndex = 7;
            this.txt_nameHead.Text = "$(PCL_ROOT)3rdParty\\VTK\\lib\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "TextHead:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 120);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(153, 125);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "提示：\n.*?d.lib  匹配以d.lib结尾的字符串\n.*?[0-9].lib 匹配以数字+.lib结尾的字符串";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 576);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nameHead);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.txt_DirectoryPath);
            this.Controls.Add(this.btn_chooseDir);
            this.Controls.Add(this.txt_fileNames);
            this.Controls.Add(this.regex);
            this.Controls.Add(this.txt_Regex);
            this.Controls.Add(this.btn_getFileNames);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_getFileNames;
        private System.Windows.Forms.TextBox txt_Regex;
        private System.Windows.Forms.Label regex;
        private System.Windows.Forms.RichTextBox txt_fileNames;
        private System.Windows.Forms.Button btn_chooseDir;
        private System.Windows.Forms.TextBox txt_DirectoryPath;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TextBox txt_nameHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}


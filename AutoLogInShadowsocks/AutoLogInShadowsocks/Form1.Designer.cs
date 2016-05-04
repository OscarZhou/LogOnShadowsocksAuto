namespace AutoLogInShadowsocks
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_path = new System.Windows.Forms.Button();
            this.lb_path = new System.Windows.Forms.Label();
            this.btn_matching = new System.Windows.Forms.Button();
            this.webbrowser = new System.Windows.Forms.WebBrowser();
            this.lb_content = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(12, 12);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(171, 23);
            this.btn_path.TabIndex = 1;
            this.btn_path.Text = "选择Shadowsock.exe文件路径：";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // lb_path
            // 
            this.lb_path.AutoSize = true;
            this.lb_path.Location = new System.Drawing.Point(10, 75);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new System.Drawing.Size(59, 12);
            this.lb_path.TabIndex = 2;
            this.lb_path.Text = "";
            // 
            // btn_matching
            // 
            this.btn_matching.Location = new System.Drawing.Point(12, 239);
            this.btn_matching.Name = "btn_matching";
            this.btn_matching.Size = new System.Drawing.Size(75, 23);
            this.btn_matching.TabIndex = 3;
            this.btn_matching.Text = "匹配";
            this.btn_matching.UseVisualStyleBackColor = true;
            this.btn_matching.Click += new System.EventHandler(this.btn_matching_Click);
            // 
            // webbrowser
            // 
            this.webbrowser.Location = new System.Drawing.Point(211, 12);
            this.webbrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webbrowser.Name = "webbrowser";
            this.webbrowser.Size = new System.Drawing.Size(335, 250);
            this.webbrowser.TabIndex = 5;
            this.webbrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webbrowser_DocumentCompleted);
            // 
            // lb_content
            // 
            this.lb_content.AutoSize = true;
            this.lb_content.Location = new System.Drawing.Point(10, 136);
            this.lb_content.Name = "lb_content";
            this.lb_content.Size = new System.Drawing.Size(65, 12);
            this.lb_content.TabIndex = 6;
            this.lb_content.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "文件路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "服务器信息：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 285);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_content);
            this.Controls.Add(this.webbrowser);
            this.Controls.Add(this.btn_matching);
            this.Controls.Add(this.lb_path);
            this.Controls.Add(this.btn_path);
            this.Name = "Form1";
            this.Text = "自动添加IP工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.Label lb_path;
        private System.Windows.Forms.Button btn_matching;
        private System.Windows.Forms.WebBrowser webbrowser;
        private System.Windows.Forms.Label lb_content;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


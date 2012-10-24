namespace OMine
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
            this.tbRow = new System.Windows.Forms.TextBox();
            this.tbCol = new System.Windows.Forms.TextBox();
            this.tbMineCount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tbRow
            // 
            this.tbRow.Location = new System.Drawing.Point(21, 8);
            this.tbRow.Name = "tbRow";
            this.tbRow.Size = new System.Drawing.Size(100, 21);
            this.tbRow.TabIndex = 0;
            // 
            // tbCol
            // 
            this.tbCol.Location = new System.Drawing.Point(127, 8);
            this.tbCol.Name = "tbCol";
            this.tbCol.Size = new System.Drawing.Size(100, 21);
            this.tbCol.TabIndex = 0;
            // 
            // tbMineCount
            // 
            this.tbMineCount.Location = new System.Drawing.Point(233, 8);
            this.tbMineCount.Name = "tbMineCount";
            this.tbMineCount.Size = new System.Drawing.Size(100, 21);
            this.tbMineCount.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(21, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 214);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbMineCount);
            this.Controls.Add(this.tbCol);
            this.Controls.Add(this.tbRow);
            this.Name = "Form1";
            this.Text = "扫雷";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRow;
        private System.Windows.Forms.TextBox tbCol;
        private System.Windows.Forms.TextBox tbMineCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}


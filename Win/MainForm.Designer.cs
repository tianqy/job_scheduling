namespace Win
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
            this.txt_instructions = new System.Windows.Forms.TextBox();
            this.txt_block = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_Algo = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_instructions
            // 
            this.txt_instructions.Font = new System.Drawing.Font("楷体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_instructions.Location = new System.Drawing.Point(153, 104);
            this.txt_instructions.Margin = new System.Windows.Forms.Padding(4);
            this.txt_instructions.Name = "txt_instructions";
            this.txt_instructions.Size = new System.Drawing.Size(86, 27);
            this.txt_instructions.TabIndex = 0;
            this.txt_instructions.TextChanged += new System.EventHandler(this.txt_instructions_TextChanged);
            // 
            // txt_block
            // 
            this.txt_block.Font = new System.Drawing.Font("楷体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_block.Location = new System.Drawing.Point(495, 104);
            this.txt_block.Margin = new System.Windows.Forms.Padding(4);
            this.txt_block.Name = "txt_block";
            this.txt_block.Size = new System.Drawing.Size(89, 27);
            this.txt_block.TabIndex = 1;
            this.txt_block.TextChanged += new System.EventHandler(this.txt_block_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.Location = new System.Drawing.Point(74, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "指令数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.Location = new System.Drawing.Point(416, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "物理块:";
            // 
            // cbb_Algo
            // 
            this.cbb_Algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Algo.Font = new System.Drawing.Font("宋体", 12F);
            this.cbb_Algo.FormattingEnabled = true;
            this.cbb_Algo.Items.AddRange(new object[] {
            "FIFO算法",
            "LRU算法",
            "LFU算法",
            "NUR算法"});
            this.cbb_Algo.Location = new System.Drawing.Point(340, 191);
            this.cbb_Algo.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_Algo.Name = "cbb_Algo";
            this.cbb_Algo.Size = new System.Drawing.Size(160, 24);
            this.cbb_Algo.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 13F);
            this.btnStart.Location = new System.Drawing.Point(295, 259);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 31);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "模拟";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F);
            this.label3.Location = new System.Drawing.Point(181, 193);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "选择替换算法：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 16F);
            this.label4.Location = new System.Drawing.Point(261, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "存储调度模拟";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 359);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbb_Algo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_block);
            this.Controls.Add(this.txt_instructions);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "存储调度";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_instructions;
        private System.Windows.Forms.TextBox txt_block;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_Algo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
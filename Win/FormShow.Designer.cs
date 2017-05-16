namespace Win
{
    partial class FormShow
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
            this.lblSort = new System.Windows.Forms.Label();
            this.dgvExchange = new System.Windows.Forms.DataGridView();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchange)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("宋体", 13F);
            this.lblSort.Location = new System.Drawing.Point(12, 9);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(98, 18);
            this.lblSort.TabIndex = 0;
            this.lblSort.Text = "指令序列：";
            // 
            // dgvExchange
            // 
            this.dgvExchange.AllowUserToAddRows = false;
            this.dgvExchange.AllowUserToDeleteRows = false;
            this.dgvExchange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExchange.Location = new System.Drawing.Point(12, 210);
            this.dgvExchange.Name = "dgvExchange";
            this.dgvExchange.ReadOnly = true;
            this.dgvExchange.RowTemplate.Height = 23;
            this.dgvExchange.Size = new System.Drawing.Size(780, 157);
            this.dgvExchange.TabIndex = 2;
            // 
            // txtSort
            // 
            this.txtSort.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSort.Location = new System.Drawing.Point(12, 30);
            this.txtSort.Multiline = true;
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(780, 174);
            this.txtSort.TabIndex = 3;
            // 
            // txtSummary
            // 
            this.txtSummary.Font = new System.Drawing.Font("宋体", 13F);
            this.txtSummary.Location = new System.Drawing.Point(12, 398);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(268, 91);
            this.txtSummary.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.Location = new System.Drawing.Point(12, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "总结与评价：";
            // 
            // FormShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 501);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.dgvExchange);
            this.Controls.Add(this.lblSort);
            this.Name = "FormShow";
            this.Text = "FormShow";
            this.Load += new System.EventHandler(this.FormShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.DataGridView dgvExchange;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label label1;
    }
}
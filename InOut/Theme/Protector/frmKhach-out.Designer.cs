namespace Theme.Protector
{
    partial class frmKhach_out
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhach_out));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lbIdcard = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 40);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kiểm tra khách ra";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.SteelBlue;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(113, 84);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(124, 25);
            this.txtAddress.TabIndex = 25;
            // 
            // lbIdcard
            // 
            this.lbIdcard.AutoSize = true;
            this.lbIdcard.BackColor = System.Drawing.Color.Transparent;
            this.lbIdcard.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdcard.ForeColor = System.Drawing.Color.White;
            this.lbIdcard.Location = new System.Drawing.Point(23, 84);
            this.lbIdcard.Name = "lbIdcard";
            this.lbIdcard.Size = new System.Drawing.Size(73, 23);
            this.lbIdcard.TabIndex = 26;
            this.lbIdcard.Text = "Mã Thẻ";
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnIn.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnIn.FlatAppearance.BorderSize = 0;
            this.btnIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(66, 141);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(180, 73);
            this.btnIn.TabIndex = 27;
            this.btnIn.Text = "Ra";
            this.btnIn.UseVisualStyleBackColor = false;
            // 
            // frmKhach_out
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(317, 226);
            this.ControlBox = false;
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lbIdcard);
            this.Controls.Add(this.label1);
            this.Name = "frmKhach_out";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lbIdcard;
        private System.Windows.Forms.Button btnIn;
    }
}
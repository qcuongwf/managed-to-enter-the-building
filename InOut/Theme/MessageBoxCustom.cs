using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MessageBoxCustom
{
    public partial class MessageBoxCustom : Form
    {
        public MessageBoxCustom()
        {
            InitializeComponent();
        }

        static MessageBoxCustom frm; static DialogResult result = DialogResult.No;

        /// <summary>
        /// setMessage method is used to display message
        /// on form and it's height adjust automatically.
        /// I am displaying message in a Label control.
        /// </summary>
        /// <param name="messageText">Message which needs to be displayed to user.</param>
        //private void setMessage(string messageText)
        //{
        //    int number = Math.Abs(messageText.Length / 30);
        //    if (number != 0)
        //        this.lblText.Height = number * 25;
        //   this.lblText.Text = messageText;
        //}

        /// <summary>
        /// Show method is overloaded which is used to display message
        /// and this is static method so that we don't need to create
        /// object of this class to call this method.
        /// </summary>
        /// <param name="messageText"></param>
        internal static DialogResult Show(string text)
        {
            frm = new MessageBoxCustom();
            frm.Text = "Thông báo";
            frm.lblText.Text = text;
            frm.addIconImage(enumMessageIcon.Information);
            frm.addButton(enumMessageButton.OK);
            frm.ShowDialog();
            return result;
        }

        internal static DialogResult Show(string text, string caption, enumMessageIcon icon, enumMessageButton button)
        {
            frm = new MessageBoxCustom();
            frm.Text = caption;
            frm.lblText.Text = text;
            frm.addButton(button);
            frm.addIconImage(icon);
            frm.ShowDialog();
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }

        #region constant defiend in form of enumration which is used in showMessage class.
        internal enum enumMessageIcon
        {
            Error,
            Warning,
            Information,
            Question,
        }

        internal enum enumMessageButton
        {
            OK,
            YesNo,
            YesNoCancel,
            OKCancel
        }
        #endregion

        private void addIconImage(enumMessageIcon MessageIcon)
        {
            switch (MessageIcon)
            {
                case enumMessageIcon.Error:
                    pictureBox1.Image = imageList1.Images["Error"];  //Error is key name in imagelist control which uniqly identified images in ImageList control.
                    break;
                case enumMessageIcon.Information:
                    pictureBox1.Image = imageList1.Images["Information"];
                    break;
                case enumMessageIcon.Question:
                    pictureBox1.Image = imageList1.Images["Question"];
                    break;
                case enumMessageIcon.Warning:
                    pictureBox1.Image = imageList1.Images["Warning"];
                    break;
            }
        }

        // <summary>
        /// This method is used to add button on message box.
        /// </summary>
        /// <param name="MessageButton">MessageButton is type of enumMessageButton
        /// through which I get type of button which needs to be displayed.</param>
        private void addButton(enumMessageButton MessageButton)
        {
            switch (MessageButton)
            {
                case enumMessageButton.OK:
                    {
                        //If type of enumButton is OK then we add OK button only.
                        Button btnOk = new Button();  //Create object of Button.
                        btnOk.Text = "OK";  //Here we set text of Button.
                        btnOk.DialogResult = DialogResult.OK;  //Set DialogResult property of button.

                        btnOk.FlatStyle = FlatStyle.Popup;  //Set flat appearence of button.
                        btnOk.FlatAppearance.BorderSize = 0;
                        btnOk.BackColor = System.Drawing.Color.CornflowerBlue;
                        btnOk.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
                        btnOk.FlatAppearance.BorderSize = 0;
                        btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                        btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnOk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnOk.ForeColor = System.Drawing.Color.White;
                        btnOk.SetBounds(frm.ClientSize.Width / 2 - 75 / 2, frm.ClientSize.Height - (25 + 10), 75, 25);  // Set bounds of button. x,y,witdh, height
                        frm.Controls.Add(btnOk);  //Finally Add button control on panel.
                    }
                    break;
                case enumMessageButton.OKCancel:
                    {
                        Button btnOk = new Button();
                        btnOk.Text = "OK";
                        btnOk.DialogResult = DialogResult.OK;
                        btnOk.FlatStyle = FlatStyle.Popup;
                        btnOk.BackColor = System.Drawing.Color.CornflowerBlue;
                        btnOk.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
                        btnOk.FlatAppearance.BorderSize = 0;
                        btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                        btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnOk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnOk.ForeColor = System.Drawing.Color.White;
                        btnOk.SetBounds((frm.ClientSize.Width - 70), 148, 65, 25);
                        frm.Controls.Add(btnOk);


                        Button btnCancel = new Button();
                        btnCancel.Text = "Hủy bỏ";
                        btnCancel.DialogResult = DialogResult.Cancel;
                        btnCancel.FlatStyle = FlatStyle.Popup;
                        btnCancel.BackColor = System.Drawing.Color.CornflowerBlue;
                        btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
                        btnCancel.FlatAppearance.BorderSize = 0;
                        btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnCancel.ForeColor = System.Drawing.Color.White;
                        btnCancel.SetBounds((frm.ClientSize.Width - (btnOk.ClientSize.Width + 5 + 80)), 148, 75, 25);
                        frm.Controls.Add(btnCancel);

                    }
                    break;
                case enumMessageButton.YesNo:
                    {
                        Button btnYes = new Button();
                        btnYes.Text = "Có";
                        btnYes.DialogResult = DialogResult.Yes;
                        btnYes.FlatStyle = FlatStyle.Popup;
                        btnYes.FlatAppearance.BorderSize = 0;
                        btnYes.BackColor = System.Drawing.Color.CornflowerBlue;
                        btnYes.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
                        btnYes.FlatAppearance.BorderSize = 0;
                        btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                        btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnYes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnYes.ForeColor = System.Drawing.Color.White;
                        btnYes.SetBounds((frm.ClientSize.Width / 2 - 75 - 10), frm.ClientSize.Height - (25 + 10), 75, 25);
                        frm.Controls.Add(btnYes);
                        btnYes.Click += new EventHandler(btnYes_Click);

                        Button btnNo = new Button();
                        btnNo.Text = "Không";
                        btnNo.DialogResult = DialogResult.No;
                        btnNo.FlatStyle = FlatStyle.Popup;
                        btnNo.BackColor = System.Drawing.Color.CornflowerBlue;
                        btnNo.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
                        btnNo.FlatAppearance.BorderSize = 0;
                        btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                        btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnNo.ForeColor = System.Drawing.Color.White;
                        btnNo.SetBounds((frm.ClientSize.Width / 2 + 10), frm.ClientSize.Height - (25 + 10), 75, 25);
                        btnNo.Click += new EventHandler(btnNo_Click);
                        frm.Controls.Add(btnNo);
                    }
                    break;
                case enumMessageButton.YesNoCancel:
                    {
                        Button btnYes = new Button();
                        btnYes.Text = "Có";
                        btnYes.DialogResult = DialogResult.Yes;
                        btnYes.FlatStyle = FlatStyle.Popup;
                        btnYes.FlatAppearance.BorderSize = 0;
                        btnYes.SetBounds((frm.ClientSize.Width - 70), 148, 65, 25);
                        frm.Controls.Add(btnYes);

                        Button btnNo = new Button();
                        btnNo.Text = "Không";
                        btnNo.DialogResult = DialogResult.No;
                        btnNo.FlatStyle = FlatStyle.Popup;
                        btnNo.FlatAppearance.BorderSize = 0;
                        btnNo.SetBounds((frm.ClientSize.Width - (btnYes.ClientSize.Width + 5 + 80)), 148, 75, 25);
                        frm.Controls.Add(btnNo);

                        Button btnCancel = new Button();
                        btnCancel.Text = "Hủy bỏ";
                        btnCancel.DialogResult = DialogResult.Cancel;
                        btnCancel.FlatStyle = FlatStyle.Popup;
                        btnCancel.FlatAppearance.BorderSize = 0;
                        btnCancel.SetBounds((frm.ClientSize.Width - (btnCancel.ClientSize.Width + btnNo.ClientSize.Width + 10 + 80)), 148, 75, 25);
                        frm.Controls.Add(btnCancel);
                    }
                    break;
            }
        }

        void btnNo_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
        }

        void btnYes_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
        }
    }

}

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
        static public DialogResult Show(string text, string caption, string OK, string Cancel, string icon)
        {
            frm = new MessageBoxCustom();
            frm.Text = caption;
            frm.lblText.Text = text;
            frm.button1.Text = OK;
            frm.button2.Text = Cancel;
            frm.pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\" + "msgimg" + "\\" + icon);
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
        
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Process;

namespace Theme
{
    public partial class frmRecoveredCard : Form
    {
        public frmRecoveredCard()
        {
            InitializeComponent();
        }

        void GetData(int node)
        {
            ConnectSql connect = new ConnectSql();
            if (node == 1)
            {
                DataTable dt = connect.getDataTable("SELECT USERS_ID,USERS_NAME,USERS_IDENTITY, USERS_ADDRESS,USERS_PHONE, USERS_EMAIL from USERS where USERS_ID='" + frmFind.id_users+"'");
                DataRow dtrow = dt.Rows[0];
                txtUser.Text = frmFind.id_users;
                txtAddress.Text = dtrow[3].ToString();
            }
            else
            {
                DataTable dt = connect.getDataTable("SELECT ACCOUNT_ID,ACCOUNT_USERS_ID,ACCOUNT_CARD_ID,ACCOUNT_PASSWORD FROM ACCOUNTS WHERE ACCOUNT_USERS_ID='" + frmFind.id_users + "'");
                dataGridView1.DataSource = dt;
            }

        }

        private void frmRecoveredCard_Load(object sender, EventArgs e)
        {
            GetData(1);
            GetData(2);
            txtIDCard.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri=e.RowIndex;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtIDCard.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cards card = new Cards(txtIDCard.Text, "CSD");
            card.Update();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Process
{
    public class Accounts
    {
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _userID;

        public string userID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private string _cardID;

        public string cardID
        {
            get { return _cardID; }
            set { _cardID = value; }
        }
        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Accounts() { }
        public Accounts(string pID, string pCardID)
        {
            id = pID;
            cardID = pCardID;
        }
        public Accounts(string pID, string pUserID, string pCardID, string pPassword) {
            id = pID;
            userID = pUserID;
            cardID = pCardID;
            password = pPassword;
        }
        ConnectSql connect;
        void Command()
        {
             connect= new ConnectSql();
            SqlCommand cmd = new SqlCommand("STORE_ACCOUNTS", connect.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Char).Value = userID;
            cmd.Parameters.Add("@CARD_ID", SqlDbType.Char).Value = cardID;
            cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = password;
            cmd.ExecuteNonQuery();
        }
        public void Add()
        {
            Command();
        }
        //Cập nhật lại số thẻ cho account
        public void Update()
        {
            connect = new ConnectSql();
            SqlCommand cmd = new SqlCommand("STORE_ACCOUNTS_UPDATE", connect.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@CARD_ID", SqlDbType.Char).Value = cardID;
            cmd.ExecuteNonQuery();
        }
    }
}

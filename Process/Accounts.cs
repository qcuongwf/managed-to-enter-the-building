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

        public Accounts(string pID, string pUserID, string pCardID, string pPassword) {
            id = pID;
            userID = pUserID;
            cardID = pCardID;
            password = pPassword;
        }

        ConnectSql myConnect;

        void Command()
        {
            myConnect = new ConnectSql();
            SqlCommand cmd = new SqlCommand("STORE_ACCOUNTS", myConnect.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Char).Value = userID;
            cmd.Parameters.Add("@CARD_ID", SqlDbType.Char).Value = cardID;
            cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = password==null?(string)(null):password;
            cmd.ExecuteNonQuery();
        }

        public void Add()
        {
            Command();
        }

        public void UpdateIDCard(string accountID, string CardID)
       {
            myConnect = new ConnectSql();
            string stringUpdate="update ACCOUNTS set ACCOUNT_CARD_ID=@CardID where ACCOUNT_ID=@AccountID";
            myConnect.OpenConnection();
            SqlCommand myCommand = new SqlCommand(stringUpdate, myConnect.getConnection);
            myCommand.Parameters.Add("@CardID", SqlDbType.Char).Value = CardID;
            myCommand.Parameters.Add("@AccountID", SqlDbType.Char).Value = accountID;
            myCommand.ExecuteNonQuery();
            myConnect.CloseConnection();
       }
        public string GetAccountID(string card)
        {
            myConnect = new ConnectSql();
            string a = "";
            string stringCommand = "SELECT ACCOUNT_USERS_ID FROM ACCOUNTS WHERE ACCOUNT_CARD_ID=@cardID";
            SqlCommand command = new SqlCommand(stringCommand, myConnect.getConnection);
            command.Parameters.Add("@cardID", SqlDbType.Char).Value = card;
            SqlDataReader sdr = command.ExecuteReader();
            myConnect.OpenConnection();
            while (sdr.Read())
                a += sdr[0].ToString();
            myConnect.CloseConnection();
            return a;
        }
    }
}

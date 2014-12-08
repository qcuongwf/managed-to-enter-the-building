using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Process
{
    public class Transactions
    {
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _accountID;

        public string accountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }
        private string _cardID;

        public string cardID
        {
            get { return _cardID; }
            set { _cardID = value; }
        }
        private DateTime _Time;

        public DateTime time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Transactions() { }
        public Transactions(string pID, string pAccountId, string pCardId, string pType, string pDescription)
        {
            id = pID;
            accountID = pAccountId;
            cardID = pCardId;
            time = DateTime.Now;
            type = pType;
        }
        public bool Insert()
        {
            ConnectSql myConnect=new ConnectSql();
            string stringSQL="INSERT INTO TRANSACTIONS(TRANS_ACCOUNT_ID,TRANS_CARD_ID,TRANS_TIME,TRANS_TYPE) VALUES(@accountID, @cardId, @time, @type)";
            myConnect.OpenConnection();
            SqlCommand command=new SqlCommand(stringSQL,myConnect.getConnection);
            command.Parameters.Add("@accountID", SqlDbType.Char).Value=accountID;
            command.Parameters.Add("@cardId",SqlDbType.Char).Value=cardID;
            command.Parameters.Add("@time",SqlDbType.DateTime).Value=time.ToString("yyyy-MM-dd HH:mm:ss");
            command.Parameters.Add("@type",SqlDbType.Char).Value=type;
            int i=command.ExecuteNonQuery();
            myConnect.CloseConnection();
            return i==0?false:true;
        }
    }
}

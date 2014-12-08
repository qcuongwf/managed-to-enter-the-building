using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Process
{
    public class Cards
    {
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _status;

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _desription;

        public string desription
        {
            get { return _desription; }
            set { _desription = value; }
        }
        public Cards() { }
        public Cards(string pID, string pStatus)
        {
            id = pID;
            status = pStatus;
        }
        public Cards(string pID, string pType, string pStatus)
        {
            id = pID;
            type = pType;
            status = pStatus;
        }
        ConnectSql myConnect;
        void Command(int node) //node bằng 1 thực hiện việc chèn thẻ vào CSDL node bằng 2 thực hiện việc cập trạng thái thẻ
        {
            myConnect = new ConnectSql();
            if(node==1)
            {
                SqlCommand cmd = new SqlCommand("STORE_CARD_INSERT", myConnect.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
                cmd.Parameters.Add("@TYPE", SqlDbType.Char).Value = type;
                cmd.Parameters.Add("@STATUS", SqlDbType.Char).Value = status;
                cmd.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar).Value = "";
                cmd.ExecuteNonQuery();
            }
            else if (node == 2)
            {
                SqlCommand cmd = new SqlCommand("STORE_CARD_UPDATE", myConnect.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
                cmd.Parameters.Add("@STATUS", SqlDbType.Char).Value = status;
                cmd.ExecuteNonQuery();
            }
            
            
        }
        //Chuyển đổi trạng thái thẻ
        public void ImportCard()
        {
            Command(1);
        }
        public void Update()
        {
            Command(2);
        }
        public DataTable LoadStatus()
        {
            myConnect = new ConnectSql();
            return myConnect.getDataTable("select CARD_ID as ID, CARD_TYPE as TYPE, CARD_STATUS as STATUS, CARD_DESCRIPTION as DESCRIPTION from CARDS");

        }
        public string CardTatus(string idCard)
        {
            myConnect = new ConnectSql();
            string a = "";
            string stringCommand = "SELECT LTRIM(RTRIM(CARD_STATUS)) FROM CARDS WHERE CARD_ID=@ID";
            SqlCommand command = new SqlCommand(stringCommand, myConnect.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Char).Value = idCard;
            a = (string)command.ExecuteScalar();
            if (a == null) a = "";
            return a;
        }

        public string GetCardID(string idAccount)
        {
            myConnect = new ConnectSql();
            string a = "";
            string stringCommand = "select TOP 1(ACCOUNT_CARD_ID) from ACCOUNTS, CARDS where ACCOUNT_CARD_ID=@ID"+
                " AND CARDS.CARD_STATUS='DSD' AND ACCOUNT_CARD_ID=CARD_ID";
            SqlCommand command = new SqlCommand(stringCommand, myConnect.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Char).Value = idAccount;
            a = (string)command.ExecuteScalar();
            if (a == null) a = "";
            return a;
        }

        public bool isata(string idcard)
        {
            myConnect = new ConnectSql();
            bool request = true;
            int count;
            string stringCommand = "select count(card_id) from CARDS where CARD_ID=@ID";
            SqlCommand command = new SqlCommand(stringCommand, myConnect.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Char).Value = idcard;
            count= (int)command.ExecuteScalar();
            if (count == 0) request = false;
            else request = true;
            return request;
        }
    }
}

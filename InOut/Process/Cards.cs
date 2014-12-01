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
        void Command(int node) //node bằng 1 thực hiện việc chèn thẻ vào CSDL node bằng 2 thực hiện việc cập trạng thái thẻ
        {
            ConnectSql connect = new ConnectSql();
            if(node==1)
            {
                SqlCommand cmd = new SqlCommand("STORE_CARD_INSERT", connect.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
                cmd.Parameters.Add("@TYPE", SqlDbType.Char).Value = type;
                cmd.Parameters.Add("@STATUS", SqlDbType.Char).Value = status;
                cmd.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar).Value = "";
                cmd.ExecuteNonQuery();
            }
            else if (node == 2)
            {
                SqlCommand cmd = new SqlCommand("STORE_CARD_UPDATE", connect.getConnection);
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
    }
}

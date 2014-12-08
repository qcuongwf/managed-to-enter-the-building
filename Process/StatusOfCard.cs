using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Process
{
    public class StatusOfCard
    {
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public StatusOfCard() { }
        public StatusOfCard(string pID, string pName) {
            id = pID;
            name = pName;
        }
        void Command(int node)
        {
            ConnectSql connect = new ConnectSql();
            SqlCommand cmd = new SqlCommand("STORE_STATUS", connect.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NODE", SqlDbType.Int).Value = node;
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = name;
            cmd.ExecuteNonQuery();
        }
        public DataTable getDataTableStatusCard()
        {
            ConnectSql connect=new ConnectSql();
            return connect.getDataTable("SELECT CARD_STATUS_ID,CARD_STATUS_NAME from CARD_STATUS");
        }
        public void Add()
        {
            Command(1);
        }
    }
}

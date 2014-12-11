using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Model
{
    public class TypeOfCard
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
        public TypeOfCard() { }
        public TypeOfCard(string pID, string pName)
        {
            id = pID;
            name = pName;
        }
        void Command(int node)
        {
            ConnectSql connect = new ConnectSql();
            SqlCommand cmd = new SqlCommand("STORE_CARD_TYPE", connect.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NODE", SqlDbType.Int).Value = node;
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = name;
            cmd.ExecuteNonQuery();
        }
        public void Add()
        {
            Command(1);
        }
        public DataTable LoadType()
        {
            ConnectSql connect = new ConnectSql();
            return connect.getDataTable("select CARD_TYPE_ID,CARD_TYPE_NAME from CARD_TYPES");

        }
    }
}

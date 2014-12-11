using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Model
{
    public class TypeOfUser
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
        public TypeOfUser() { }
        public TypeOfUser(string pID, string pName) {
            id = pID;
            name = pName;
        }
        void Command()
        {
            ConnectSql connect = new ConnectSql();
            SqlCommand cmd = new SqlCommand("STORE_USER_TYPE", connect.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = name;
            cmd.ExecuteNonQuery();
        }
        void Add()
        {
            Command();
        }
    }
}

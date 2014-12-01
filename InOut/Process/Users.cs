using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Process
{
    public class Users
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
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _indentity;

        public string indentity
        {
            get { return _indentity; }
            set { _indentity = value; }
        }
        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _phone;

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        public Users() { }
        public Users(string pID, string pType, string pName, string pIndentity, string pAddress, string pPhone, string pEmail)
        {
            id = pID;
            name = pName;
            type = pType;
            indentity = pIndentity;
            address = pAddress;
            phone = pPhone;
            email = pEmail;
        }
        void cmd(int node)
        {
            ConnectSql connect = new ConnectSql();
            SqlCommand cmd = new SqlCommand("STORE_USERS", connect.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@TYPE", SqlDbType.Char).Value = type;
            cmd.Parameters.Add("@IDENTITY", SqlDbType.Char).Value = indentity;
            cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = address;
            cmd.Parameters.Add("@PHONE", SqlDbType.Char).Value = phone;
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = email;
            cmd.ExecuteNonQuery();
        }
        public void AddUser()
        {
            cmd(1);
        }
    }
}

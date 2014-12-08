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

        ConnectSql myConnect;

        public void AddUser()
        {
            myConnect = new ConnectSql();
            string stringInsert="INSERT INTO USERS(USERS_ID, USERS_TYPE, USERS_NAME, USERS_IDENTITY, USERS_ADDRESS, USERS_PHONE, USERS_EMAIL) VALUES(@ID, @TYPE, @NAME, @IDENTITY, @ADDRESS, @PHONE, @EMAIL)";
            myConnect.OpenConnection();
            SqlCommand cmd = new SqlCommand(stringInsert, myConnect.getConnection);
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@TYPE", SqlDbType.Char).Value = type;
            cmd.Parameters.Add("@IDENTITY", SqlDbType.Char).Value = indentity;
            cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = address;
            cmd.Parameters.Add("@PHONE", SqlDbType.Char).Value = phone;
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = email;
            cmd.ExecuteNonQuery();
            myConnect.CloseConnection();
        }

        public void Update()
        {
            myConnect = new ConnectSql();
            string stringUpdate="UPDATE USERS SET USERS_NAME=@NAME,USERS_IDENTITY=@IDENTITY,USERS_PHONE=@PHONE,USERS_ADDRESS=@ADDRESS,USERS_EMAIL=@EMAIL WHERE USERS_ID=@ID";
            myConnect.OpenConnection();
            SqlCommand myCommand = new SqlCommand(stringUpdate, myConnect.getConnection);
            myCommand.Parameters.Add("@NAME",SqlDbType.NVarChar).Value=name;
            myCommand.Parameters.AddWithValue("@IDENTITY", indentity);
            myCommand.Parameters.AddWithValue("@PHONE", phone);
            myCommand.Parameters.AddWithValue("@ADDRESS", address);
            myCommand.Parameters.AddWithValue("@EMAIL", email);
            myCommand.Parameters.AddWithValue("@ID", id);
            myCommand.ExecuteNonQuery();
            myConnect.CloseConnection();

        }
        public DataTable LoadTableUser()
        {
            ConnectSql myConnect=new ConnectSql();
            return myConnect.getDataTable("select USERS_ID,USERS_NAME,USERS_IDENTITY,USERS_ADDRESS,USERS_PHONE,USERS_EMAIL from USERS WHERE USERS_TYPE='NHANVIEN'");
        }
        //hàm load thông tin bằng userid
        public void LoadUserFromID(string idUser)
        {
            ConnectSql myConnect = new ConnectSql();
            DataTable data = myConnect.getDataTable("SELECT USERS_ID,USERS_NAME,USERS_IDENTITY, USERS_ADDRESS,USERS_PHONE, USERS_EMAIL from USERS where USERS_ID='" + idUser + "'");
            DataRow data2 = data.Rows[0];
            id = data2[0].ToString();
            name = data2[1].ToString();
            indentity = data2[2].ToString();
            address = data2[3].ToString();
            phone = data2[4].ToString();
            email = data2[5].ToString();
        }
        //hàm kiểm tra user có tồn tại hay không?
        public bool isExits(string type)
        {
           Controller.CheckError error = new Controller.CheckError();
           if (error.isExists("SELECT COUNT(*) FROM USERS WHERE USERS_ID LIKE '"+type+"%'")) return true;
          else return false;
        }
        public string getLastUserID()
        {
            myConnect = new ConnectSql();
            string stringCommand = "SELECT TOP 1(USERS_ID) FROM USERS WHERE USERS_TYPE='NHANVIEN' ORDER BY USERS_ID DESC";
            SqlCommand cmd = new SqlCommand(stringCommand, myConnect.getConnection);
            string count = (string)cmd.ExecuteScalar();
            return count;
        }
    }
}

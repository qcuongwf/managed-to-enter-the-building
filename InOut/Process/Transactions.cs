using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public Transactions(string pID, string pAccountId, string pCardId, DateTime pTime, string pType, string pDescription)
        {
            id = pID;
            accountID = pAccountId;
            cardID = pCardId;
            time = pTime;
            type = pType;
        }
    }
}

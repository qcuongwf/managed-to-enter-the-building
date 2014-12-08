﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public class Utilities
    {
        public static string NextID(string lastID, string prefixID)
        {
            if (lastID == null) return prefixID + "0000001";
            if (lastID == "") return prefixID + "0000001";
            else
            {
                int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
                int lengthNumerID = lastID.Length - prefixID.Length;
                string zeroNumber = "";
                for (int i = 1; i <= lengthNumerID; i++)
                {
                    if (nextID < Math.Pow(10, i))
                    {
                        for (int j = 1; j <= lengthNumerID - i; i++)
                        {
                            zeroNumber += "0";
                        }
                        return prefixID + zeroNumber + nextID.ToString();
                    }
                }
                return prefixID + nextID;
            }
        }
    }
}

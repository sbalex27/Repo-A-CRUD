using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SalesApp_Alpha_2
{
    class QFunctions
    {
        public static bool IsNumeric(object value)
        {
            string text = value.ToString();
            char[] charArray = text.ToCharArray();
            bool isOk = false;
            foreach (char c in charArray)
            {
                if (char.IsNumber(c) || char.IsPunctuation(c))
                {
                    isOk = true;
                }
                else
                {
                    isOk = false;
                }
            }
            return isOk;
        }

        public static bool IsEmptyText(object value)
        {
            if (value == null) return true;
            string text = value.ToString();
            if (text.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}

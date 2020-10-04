using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterEncoding.Models
{
    class Converter
    {
        public static string StringToBinary2(string data)
        {
            string converted = string.Empty;
            // convert string to byte
            byte[] byteArray = Encoding.ASCII.GetBytes(data);


            for (int i = 0; i < byteArray.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    converted += (byteArray[i] & 0x80) > 0 ? "1" : "0";
                    byteArray[i] <<= 1;
                }
            }

            return converted;
        }
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                //Convert the char to base 2 and pad the output with 0
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
        
    }
}

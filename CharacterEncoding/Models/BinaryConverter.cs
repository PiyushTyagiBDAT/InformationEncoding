﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterEncoding.Models
{
    class BinaryConverter
    {
        int[] positionvalues = { 128, 64, 32, 16, 8, 4, 2, 1 };
        public string ConvertTo(string word)
        {
            string output = "";

            //Iterate over all elements in the array of characters
            for (int i = 0; i < word.Length; i++)
            {
                string binaryoctet = "";

                //Get one letter
                string letter = word.Substring(i, 1);

                //Convert the letter to a char data type
                char charletter = System.Convert.ToChar(letter);

                //Format an output conprised of the combination of all binary bits
                binaryoctet = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                    Bit128(charletter),
                    Bit64(charletter),
                    Bit32(charletter),
                    Bit16(charletter),
                    Bit8(charletter),
                    Bit4(charletter),
                    Bit2(charletter),
                    Bit1(charletter)
                    );

                //Append the binary output to the final output
                output += binaryoctet;
            }

            return (output);
        }
        public string ConvertBinaryToString(string binaryString)
        {
            string output = "";
            for (int i = 0; i < binaryString.Length; i += 8)
            {
                string binaryOctet = binaryString.Substring(i, 8);
                output += ConvertToASCII(binaryOctet);

            }

            return (output);
        }
        public char ConvertToASCII(string binaryvalue)
        {
            string binaryOctet = binaryvalue;
            uint bytevalue = 0;

            for (int c = 0; c < positionvalues.Length; c++)
            {
                string bit = binaryvalue.Substring(c, 1);
                bytevalue += bit == "1" ? (uint)positionvalues[c] : 0;
            }

            return ((char)bytevalue);
        }
        public int Bit128(char letter)
        {
            int bit = 128;


            int binaryoutput = ((int)letter) / bit;
            if (binaryoutput < 1)
            {
                return (0);
            }

            return (1);
        }
        public int Bit64(char letter)
        {
            int bit = 64;

            return (BitValue(PostionalValue(letter, bit)));
        }
        public int Bit32(char letter)
        {
            int bit = 32;

            return (BitValue(PostionalValue(letter, bit)));
        }
        public int Bit16(char letter)
        {
            int bit = 16;

            return (BitValue(PostionalValue(letter, bit)));
        }
        public int Bit8(char letter)
        {
            int bit = 8;

            return (BitValue(PostionalValue(letter, bit)));
        }
        public int Bit4(char letter)
        {
            int bit = 4;

            return (BitValue(PostionalValue(letter, bit)));
        }
        public int Bit2(char letter)
        {
            int bit = 2;

            return (BitValue(PostionalValue(letter, bit)));
        }
        public int Bit1(char letter)
        {
            int bit = 1;

            return (BitValue(PostionalValue(letter, bit)));
        }

        public decimal PostionalValue(char letter, int bit)
        {
            //Get the remainder of ASCII value divided by previous bit value
            decimal modout = ((int)letter) % (bit * 2);

            //Divide the remainder by the current bit value
            decimal binaryoutput = modout / bit;

            return (binaryoutput);
        }

        public int BitValue(decimal value)
        {
            if (value < 1)
            {
                return (0);
            }

            return (1);
        }
    }
}

using CharacterEncoding.Models;
using System;
using System.Buffers.Text;
using System.Linq;
using System.Text;

namespace CharacterEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 };






            Console.WriteLine("Please enter your text");
            var fullName = Console.ReadLine();
            Console.WriteLine("Your entered text is: "+fullName);
           
            BinaryConverter binaryConverter = new BinaryConverter();
            string binaryValue = binaryConverter.ConvertTo(fullName);
            Console.WriteLine($"{fullName} as Binary: {binaryValue}");
            Console.WriteLine("Converting value from Binary to ASCII :");
            Console.WriteLine($"Binary Value:{binaryValue}" +"\n"+
                $"The text converted from Binary to text: {binaryConverter.ConvertBinaryToString(binaryValue)}");
           
            HexadecimalConverter hex = new HexadecimalConverter();
            string StringToHex = hex.ConvertTo(fullName);
            Console.WriteLine($"{fullName} as Hexadecimal Value is : {StringToHex}");
            Console.WriteLine($"{StringToHex} is Hexadecimal for ASCII: {hex.ConveryFromHexToASCII(StringToHex)}");

            string nameBase64Encoded = Models.Base64.StringToBase64(fullName);
            Console.WriteLine("The text converted to the Base64 is :"+nameBase64Encoded);

            string nameBase64Decoded = Models.Base64.Base64ToString(nameBase64Encoded);
            Console.WriteLine($"The Text value of {nameBase64Encoded} is :"+nameBase64Decoded);

            Console.WriteLine("for the conversion of the fullname to bytearray:");
            byte[] fullnamebytes = Encoding.ASCII.GetBytes(fullName);
            foreach (byte b in fullnamebytes)
            {
                Console.WriteLine("Converted text in the byte[]: " + b);

            }


            Console.WriteLine("Please Enter the Text That need to be DeepEncrypt ");

            string unicodeString =  Console.ReadLine();

            int encryptionDepth = 10;
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString()));
            Encrypter encrypter = new Encrypter(unicodeString, cipher, encryptionDepth);

         
            string nameEncryptWithCipher = Encrypter.EncryptWithCipher(unicodeString, cipher);
            Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

            string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

        }
    }
}

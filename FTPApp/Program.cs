using FTPApp.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using FtpApp.Models.Utility;

namespace FTPApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // byte[] filetobyte = FtpApp.Models.Utility.FTP.GetStreamBytes("D:\\20200206_131843");
           // bool exists = FtpApp.Models.Utility.FTP.FileExists(Constants.FTP.BaseUrl + "/200463142 Piyush Tyagi/myimage.jpg");

            //Does the file exist?
           // if (exists == true)
            {
                Console.WriteLine("File exists");
            }
           // else
            {
                Console.WriteLine("File does not exist");
            }

            List<string> directories = FtpApp.Models.Utility.FTP.GetDirectory(Constants.FTP.BaseUrl);

            foreach (var directory in directories)
            {
                try
                {
                    Student student = new Student();
                    student.FromDirectory(directory);
                    Console.WriteLine(Constants.FTP.BaseUrl + "/" +directory);
                    //Path to the remote file you will download
                    string remoteDownloadFilePath = "/200463142 Piyush Tyagi/info.csv";
                    string remotedown = "/200463142 Piyush Tyagi/myimage.jpg";
                    //Path to a valid folder and the new file to be saved
                    string localDownloadFileDestination = @"C:\Users\ptpiy\source\repos\FTPApp\Content\Data\info2.csv";
                    string saveImage = @"C:\Users\ptpiy\source\repos\FTPApp\Content\Image\myimage.jpg";
                    Console.WriteLine(FtpApp.Models.Utility.FTP.DownloadFile(Constants.FTP.BaseUrl + remotedown, saveImage));
                    Console.WriteLine(FtpApp.Models.Utility.FTP.DownloadFile(Constants.FTP.BaseUrl + remoteDownloadFilePath, localDownloadFileDestination));
                    
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

                // conveting image to base64 and saving it in file

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                //Build a image file path from the original image path
                FileInfo fileinfo = new FileInfo("C:\\Users\\ptpiy\\source\\repos\\FTPApp\\Content\\Image\\myimage.jpg");

                //Provide an Image from a file on your Desktop
                Image image = Image.FromFile(fileinfo.FullName);

                //Convert Image to Base64 encoded text
                string base64image = FTP.ImageToBase64(image, ImageFormat.Jpeg);
                


            }


        }
    }
}

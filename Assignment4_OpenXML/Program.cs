using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Assignment4_OpenXML.Models;

namespace Assignment4_OpenXML
{
    class Program
    {
        static void Main(string[] args)

        {
            List<string> directories = Models.Utilities.FTP.GetDirectory(Constants.BaseUrl);
            string url = "ftp://waws-prod-dm1-127.ftp.azurewebsites.windows.net/bdat1001-10983";

            //Image download
             string downloaded_image = @"E:\Program_DOCs\download.jpeg";
            Models.Utilities.FTP.DownloadFile(url + "/200463142 Piyush Tyagi/myimage.jpg", downloaded_image);

            //Creating the Word Doument

            string filepath_doc = @"E:\Program_DOCs\OpenXml_DOC.docx";
            Models.word.Word(filepath_doc);
            


            //Creating the Excel file
            string file_Excel = @"E:\Program_DOCs\OpenXml_Excel.xlsx";
            Models.Excel.CreateSpreadsheetWorkbook(file_Excel);


            //Creating the text in Excel

            Models.Excel.InsertText(file_Excel, "Hello my name is Piyush Tyagi");
            Models.Excel.InsertText(file_Excel, "I was supposed to add Column but could not add them ");
            



            //Creating Ppt

            string file_ppt = @"E:\Program_DOCs\OpenXml_PPT.ppt";
            Models.presentation.CreatePresentation(file_ppt);
           
            Models.presentation.AddImage(file_ppt, downloaded_image);
            Models.presentation.InsertNewSlide(file_ppt, 2, "so far so good");


            // Upload to FTP
            string localUploadFilePath = filepath_doc;
            string remoteUploadFileDestination = "/200463142 Piyush Tyagi/info.docx";

            //Doc upload
            Console.WriteLine(upload.UploadFile(localUploadFilePath, url + remoteUploadFileDestination));

            //Excel file upload
            Console.WriteLine(upload.UploadFile(file_Excel, url + "/200463142 Piyush Tyagi/info.xlsx"));

            //PPT File upload
            Console.WriteLine(upload.UploadFile(file_ppt, url + "/200463142 Piyush Tyagi/info.pptx"));
        }
    }
}


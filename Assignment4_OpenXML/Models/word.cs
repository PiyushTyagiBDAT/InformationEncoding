using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DocumentFormat.OpenXml;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace Assignment4_OpenXML.Models
{
    class word
    {
        public static void Word(string filepath)
        {
            List<string> directories = Models.Utilities.FTP.GetDirectory(Constants.BaseUrl);
            string downloaded_image = @"E:\Program_DOCs\download.jpeg";

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
            {

                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.

                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                

                foreach (var directory in directories)
                {
                    try
                    {

                        run.AppendChild(new Text("Hello my name is: " + directory));
                         run.AppendChild(new Paragraph(new Break() { Type = BreakValues.Page }));


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
            



        }
        private string AddGraph(WordprocessingDocument wpd, string filepath)
        {
            ImagePart ip = wpd.MainDocumentPart.AddImagePart(ImagePartType.Jpeg);
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                if (fs.Length == 0) return string.Empty;
                ip.FeedData(fs);
            }

            return wpd.MainDocumentPart.GetIdOfPart(ip);
        }
        private void InsertImage(WordprocessingDocument wpd, OpenXmlElement parent, string filepath)
        {
            string relationId = AddGraph(wpd, filepath);
            if (!string.IsNullOrEmpty(relationId))
            {
                Size size = new Size(800, 600);

                Int64Value width = size.Width * 9525;
                Int64Value height = size.Height * 9525;

                var draw = new Drawing(
                    new DW.Inline(
                        new DW.Extent() { Cx = width, Cy = height },
                        new DW.EffectExtent()
                        {
                            LeftEdge = 0L,
                            TopEdge = 0L,
                            RightEdge = 0L,
                            BottomEdge = 0L
                        },
                        new DW.DocProperties()
                        {
                            Id = (UInt32Value)1U,
                            Name = "Its me"
                        },
                        new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks() { NoChangeAspect = true }),
                        new A.Graphic(
                            new A.GraphicData(
                                new PIC.Picture(
                                    new PIC.NonVisualPictureProperties(
                                        new PIC.NonVisualDrawingProperties()
                                        {
                                            Id = (UInt32Value)0U,
                                            Name = relationId
                                        },
                                        new PIC.NonVisualPictureDrawingProperties()),
                                        new PIC.BlipFill(
                                            new A.Blip(
                                                new A.BlipExtensionList(
                                                    new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" })
                                                )
                                            {
                                                Embed = relationId,
                                                CompressionState =
                                                A.BlipCompressionValues.Print
                                            },
                                                new A.Stretch(
                                                    new A.FillRectangle())),
                                                    new PIC.ShapeProperties(
                                                        new A.Transform2D(
                                                            new A.Offset() { X = 0L, Y = 0L },
                                                            new A.Extents() { Cx = width, Cy = height }),
                                                            new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle })))
                            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                                                            )
                    {
                        DistanceFromTop = (UInt32Value)0U,
                        DistanceFromBottom = (UInt32Value)0U,
                        DistanceFromLeft = (UInt32Value)0U,
                        DistanceFromRight = (UInt32Value)0U,
                        EditId = "50D07946"
                    });

                parent.Append(draw);
            }
        }





    }
}


        
    


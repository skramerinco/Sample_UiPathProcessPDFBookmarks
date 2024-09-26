using Sample_ProcessPDF.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Data;
using UiPath.CodedWorkflows;
using UiPath.Core;
using UiPath.Core.Activities.Storage;
using UiPath.Orchestrator.Client.Models;
using UiPath.Testing;
using UiPath.Testing.Activities.TestData;
using UiPath.Testing.Activities.TestDataQueues.Enums;
using UiPath.Testing.Enums;
using UiPath.UIAutomationNext.API.Contracts;
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;
using System.IO;
using iTextSharp.text.pdf;
using static iTextSharp.text.pdf.PdfDocument;

namespace Sample_ProcessPDF{
    public class extract_bookmarks : CodedWorkflow
    {
        [Workflow]
        public (int statusCode, string returnValue) Execute(string pdfFilePath)
        {         
            // Input PDF File
            //string pdfFilePath = "C:\\Users\\sean.kramer\\Downloads\\SAMPLE PRJECT Q017-D02217 100% Drawing_2024-03-11.pdf";
            
            // File path where you want to write the text
            string filePath = "bookmarks.txt";
            
            PdfReader reader = new PdfReader(pdfFilePath);
            var list = SimpleBookmark.GetBookmark(reader);
            using (MemoryStream ms = new MemoryStream())
            {
                SimpleBookmark.ExportToXML(list, ms, "ISO8859-1", true);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    // Return the xml output
                     return (0, sr.ReadToEnd());
                }
}

        }
    }
}
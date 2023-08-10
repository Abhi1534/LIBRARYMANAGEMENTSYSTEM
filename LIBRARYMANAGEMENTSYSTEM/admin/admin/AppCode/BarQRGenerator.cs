#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXing;
using System.IO;
using System.Net;
using System.Drawing;
using System.Web;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security;
//using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Security.Permissions;

#endregion Namespaces

namespace BarQRCodeGenerator
{
    public class BarQRGenerator : IBarQRGenerator
    {
        public enum ActionType : uint
        {
            CheckPath = 0,
            CreateFile
        }
        //public string GenerateBarCode(string strBARInput, string strUHID)
        //{
        //    string strBARpath = string.Empty;
        //    string strBarfolder = ConfigurationManager.AppSettings["BARUPLOADFOLDERPATH"].ToString();

        //    try
        //    {
        //        //NewNas na = new NewNas();
        //        var QCwriter = new BarcodeWriter();
        //        QCwriter.Options.Height = 100;
        //        QCwriter.Options.Width = 200;
        //        QCwriter.Format = BarcodeFormat.CODE_128;
        //        //QCwriter.Options.PureBarcode = true;
        //        var result = QCwriter.Write(strBARInput);
        //        strBARpath = strUHID + "_" + "BarCode";

        //        byte[] bytes = null;
        //        var BARCodeBitmap = new Bitmap(result);

        //        string Pathnew = GetUploadFolderPath(strBarfolder);
        //        string imgName = strBARpath + ".jpg";
        //        strBARpath = Pathnew + "\\" + imgName;
        //      // DirectoryInfo pdfPathInfon = Directory.CreateDirectory(Pathnew);
        //        FileInfo pdfPathInfon = na.Impersonate(Pathnew, "CreateFile"); // production
        //        using (MemoryStream memory = new MemoryStream())
        //        {
        //            using (FileStream fs = new FileStream(strBARpath, FileMode.Create, FileAccess.ReadWrite))
        //            {
        //                BARCodeBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
        //                bytes = memory.ToArray();
        //                fs.Write(bytes, 0, bytes.Length);
        //            }
        //        }
        //        BARCodeBitmap.Dispose();
        //        return strBARpath;
        //    }
        //    catch(Exception ex)
        //    {
        //        UtilityLogger.Log(string.Format("GenerateBarCode Method : {0}", ex.Message), "GenerateBarCode");
        //    }
        //    return strBARpath;
        //}
        //public string GenerateQRCode(string strQRInput, string strUHID)
        //{
        //    string strQRpath = string.Empty;
        //    string strQRSubfolder = ConfigurationManager.AppSettings["QRUPLOADFOLDERPATH"].ToString();
        //    NewNas na = new NewNas();
        //    try
        //    {
        //        var QCwriter = new BarcodeWriter();
        //        QCwriter.Options.Height = 120;
        //        QCwriter.Options.Width = 120;
        //        QCwriter.Format = BarcodeFormat.QR_CODE;
        //        //QCwriter.Options.PureBarcode = true;
        //        var result = QCwriter.Write(strQRInput);
        //        strQRpath = strUHID + "_"+ "QRCode";

        //        byte[] bytes = null;
        //        var QRCodeBitmap = new Bitmap(result);

        //        string Pathnew = GetUploadFolderPath(strQRSubfolder);
        //        string imgName = strQRpath + ".jpg";
        //        strQRpath = Pathnew + "\\" + imgName;
        //        DirectoryInfo pdfPathInfon = Directory.CreateDirectory(Pathnew);
        //       // FileInfo pdfPathInfon = na.Impersonate(Pathnew, "CreateFile"); // production

        //        using (MemoryStream memory = new MemoryStream())
        //        {
        //            using (FileStream fs = new FileStream(strQRpath, FileMode.Create, FileAccess.ReadWrite))
        //            {
        //                QRCodeBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
        //                bytes = memory.ToArray();
        //                fs.Write(bytes, 0, bytes.Length);
        //            }
        //        }
        //        QRCodeBitmap.Dispose();
        //        return strQRpath.Substring(38);
        //    }
        //    catch (Exception ex)
        //    {
        //        UtilityLogger.Log(string.Format("GenerateQRCode Method : {0}", ex.Message), "GenerateBarCode");
        //    }
        //    return strQRpath.Substring(33);
        //}
        //public byte[] GetImagefromNAS(string imgPath, int Type)
        //{
        //    //Type 1 for BarCode and 2 for QRCode
        //    NASSaveImage objNAS = new NASSaveImage();
        //    return objNAS.GetImagePath(imgPath, Type);
        //}

        //Change to get image from memory stream

        public byte[] GenerateBarCodeByteArray(string strBARInput, string strUHID)
        {
            string strBARpath = string.Empty;
            byte[] bytes = null;

            try
            {
                //NewNas na = new NewNas();
                var QCwriter = new BarcodeWriter();
                QCwriter.Options.Height = 60;
                QCwriter.Options.Width = 200;
                
                QCwriter.Format = BarcodeFormat.CODE_39;
                QCwriter.Options.PureBarcode = false;
              
                //QCwriter.Options.PureBarcode = true;
                
                var result = QCwriter.Write(strBARInput);
                //strQRpath = strUHID + "_" + "QRCode";
                var BARCodeBitmap = new Bitmap(result);
                
                using (MemoryStream memory = new MemoryStream())
                {                   
                        BARCodeBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                        bytes = memory.ToArray();                                         
                }
                BARCodeBitmap.Dispose();
                return bytes;
            }
            catch (Exception ex)
            {
            }
            return bytes;
        }
        public byte[] GenerateQRCodeByteArray(string strQRInput, string strUHID)
        {
            string strQRpath = string.Empty;
            byte[] bytes = null;

            try
            {
                var QCwriter = new BarcodeWriter();
                QCwriter.Options.Height = 120;
                QCwriter.Options.Width = 120;
                QCwriter.Format = BarcodeFormat.QR_CODE;
                //QCwriter.Options.PureBarcode = true;
                QCwriter.Options.Margin = 0;
                var result = QCwriter.Write(strQRInput);             
                var QRCodeBitmap = new Bitmap(result);
                using (MemoryStream memory = new MemoryStream())
                {
                        QRCodeBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bytes = memory.ToArray();                     
                }
                QRCodeBitmap.Dispose();
                return bytes;
            }
            catch (Exception ex)
            {
            }
            return bytes;
        }


        public string GetUploadFolderPath(string MainModule, string strUHID)
        {
            string folderpath = string.Empty;
            StringBuilder strUploadBuilder = new StringBuilder(MainModule);
            string date = @"\"+ DateTime.Now.Year + "_"+ DateTime.Now.Month.ToString().PadLeft(2, '0') + "_"+ DateTime.Now.Day.ToString().PadLeft(2, '0') + "";
            strUploadBuilder.AppendFormat(date);
            //strUploadBuilder.AppendFormat(@"{0}\{1}\", MainModule, SubModule);
            CreateFolder(strUploadBuilder.ToString());

            return strUploadBuilder.ToString();
        }
        private static void CreateFolder(string path)
        {
            try
            {
                if (!Directory.GetParent(path).Exists)
                {
                    CreateFolder(Directory.GetParent(path).FullName);
                }
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
            }
        }

        //public byte[] GenerateQRCodeByteArray(string strQRInput, string strUHID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
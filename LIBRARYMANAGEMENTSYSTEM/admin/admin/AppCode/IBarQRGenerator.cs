using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarQRCodeGenerator
{
    public interface IBarQRGenerator
    {
        //string GenerateQRCode(string strQRInput, string strUHID);
        byte[] GenerateQRCodeByteArray(string strQRInput, string strUHID);

        //string GenerateBarCode(string strBARInput, string strUHID);
        byte[] GenerateBarCodeByteArray(string strBARInput, string strUHID);
        //byte[] GetImagefromNAS(string imgPath, int Type);
        
    }
}

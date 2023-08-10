<%@ WebHandler Language="C#" Class="CaptchaHandler" %>

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;

public class CaptchaHandler : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext objContext)
    {
        using (Bitmap objBitmap = new Bitmap(150, 40, PixelFormat.Format32bppArgb))
        {
            using (Graphics objGraphics = Graphics.FromImage(objBitmap))
            {
                Rectangle objImageType = new Rectangle(0, 0, 149, 39);
                objGraphics.FillRectangle(Brushes.White, objImageType);

                // Create string to draw.
                Random objRand = new Random();
                int objstartIndex = objRand.Next(1, 5);
                int objLength = objRand.Next(5, 10);
                String objChallanString = Guid.NewGuid().ToString().Replace("-", "0").Substring(objstartIndex, objLength);
                objContext.Session["ChallanCaptcha"] = objChallanString;
                Font objChallanFont = new Font("Verdana", 12, FontStyle.Italic | FontStyle.Strikeout);
                using (SolidBrush drawBrush = new SolidBrush(Color.Red))
                {
                    PointF objChallanPoint = new PointF(15, 10);
                    objGraphics.DrawRectangle(new Pen(Color.Orange, 0), objImageType);
                    objGraphics.DrawString(objChallanString, objChallanFont, drawBrush, objChallanPoint);
                }
                objBitmap.Save(objContext.Response.OutputStream, ImageFormat.Jpeg);
                objContext.Response.ContentType = "image/jpeg";
                objContext.Response.End();
            }
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
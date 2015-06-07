using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Runtime.Serialization.Json;
using HighBridge.Common.Util;

namespace HighBridge.Model
{
    class FaceDate
    {
        //bitmapイメージからFaceDateを解析してstring型のjsonを返すメソッド
        public static string[] GetFaceDate(Bitmap inputBitmap)
        {
            Bitmap resisedBitmap = ResizeImage(inputBitmap, 4000, 4000);

            FileStream fs = new FileStream(@"C:\Users\Onodera\Documents\SuperOSK\HighBridge\Assets\WIN_20150606_191014.jpeg", FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();

            Dictionary<string, object> postParameters = new Dictionary<string, object>();
            postParameters.Add("apikey", "c334784652d3de937402417a8824880f");
            postParameters.Add("mode", "register");
            postParameters.Add("inputFile", data);//MIMEタイプは画像の種類に合わせて指定する。(http://www.iana.org/assignments/media-types/media-types.xhtml)

            // Create request and receive response
            string postURL = "http://eval.api.polestars.jp:8080/webapi/face.do";//TODO アドレスかえる
            string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";//TODO UserAgent変更
            HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(postURL, userAgent, postParameters);

            // Process response
            StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
            string fullResponse = responseReader.ReadToEnd();
            webResponse.Close();

            var json = DynamicJson.Parse(fullResponse);
            string faceId = (json.results.faceRecognition.detectionFaceInfo.registrationFaceInfo.faceId).ToString();
            string imagepath = (json.results.faceRecognition.detectionFaceInfo.registrationFaceInfo.imagePath).ToString();

            return new string[] { faceId, imagepath };
        }

        public static Bitmap ResizeImage(Bitmap image, double dw, double dh)
        {
            double hi;
            double imagew = image.Width;
            double imageh = image.Height;

            if ((dh / dw) <= (imageh / imagew))
            {
                hi = dh / imageh;
            }
            else
            {
                hi = dw / imagew;
            }
            int w = (int)(imagew * hi);
            int h = (int)(imageh * hi);

            Bitmap result = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(result);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, result.Width, result.Height);

            return result;
        }
    }

}

using System;
using System.Drawing;
using System.Net;
using System.Text;

namespace HighBridge.Common.Util
{
    class FaceDate
    {
        //bitmapイメージからFaceDateを解析してstring型のjsonを返すメソッド
        public string GetFaceDate(Bitmap inputBitmap)
        {
            inputBitmap.Save(@"C:\Users\Onodera\Documents\SuperOSK\HighBridge\Assets\"+inputBitmap.ToString(), System.Drawing.Imaging.ImageFormat.Png);
            string filePath = @"C:\Users\Onodera\Documents\SuperOSK\HighBridge\Assets";
            //APIkey
            String param = "?APIKEY=477730556650656f743635456e612e537148425a5470344e766678667735625543696d53366b4d774b462f&mode=register";
            //送信先のURL
            string url = "https://api.apigw.smt.docomo.ne.jp/puxImageRecognition/v1/faceRecognition" + param;

            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/octet-stream");
            //データを送信し、また受信する
            byte[] resData = wc.UploadFile(url, filePath);
            //受信したデータを返す
            return Encoding.UTF8.GetString(resData);
        }

        //送信するファイルのパスからFaceDateを解析してstring型のjsonを返すメソッド
        public string GetFaceDate(string filePath)
        {
            //APIkey
            String param = "?APIKEY=477730556650656f743635456e612e537148425a5470344e766678667735625543696d53366b4d774b462f&mode=register";
            //送信先のURL
            string url = "https://api.apigw.smt.docomo.ne.jp/puxImageRecognition/v1/faceRecognition" + param;

            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/octet-stream");
            //データを送信し、また受信する
            byte[] resData = wc.UploadFile(url, filePath);
            //受信したデータを返す
            return Encoding.UTF8.GetString(resData);
        }
    }
}

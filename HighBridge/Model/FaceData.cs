using System;
using System.Drawing;
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
            //APIkey
            String param = "?apiKey=c334784652d3de937402417a8824880f" + "&mode=register";
            //送信先のURL
            string url = "http://eval.api.polestars.jp:8080/webapi/face.do" + param;

            //文字コード
            System.Text.Encoding enc = Encoding.GetEncoding("utf-8");
            //区切り文字列
            string boundary = System.Environment.TickCount.ToString();

            //WebRequestの作成
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを設定
            req.ContentType = "application/octet-stream; boundary=" + boundary;
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";


            //バイト型配列に変換
            byte[] postData;

            // メモリストリームの生成
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                // Bitmap画像を、bmp形式でストリームに保存
                inputBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                // ストリームのデーターをバイト型配列に変換
                postData = ms.ToArray();

                // ストリームのクローズ
                ms.Close();
            }

            //POST送信するデータの長さを指定
            req.ContentLength = postData.Length;

            //データをPOST送信するためのStreamを取得
            System.IO.Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            //サーバーからの応答を受信するためのWebResponseを取得
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            //応答データを受信するためのStreamを取得
            System.IO.Stream resStream = res.GetResponseStream();
            //受信して表示
            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);

            string result = sr.ReadToEnd();
            //閉じる
            sr.Close();

            var json = DynamicJson.Parse(result);
            string faceId = (json.results.faceRecognition.detectionFaceInfo.registrationFaceInfo.faceId).ToString();
            string imagepath = (json.results.faceRecognition.detectionFaceInfo.registrationFaceInfo.imagePath).ToString();

            return new string[]{faceId,imagepath};
        }
    }
}

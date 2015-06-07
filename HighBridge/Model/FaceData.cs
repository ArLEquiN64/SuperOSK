using System;
using System.Drawing;
using System.Net;
using System.Text;

namespace HighBridge.Model
{
    class FaceDate
    {
        //bitmapイメージからFaceDateを解析してstring型のjsonを返すメソッド
        public static string GetFaceDate(Bitmap inputBitmap)
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

            return result;
        }
    }
}

//    inputBitmap.Save(@"C:\Users\Onodera\Documents\SuperOSK\HighBridge\Assets\"+inputBitmap.ToString(), System.Drawing.Imaging.ImageFormat.Png);

//    string filePath = @"C:\Users\Onodera\Documents\SuperOSK\HighBridge\Assets\WIN_20150606_191014.bmp";

//    //APIkey
//    String param = "?apiKey=c334784652d3de937402417a8824880f" + "&mode=register";
//    //送信先のURL
//    string url = "http://eval.api.polestars.jp:8080/webapi/face.do" + param;

//    //文字コード
//    System.Text.Encoding enc = Encoding.GetEncoding("utf-8");
//    //区切り文字列
//    string boundary = System.Environment.TickCount.ToString();

//    //WebRequestの作成
//    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
//    //メソッドにPOSTを指定
//    req.Method = "POST";
//    //ContentTypeを設定
//    req.ContentType = "application/multipart/form-data; boundary=" + boundary;
//    req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

//    //POST送信するデータを作成
//    string postData = "";
//    postData = "";
//    //バイト型配列に変換
//    byte[] startData = enc.GetBytes(postData);
//    postData = "";
//    byte[] endData = enc.GetBytes(postData);

//    //送信するファイルを開く
//    System.IO.FileStream fs = new System.IO.FileStream(
//        filePath, System.IO.FileMode.Open,
//        System.IO.FileAccess.Read);

//    //POST送信するデータの長さを指定
//    req.ContentLength = startData.Length + endData.Length + fs.Length;

//    //データをPOST送信するためのStreamを取得
//    System.IO.Stream reqStream = req.GetRequestStream();
//    //送信するデータを書き込む
//    reqStream.Write(startData, 0, startData.Length);
//    //ファイルの内容を送信
//    byte[] readData = new byte[0x1000];
//    int readSize = 0;
//    while (true)
//    {
//        readSize = fs.Read(readData, 0, readData.Length);
//        if (readSize == 0)
//            break;
//        reqStream.Write(readData, 0, readSize);
//    }
//    fs.Close();
//    reqStream.Write(endData, 0, endData.Length);
//    reqStream.Close();

//    //サーバーからの応答を受信するためのWebResponseを取得
//    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
//    //応答データを受信するためのStreamを取得
//    System.IO.Stream resStream = res.GetResponseStream();
//    //受信して表示
//    System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
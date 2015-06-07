using System;
using System.Drawing;
using System.Net;
using HighBridge.Common.Util;

namespace HighBridge.Model
{
    static class AccountManager
    {
        static AccountManager()
        {
            MyData=new UserData("","wang");
        }
        public static UserData MyData { get; set; }

        private static string _sessionId;

        public static void AddUser(UserData userdata)
        {
            //文字コードを指定する
            System.Text.Encoding enc =
                System.Text.Encoding.GetEncoding("shift_jis");

            //POST送信する文字列を作成
            string postData =
                "id=" + userdata.FaceId + "&"
                + "name=" + userdata.Name + "&"
                + "mail=azelf.trickroom@gmail.com";

            //バイト型配列に変換
            byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);

            //WebRequestの作成
            System.Net.WebRequest req =
                System.Net.WebRequest.Create("http://VirtualOSK.cloudapp.net/register/");
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = "application/x-www-form-urlencoded";
            //POST送信するデータの長さを指定
            req.ContentLength = postDataBytes.Length;

            //データをPOST送信するためのStreamを取得
            System.IO.Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(postDataBytes, 0, postDataBytes.Length);
            reqStream.Close();

            //サーバーからの応答を受信するためのWebResponseを取得
            System.Net.WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            System.IO.Stream resStream = res.GetResponseStream();
            //受信して表示
            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            Console.WriteLine(sr.ReadToEnd());
            //閉じる
            sr.Close();
        }

		public static void logIn()
		{
			//文字コードを指定する
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");

			//POST送信する文字列を作成
			string postData =
				"id=" + MyData.FaceId;

			//バイト型配列に変換
			byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);

			//WebRequestの作成
			System.Net.WebRequest req =
				System.Net.WebRequest.Create("http://VirtualOSK.cloudapp.net/login");
			//メソッドにPOSTを指定
			req.Method = "GET";
			//ContentTypeを"application/x-www-form-urlencoded"にする
			req.ContentType = "application/x-www-form-urlencoded";
			//POST送信するデータの長さを指定
			req.ContentLength = postDataBytes.Length;

			//データをPOST送信するためのStreamを取得
			System.IO.Stream reqStream = req.GetRequestStream();
			//送信するデータを書き込む
			reqStream.Write(postDataBytes, 0, postDataBytes.Length);
			reqStream.Close();

			//サーバーからの応答を受信するためのWebResponseを取得
			System.Net.WebResponse res = req.GetResponse();
			//応答データを受信するためのStreamを取得
			System.IO.Stream resStream = res.GetResponseStream();
			//受信して表示
			System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
			var str = sr.ReadToEnd();
			//閉じる
			sr.Close();
			_sessionId = str;
		}

		public static UserData GetUserInfo(string faceid)
		{
			//文字コードを指定する
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");

			//POST送信する文字列を作成
			string postData =
				"id=" + MyData.FaceId + "&" +
				"sessionId=" + _sessionId;

			//バイト型配列に変換
			byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);

			//WebRequestの作成
			System.Net.WebRequest req =
				System.Net.WebRequest.Create("http://VirtualOSK.cloudapp.net/users/:" + faceid);
			//メソッドにPOSTを指定
			req.Method = "GET";
			//ContentTypeを"application/x-www-form-urlencoded"にする
			req.ContentType = "application/x-www-form-urlencoded";
			//POST送信するデータの長さを指定
			req.ContentLength = postDataBytes.Length;

			//データをPOST送信するためのStreamを取得
			System.IO.Stream reqStream = req.GetRequestStream();
			//送信するデータを書き込む
			reqStream.Write(postDataBytes, 0, postDataBytes.Length);
			reqStream.Close();

			//サーバーからの応答を受信するためのWebResponseを取得
			System.Net.WebResponse res = req.GetResponse();
			//応答データを受信するためのStreamを取得
			System.IO.Stream resStream = res.GetResponseStream();
			//受信して表示
			System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
			var str = sr.ReadToEnd();
			//閉じる
			sr.Close();
			return MyData;
		}

        public static UserData Identify(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }
    }
}

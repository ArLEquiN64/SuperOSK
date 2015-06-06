using System;
using System.Net;
using System.Text;
using Codeplex.Data;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //送信するファイルのパス
            string filePath = @"C:\Users\Onodera\Pictures\Camera Roll\WIN_20150606_191014.JPG";
            //APIkey
            String apikey="477730556650656f743635456e612e537148425a5470344e766678667735625543696d53366b4d774b462f";
            //送信先のURL
            string url = "https://api.apigw.smt.docomo.ne.jp/puxImageRecognition/v1/faceRecognition" + "?APIKEY=" +apikey+ "&mode=register";


            var obj = new
            {
                APIKEY = apikey,
                imageURL = "http://cdn-ak.f.st-hatena.com/images/fotolife/i/im0man/20150224/20150224022154.jpg",
                mode = "register"
            };
            var formattedString = DynamicJson.Serialize(obj);

            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/octet-stream");

            byte[] data = Encoding.UTF8.GetBytes(formattedString);
            byte[] resData = wc.UploadData(new Uri(url), "POST", data);
            string resText = Encoding.UTF8.GetString(resData);
            Console.WriteLine(resText);

            //System.Net.WebClient wc = new System.Net.WebClient();
            //wc.Headers.Add("Content-Type", "application/octet-stream");
            ////データを送信し、また受信する
            //byte[] resData = wc.UploadFile(url, filePath);
            ////受信したデータを表示する
            //string resText = Encoding.UTF8.GetString(resData);
            //Console.WriteLine(resText);
        }
    }


}

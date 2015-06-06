using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            String param = "?APIKEY=477730556650656f743635456e612e537148425a5470344e766678667735625543696d53366b4d774b462f&mode=register";
            //送信先のURL
            string url = "https://api.apigw.smt.docomo.ne.jp/puxImageRecognition/v1/faceRecognition" + param;

            System.Net.WebClient wc = new System.Net.WebClient();
            wc.Headers.Add("Content-Type", "application/octet-stream");
            //データを送信し、また受信する
            byte[] resData = wc.UploadFile(url, filePath);
            //受信したデータを表示する
            var resText = DynamicJson.Parse(Encoding.UTF8.GetString(resData));

        }
    }
}

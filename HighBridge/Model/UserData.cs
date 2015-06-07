using System.Drawing;

namespace HighBridge.Model
{
    class UserData
    {
        public string FaceId { get; set; }
        public string Name { get; set; }
        public string TwitterId { get; set; }
        public string Comment { get; set; }
        public Bitmap Bitmap { get; set; }

        public UserData(string iD,string name)
        {
            this.FaceId = iD;
            this.Name = name;
            TwitterId = "";
            Comment = "";
        }
    }
}

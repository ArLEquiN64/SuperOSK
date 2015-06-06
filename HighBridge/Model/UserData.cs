namespace HighBridge.Model
{
    class UserData
    {
        public string ID { get; set; }
        public string name { get; set; }

        public UserData(string ID,string name)
        {
            this.ID = ID;
            this.name = name;
        }
    }
}

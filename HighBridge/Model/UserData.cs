using System.Drawing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace HighBridge.Model
{
	[DataContract]
    class UserData
    {
		[DataMember]
		public string faceId { get; set; }
		[DataMember]
		public string name { get; set; }
		[DataMember]
		public string twitterId { get; set; }
		[DataMember]
		public string comment { get; set; }
		[DataMember]
        public string bitmap { get; set; }

    }
}

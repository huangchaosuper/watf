using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WATF.Plugin.HPST
{
    public class HPSTStruct
    {
        public class ReportMessages
        {
            public ReportMessages()
            {
                if (this.Messages == null)
                    this.Messages = new List<Message>();
            }
            [System.Xml.Serialization.XmlElement("ReportMessages", Type = typeof(ReportMessages))]
            public List<Message> Messages { get; set; }
        }
        [Serializable]
        public class Message
        {
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string Actual { get; set; }
            public string Expected { get; set; }
            public string DateTime { get; set; }
        }
    }
}

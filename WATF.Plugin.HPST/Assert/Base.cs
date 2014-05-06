using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace WATF.Plugin.HPST.Assert
{
    public abstract class Base
    {
        internal void AddReport(int errorCode, string errorMessage, object actual = null, object expected = null)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
            string fileName = System.IO.Path.Combine(path,"WATF.xml");
            string data = "";
            List<WATF.Plugin.HPST.HPSTStruct.Message> messages = null;
            using (System.IO.FileStream fileStream = System.IO.File.Open(fileName, FileMode.OpenOrCreate))
            {
                using(StreamReader sr = new StreamReader(fileStream))
                {
                    data = sr.ReadToEnd();
                }
            }
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<WATF.Plugin.HPST.HPSTStruct.Message>), new Type[] { typeof(WATF.Plugin.HPST.HPSTStruct.ReportMessages) });
            if (data.Length > 1)
            {
                using (StreamReader mem2 = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(data)), System.Text.Encoding.UTF8))
                {
                    messages = new List<WATF.Plugin.HPST.HPSTStruct.Message>((List<WATF.Plugin.HPST.HPSTStruct.Message>)mySerializer.Deserialize(mem2));
                }
            }
            else
            {
                messages = new List<WATF.Plugin.HPST.HPSTStruct.Message>();
            }
            WATF.Plugin.HPST.HPSTStruct.Message message = new HPSTStruct.Message();
            message.ErrorCode = errorCode;
            message.ErrorMessage = errorMessage;
            if (actual == null) message.Actual = "Null Value";
            else message.Actual = actual.ToString();
            if (expected == null) message.Expected = "Null Value";
            else message.Expected = expected.ToString();
            message.DateTime = DateTime.Now.ToString();
            messages.Add(message);
            using (System.IO.FileStream fileStream = System.IO.File.Open(fileName, FileMode.OpenOrCreate))
            {
                using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(fileStream, Encoding.UTF8))
                {
                    mySerializer.Serialize(writer, messages);
                    writer.Flush();
                }
            }
        }
    }
}

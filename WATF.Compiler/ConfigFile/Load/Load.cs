using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.ConfigFile.Load
{
    public class Load :  WATF.Compiler.Interface.WATFPathNavigator
    {
        Interface.WATFDictionary<String, String> m_Attributes = null;
        public Load(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {

            this.m_Attributes = new WATF.Compiler.Interface.WATFDictionary<string, string>();
            XPathNavigator copyXPathNavigator = xPathNavigator.CreateNavigator();
            if (copyXPathNavigator.MoveToFirstAttribute())
            {
                if (copyXPathNavigator.Name.Equals(GlobalDefine.Keyword.ConfigFile.Name))
                {
                    this.m_Attributes.Add(GlobalDefine.Keyword.ConfigFile.Name, Name.Value(xPathNavigator));
                }
                else if (copyXPathNavigator.Name.Equals(GlobalDefine.Keyword.ConfigFile.Path))
                {
                    this.m_Attributes.Add(GlobalDefine.Keyword.ConfigFile.Path, Path.Value(xPathNavigator));
                }
                while (copyXPathNavigator.MoveToNextAttribute())
                {
                    if (copyXPathNavigator.Name.Equals(GlobalDefine.Keyword.ConfigFile.Name))
                    {
                        this.m_Attributes.Add(GlobalDefine.Keyword.ConfigFile.Name, Name.Value(xPathNavigator));
                    }
                    else if (copyXPathNavigator.Name.Equals(GlobalDefine.Keyword.ConfigFile.Path))
                    {
                        this.m_Attributes.Add(GlobalDefine.Keyword.ConfigFile.Path, Path.Value(xPathNavigator));
                    }
                }
            }
        }
        public override int Init(string value = "")
        {
            throw new NotImplementedException();
        }

        public override object Run(object value = null)
        {
            return this.m_Attributes[GlobalDefine.Keyword.ConfigFile.Path] + this.m_Attributes[GlobalDefine.Keyword.ConfigFile.Name];
        }

        public override void UnInit(string value = "")
        {
            throw new NotImplementedException();
        }

        //public Dictionary<String, String> Attributes
        //{ 
            
        //}

        public class LoadException : ConfigFile.ConfigFileException
        {
            public LoadException(string message) : base(message) { }
            protected LoadException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
            public LoadException(string message, System.Exception innerException) : base(message, innerException) { }
        }
    }
}

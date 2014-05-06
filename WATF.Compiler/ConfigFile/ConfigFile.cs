using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.ConfigFile
{
    public class ConfigFile : WATF.Compiler.Interface.WATFPathNavigator
    {

        private static ConfigFile m_ConfigFile = null;
        private Interface.WATFDictionary<String, Interface.WATFPathNavigator> m_ConfigFileNodes = null;
        public static ConfigFile GetInstance(XPathNavigator xPathNavigator)
        {
            if (m_ConfigFile == null)
            {
                m_ConfigFile = new ConfigFile(xPathNavigator);
            }
            return m_ConfigFile;
        }
        private ConfigFile(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {
            m_ConfigFileNodes = new Interface.WATFDictionary<string, Interface.WATFPathNavigator>();
            XPathNodeIterator xPathNodeIterator = xPathNavigator.CreateNavigator().SelectChildren(XPathNodeType.Element);
            while (xPathNodeIterator.MoveNext())
            {
                if(xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.ConfigFile.Load))
                {
                    m_ConfigFileNodes.Add(GlobalDefine.Keyword.ConfigFile.Load, new Load.Load(xPathNodeIterator.Current));
                }
            }
        }
        public override int Init(string value = "")
        {
            //throw new NotImplementedException();
            return 0;
        }

        public override object Run(object value = null)
        {
            //exe load xmlnode
            //load executive file
            Interface.WATFDictionary<String, Executive.Executive> ExecutiveNodes = new Interface.WATFDictionary<string, Executive.Executive>();
            foreach (KeyValuePair<String, Interface.WATFPathNavigator> ConfigFileNode in this.m_ConfigFileNodes)
            {
                if (ConfigFileNode.Key.Equals(GlobalDefine.Keyword.ConfigFile.Load))
                {
                    XPathDocument xPathDocument = new XPathDocument((string)((Load.Load)ConfigFileNode.Value).Run());
                    XPathNodeIterator xPathNodeIterator = xPathDocument.CreateNavigator().Select("/" + GlobalDefine.Keyword.Executive.Root);
                    if (xPathNodeIterator.MoveNext())
                    {
                        if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.Executive.Root))
                        {
                            ExecutiveNodes.Add(GlobalDefine.Keyword.Executive.Root, new Executive.Executive(xPathNodeIterator.Current));
                        }
                    }
                }
            }
            return ExecutiveNodes;
        }

        public override void UnInit(string value = "")
        {
            throw new NotImplementedException();
        }

        public class ConfigFileException : Exception.CompilerException
        {
            public ConfigFileException(string message) : base(message) { }
            protected ConfigFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
            public ConfigFileException(string message, System.Exception innerException) : base(message, innerException) { }
        }
    }
}

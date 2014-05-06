using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler
{
    public class App : Interface.IWATFApp
    {
        #region "Constructors, fields"
        private ConfigFile.ConfigFile m_ConfigFile = null;
        private Interface.WATFDictionary<string, Executive.Executive> m_ExeFiles = null;
        private App(string fullfilename)
        {
            XPathDocument xPathDocument = new XPathDocument(fullfilename);
            XPathNodeIterator xPathNodeIterator = xPathDocument.CreateNavigator().Select("/" + GlobalDefine.Keyword.ConfigFile.Root);
            if (xPathNodeIterator.MoveNext())
            {
                if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.ConfigFile.Root))
                {
                    m_ConfigFile = ConfigFile.ConfigFile.GetInstance(xPathNodeIterator.Current);
                }
            }
        }
        private static App m_App = null;
        public static App GetInstance(string fullfilename)
        {
            if (m_App == null)
            {
                m_App = new App(fullfilename);
            }
            return m_App;
        }
        #endregion
        #region "Methods"
        public int Init(string value = "")
        {
            //throw new NotImplementedException();
            return 0;
        }

        public object Run(object value = null)
        {
            this.m_ExeFiles = (Interface.WATFDictionary<string, Executive.Executive>)this.m_ConfigFile.Run();
            foreach (KeyValuePair<String, Executive.Executive> ExecutiveNode in this.m_ExeFiles)
            {
                if (ExecutiveNode.Key.Equals(GlobalDefine.Keyword.Executive.Root))
                {
                    ExecutiveNode.Value.Run();
                }
            }
            return true;
        }

        public void UnInit(string value = "")
        {
            //throw new NotImplementedException();
        }
        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Executive
{
    public class Executive : WATF.Compiler.Interface.WATFPathNavigator
    {
        private Interface.WATFDictionary<String, Interface.WATFPathNavigator> m_ExeChilds = null;
        public Executive(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {
            XPathNodeIterator xPathNodeIterator = xPathNavigator.CreateNavigator().SelectChildren(XPathNodeType.Element);
            m_ExeChilds = new Interface.WATFDictionary<string, Interface.WATFPathNavigator>();
            while (xPathNodeIterator.MoveNext())
            {
                if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.Executive.Import))
                {
                    m_ExeChilds.Add(xPathNodeIterator.Current.LocalName, new Import.Import(xPathNodeIterator.Current));
                }
                else if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.Executive.Test))
                {
                    m_ExeChilds.Add(xPathNodeIterator.Current.LocalName, new Test.Test(xPathNodeIterator.Current));
                }
            }
        }

        public override int Init(string value = "")
        {
            throw new NotImplementedException();
        }

        public override object Run(object value = null)
        {
            //throw new NotImplementedException();
            Interface.WATFContext context = Interface.WATFContext.GetInstance();
            foreach (KeyValuePair<String, Interface.WATFPathNavigator> ExeChild in this.m_ExeChilds)
            {
                if (ExeChild.Key.Equals(GlobalDefine.Keyword.Executive.Import))
                {
                    ExeChild.Value.Run(context);
                }
            }
            foreach (KeyValuePair<String, Interface.WATFPathNavigator> ExeChild in this.m_ExeChilds)
            {
                if (ExeChild.Key.Equals(GlobalDefine.Keyword.Executive.Test))
                {
                    ExeChild.Value.Run(context);
                }
            }
            return default(object);
        }

        public override void UnInit(string value = "")
        {
            throw new NotImplementedException();
        }
    }
}

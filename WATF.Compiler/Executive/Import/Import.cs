using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Executive.Import
{
    public class Import : WATF.Compiler.Interface.WATFPathNavigator
    {
        Interface.WATFDictionary<String, WATF.Compiler.Interface.WATFPathNavigator> m_ImportChilds = null;
        public Import(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {
            this.m_ImportChilds = new Interface.WATFDictionary<String, WATF.Compiler.Interface.WATFPathNavigator>();
            XPathNodeIterator xPathNodeIterator = xPathNavigator.CreateNavigator().SelectChildren(XPathNodeType.Element);
            while (xPathNodeIterator.MoveNext())
            {
                if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.Executive.Package))
                {
                    m_ImportChilds.Add(xPathNodeIterator.Current.LocalName, new Package.Package(xPathNodeIterator.Current));
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
            foreach (KeyValuePair<String, Interface.WATFPathNavigator> ImportChild in this.m_ImportChilds)
            {
                if (ImportChild.Key.Equals(GlobalDefine.Keyword.Executive.Package))
                {
                    ImportChild.Value.Run(value);
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

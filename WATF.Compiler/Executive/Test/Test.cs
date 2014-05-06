using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Executive.Test
{
    public class Test : WATF.Compiler.Interface.WATFPathNavigator
    {
        Interface.WATFDictionary<String, Interface.WATFPathNavigator> m_TestChilds = null;
        public Test(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {
            m_TestChilds = new Interface.WATFDictionary<string, Interface.WATFPathNavigator>();
            XPathNodeIterator xPathNodeIterator = xPathNavigator.CreateNavigator().SelectChildren(XPathNodeType.Element);
            while (xPathNodeIterator.MoveNext())
            {
                if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.Executive.Step))
                {
                    m_TestChilds.Add(GlobalDefine.Keyword.Executive.Step, new Step.Step(xPathNodeIterator.Current));
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
            foreach (KeyValuePair<String, Interface.WATFPathNavigator> TestChild in this.m_TestChilds)
            {
                if (TestChild.Key.Equals(GlobalDefine.Keyword.Executive.Step))
                {
                    TestChild.Value.Run(value);
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

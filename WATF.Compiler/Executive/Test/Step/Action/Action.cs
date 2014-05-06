using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Executive.Test.Step.Action
{
    public class Action : WATF.Compiler.Interface.WATFPathNavigator
    {
        public Interface.WATFDictionary<String, String> m_Attributes = null;
        public Interface.WATFDictionary<String, WATF.Compiler.Interface.WATFPathNavigator> m_ActionChilds = null;

        public Action(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {
            m_ActionChilds = new Interface.WATFDictionary<string, Interface.WATFPathNavigator>();
            XPathNodeIterator xPathNodeIterator = xPathNavigator.CreateNavigator().SelectChildren(XPathNodeType.Element);
            while (xPathNodeIterator.MoveNext())
            {
                if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.Executive.Action))
                {
                    m_ActionChilds.Add(GlobalDefine.Keyword.Executive.Action, new Action(xPathNodeIterator.Current));
                }
            }
            this.m_Attributes = new Interface.WATFDictionary<string, string>();
            XPathNavigator copyXPathNavigator = xPathNavigator.CreateNavigator();
            if (copyXPathNavigator.MoveToFirstAttribute())
            {
                this.m_Attributes.Add(copyXPathNavigator.Name, copyXPathNavigator.Value);
                while (copyXPathNavigator.MoveToNextAttribute())
                {
                    this.m_Attributes.Add(copyXPathNavigator.Name,copyXPathNavigator.Value);
                }
            }
        }
        public override int Init(string value = "")
        {
            throw new NotImplementedException();
        }

        public override object Run(object value = null)
        {
            if (this.m_Attributes.ContainsKey(GlobalDefine.Keyword.Executive.Select))
            {
                Master.Select select = new Master.Select(value);
                select.Run(this);
            }
            return default(object);
        }

        public override void UnInit(string value = "")
        {
            throw new NotImplementedException();
        }
    }
}

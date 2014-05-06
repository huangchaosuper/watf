using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Executive.Test.Step
{
    public class Step : WATF.Compiler.Interface.WATFPathNavigator
    {
        Interface.WATFDictionary<String, WATF.Compiler.Interface.WATFPathNavigator> m_StepChilds = null;
        public Step(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {
            m_StepChilds = new Interface.WATFDictionary<string, Interface.WATFPathNavigator>();
            XPathNodeIterator xPathNodeIterator = xPathNavigator.CreateNavigator().SelectChildren(XPathNodeType.Element);
            while (xPathNodeIterator.MoveNext())
            {
                if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.Executive.Var))
                {
                    m_StepChilds.Add(GlobalDefine.Keyword.Executive.Var, new Var.Var(xPathNodeIterator.Current));
                }
                else if (xPathNodeIterator.Current.LocalName.Equals(GlobalDefine.Keyword.Executive.Action))
                {
                    m_StepChilds.Add(GlobalDefine.Keyword.Executive.Action, new Action.Action(xPathNodeIterator.Current));
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
            foreach (KeyValuePair<String, Interface.WATFPathNavigator> StepChild in this.m_StepChilds)
            {
                if (StepChild.Key.Equals(GlobalDefine.Keyword.Executive.Var))
                {
                    StepChild.Value.Run(value);
                }
            }
            foreach (KeyValuePair<String, Interface.WATFPathNavigator> StepChild in this.m_StepChilds)
            {
                if (StepChild.Key.Equals(GlobalDefine.Keyword.Executive.Action))
                {
                    StepChild.Value.Run(value);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Executive.Test.Step.Var
{
    public class Var: WATF.Compiler.Interface.WATFPathNavigator
    {
        Interface.WATFDictionary<String, String> m_Attributes = null;
        public Var(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {
            this.m_Attributes = new Interface.WATFDictionary<string, string>();
            XPathNavigator copyXPathNavigator = xPathNavigator.CreateNavigator();
            if (copyXPathNavigator.MoveToFirstAttribute())
            {
                this.m_Attributes.Add(copyXPathNavigator.Name, copyXPathNavigator.Value);
                while (copyXPathNavigator.MoveToNextAttribute())
                {
                    this.m_Attributes.Add(copyXPathNavigator.Name, copyXPathNavigator.Value);
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
            Interface.WATFContext context = (Interface.WATFContext)value;
            if (this.m_Attributes.ContainsKey(GlobalDefine.Keyword.Executive.Name)
                && this.m_Attributes.ContainsKey(GlobalDefine.Keyword.Executive.Value))
            {
                context.Vars.Add(this.m_Attributes[GlobalDefine.Keyword.Executive.Name], this.m_Attributes[GlobalDefine.Keyword.Executive.Value]);
            }
            return default(object);
        }
        public override void UnInit(string value = "")
        {
            throw new NotImplementedException();
        }
    }
}

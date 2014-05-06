using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Executive.Import.Package
{
    public class Package: WATF.Compiler.Interface.WATFPathNavigator
    {
        Interface.WATFDictionary<String, String> m_Attributes = null;
        public Package(XPathNavigator xPathNavigator)
            : base(xPathNavigator)
        {
            this.m_Attributes = new Interface.WATFDictionary<string, string>();
            XPathNavigator copyXPathNavigator = xPathNavigator.CreateNavigator();
            if(copyXPathNavigator.MoveToFirstAttribute())
            {
                if(copyXPathNavigator.Name.Equals(GlobalDefine.Keyword.Executive.Path))
                {
                    this.m_Attributes.Add(copyXPathNavigator.Name, Path.Value(xPathNavigator));
                }
                else if(copyXPathNavigator.Name.Equals(GlobalDefine.Keyword.Executive.Prefix))
                {
                    this.m_Attributes.Add(copyXPathNavigator.Name, Prefix.Value(xPathNavigator));
                }
                while (copyXPathNavigator.MoveToNextAttribute())
                {
                    if (copyXPathNavigator.Name.Equals(GlobalDefine.Keyword.Executive.Path))
                    {
                        this.m_Attributes.Add(copyXPathNavigator.Name, Path.Value(xPathNavigator));
                    }
                    else if (copyXPathNavigator.Name.Equals(GlobalDefine.Keyword.Executive.Prefix))
                    {
                        this.m_Attributes.Add(copyXPathNavigator.Name, Prefix.Value(xPathNavigator));
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
            //throw new NotImplementedException();
            Interface.WATFContext context = (Interface.WATFContext)value;
            if (this.m_Attributes.ContainsKey(GlobalDefine.Keyword.Executive.Path)
                && this.m_Attributes.ContainsKey(GlobalDefine.Keyword.Executive.Prefix))
            {
                context.Assemblys.Add(this.m_Attributes[GlobalDefine.Keyword.Executive.Prefix],
                    System.Reflection.Assembly.LoadFrom(this.m_Attributes[GlobalDefine.Keyword.Executive.Path]));
            }
            return default(object);
        }

        public override void UnInit(string value = "")
        {
            throw new NotImplementedException();
        }
    }
}

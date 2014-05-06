using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.ConfigFile.Load
{
    public class Name
    {
        public static string Value(XPathNavigator xPathNavigator)
        {
            return xPathNavigator.GetAttribute(GlobalDefine.Keyword.ConfigFile.Name, String.Empty);
        }
    }
}
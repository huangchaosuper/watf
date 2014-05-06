using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Executive.Import.Package
{
    public class Path
    {
        public static string Value(XPathNavigator xPathNavigator)
        {
            return xPathNavigator.GetAttribute(GlobalDefine.Keyword.Executive.Path, String.Empty);
        }
    }
}

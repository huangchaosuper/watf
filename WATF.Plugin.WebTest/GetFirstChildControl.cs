using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.WebTest
{
    public class GetFirstChildControl:WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            //throw new NotImplementedException();
            mshtml.IHTMLElement element = parent as mshtml.IHTMLElement;
            foreach(mshtml.IHTMLElement firstChild in element.children as mshtml.IHTMLElementCollection)
            {
                return firstChild;
            }
            return default(object);
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

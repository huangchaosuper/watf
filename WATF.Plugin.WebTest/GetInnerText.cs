using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.WebTest
{
    public class GetInnerText : WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            //throw new NotImplementedException();
            mshtml.IHTMLElement element = parent as mshtml.IHTMLElement;
            return element.innerText;
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

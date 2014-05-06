using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.WebTest
{

    public class GetControlByClass : WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            if(!parameters.ContainsKey("Tag")) throw new ArgumentNullException("Tag");
            if(!parameters.ContainsKey("ClassName")) throw new ArgumentNullException("ClassName");
            mshtml.IHTMLDocument3 document = parent as mshtml.IHTMLDocument3;
            if (document != null)
            {
                mshtml.IHTMLElementCollection elements = document.getElementsByTagName(parameters["Tag"] as string);
                foreach(mshtml.IHTMLElement element in elements)
                {
                    if(element.className == parameters["ClassName"] as string)
                    {
                        return element;
                    }
                }
            }
            return default(object);
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

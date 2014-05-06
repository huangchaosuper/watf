using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.WebTest
{
    public class GetControlById:WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            if (!parameters.ContainsKey("Id")) throw new ArgumentNullException("Id");
            mshtml.IHTMLDocument3 document = parent as mshtml.IHTMLDocument3;
            WaitForPageReady waitForPageReady = new WaitForPageReady();
            waitForPageReady.StartMethod(parent);
            waitForPageReady.EndMethod();
            if (document != null)
            {
                return document.getElementById((string)parameters["Id"]);
            }
            return default(object);
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

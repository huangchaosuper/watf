using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.WebTest
{
    public class InputText : WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            if (!parameters.ContainsKey("Text")) throw new ArgumentNullException("Text");
            mshtml.IHTMLInputElement element = parent as mshtml.IHTMLInputElement;
            if (element != null)
            {
                mshtml.IHTMLTxtRange tr = element.createTextRange();
                tr.text = (string)parameters["Text"];
                ((mshtml.IHTMLElement3)element).FireEvent("onchange");
            }
            return default(object);
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}
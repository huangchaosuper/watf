using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.WebTest
{
    public class WaitForPageReady : WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            int time = 30;
            mshtml.IHTMLDocument2 document2 = null;
            if (parent == null)
            {
                if (parameters == null && !parameters.ContainsKey("Page")) throw new ArgumentNullException("Page");
                document2 = parameters["Page"] as mshtml.IHTMLDocument2;
            }
            else 
            {
                document2 = parent as mshtml.IHTMLDocument2;
            }
            if (parameters != null && parameters.ContainsKey("WaitSecond"))
            {
                int.TryParse(parameters["WaitSecond"] as string, out time);
            }
            for (int i = 0; i < time; i++)
            {
                if (document2 != null && document2.readyState.Equals("complete"))
                {
                    break;
                }

                System.Console.WriteLine("READY:" + (document2 == null ? "null" : document2.readyState));
                System.Threading.Thread.Sleep(1000);
            }
            return default(object);
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

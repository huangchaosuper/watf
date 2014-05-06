using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDNOnline.Test
{
    public class GetPageResultUrlList : WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            if (!parameters.ContainsKey("Tag")) throw new ArgumentNullException("Tag");
            if (!parameters.ContainsKey("ClassName")) throw new ArgumentNullException("ClassName");
            List<string> resultListUrl = new List<string>();
            mshtml.IHTMLDocument2 doc2 = parent as mshtml.IHTMLDocument2;
            Common.WaitForPageReady(doc2);
            string url = doc2.url;
            for (int i = 0; i < 1; i++)
            {
                mshtml.IHTMLDocument2 document2 = parent as mshtml.IHTMLDocument2;
                mshtml.IHTMLDocument3 document3 = parent as mshtml.IHTMLDocument3;
                Common.WaitForPageReady(document2);
                document2.url = string.Format("{0}{1}{2}", url, "&startindex=", i * 20);
                if (document3 != null)
                {
                    mshtml.IHTMLElementCollection elements = document3.getElementsByTagName(parameters["Tag"] as string);
                    foreach (mshtml.IHTMLElement element in elements)
                    {
                        if (element.className == parameters["ClassName"] as string)
                        {
                            mshtml.IHTMLElementCollection elementChildren = element.children as mshtml.IHTMLElementCollection;
                            foreach (mshtml.IHTMLElement firstChild in elementChildren)
                            {
                                resultListUrl.Add(firstChild.getAttribute("href") as string);
                                break;
                            }
                        }
                    }
                }
            }
            return resultListUrl;
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }

    }
}

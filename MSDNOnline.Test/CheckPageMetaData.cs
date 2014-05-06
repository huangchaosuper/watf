using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDNOnline.Test
{
    public class CheckPageMetaData : WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            //throw new NotImplementedException();
            if (!parameters.ContainsKey("PageList")) throw new ArgumentNullException("PageList");
            if (!parameters.ContainsKey("CheckMetaData")) throw new ArgumentNullException("CheckMetaData");
            List<string> pageUrlList = new List<string>(parameters["PageList"] as List<string>);
            Dictionary<string,string> pageMetaData = new Dictionary<string,string>();
            foreach(string url in pageUrlList)
            {
                mshtml.IHTMLDocument2 document2 = parent as mshtml.IHTMLDocument2;
                document2.url = url;
                Common.WaitForPageReady(document2);
                mshtml.IHTMLDocument3 document3 = parent as mshtml.IHTMLDocument3;
                if (document3 != null)
                {
                    mshtml.IHTMLElementCollection elements = document3.getElementsByName(parameters["CheckMetaData"] as string);
                    foreach (mshtml.IHTMLElement element in elements)
                    {
                        System.Console.WriteLine("URL=[{0}],Content=[{1}]", url, element.getAttribute("content") as string);
                        if (!pageMetaData.ContainsKey(url))
                        {
                            pageMetaData.Add(url, element.getAttribute("content") as string);
                        }
                        else 
                        {
                            System.Console.WriteLine("Repeat:URL=[{0}],Content=[{1}]", url, element.getAttribute("content") as string);
                        }
                        break;
                    }
                }
            }
            return pageMetaData;
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.WebTest
{
    public class GetCurrentPage : WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            //throw new NotImplementedException();
            SHDocVw.ShellWindows shellwindows = new SHDocVw.ShellWindows();
            string filename;
            foreach (SHDocVw.InternetExplorer ie in shellwindows)
            {
                filename = System.IO.Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                if (filename.Equals("iexplore") && ie.LocationURL.StartsWith("http://"))
                {
                    Console.WriteLine("Web Site　　: {0}", ie.LocationURL);
                    mshtml.IHTMLDocument2 document = ie.Document as mshtml.IHTMLDocument2;
                    while (document.readyState != "complete")
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    return document;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.WebTest
{
    public class OpenIEBrowser:WATF.Plugin.IPlugin
    {
        private SHDocVw.InternetExplorer m_ieBrowser = new SHDocVw.InternetExplorer();
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            if (!parameters.ContainsKey("Url")) throw new ArgumentNullException("Url");
            KillIExplore();
            System.Diagnostics.Process IE = System.Diagnostics.Process.Start("IExplore.exe", (string)parameters["Url"]);
            System.Threading.Thread.Sleep(5000);
            SHDocVw.ShellWindows shellwindows = new SHDocVw.ShellWindows();
            string filename;
            foreach (SHDocVw.InternetExplorer ie in shellwindows)
            {
                filename = System.IO.Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                if (filename.Equals("iexplore") && ie.LocationURL.StartsWith("http://"))
                {
                    m_ieBrowser = ie;
                    Console.WriteLine("Web Site　　: {0}", ie.LocationURL);
                    mshtml.IHTMLDocument2 document = m_ieBrowser.Document as mshtml.IHTMLDocument2;
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
            if (this.m_ieBrowser != null)
            {
                this.m_ieBrowser.Quit();
            }
            KillIExplore();
        }
        private void KillIExplore()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("iexplore");
            
            foreach (System.Diagnostics.Process process in processes)
            {
                process.Kill();
                //System.Console.WriteLine(process.ProcessName);
            }
            while (true)
            {
                processes = System.Diagnostics.Process.GetProcessesByName("iexplore");
                if (processes.Length < 1)
                {
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
        }
    }
}

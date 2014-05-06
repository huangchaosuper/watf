using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Core.Browser.IE
{
    internal class IE : Browser
    {
        private SHDocVw.InternetExplorer m_ieBrowser;
        public IE()
        {
            //m_ieBrowser = new InternetExplorer();
        }
        public override void Open(string URL)
        {
            //object mVal = System.Reflection.Missing.Value;
            //m_ieBrowser.Navigate(URL, ref mVal, ref mVal, ref mVal, ref mVal);
            System.Diagnostics.Process.Start("IExplore.exe", URL);
        }
        public override WATF.Core.Page.IPage Page()
        {
            SHDocVw.ShellWindows shellwindows = new SHDocVw.ShellWindows();
            string filename;
            foreach (SHDocVw.InternetExplorer ie in shellwindows)
            {
                filename = System.IO.Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                if (filename.Equals("iexplore"))
                {
                    m_ieBrowser = ie;
                    Console.WriteLine("Web Site　　: {0}", ie.LocationURL);
                    return new WATF.Core.Page.Page(ie.Document);
                }
            }
            return null;
        }
        public override void Close()
        {
            //throw new NotImplementedException();
            if (this.m_ieBrowser != null)
            {
                this.m_ieBrowser.Quit();
            }
        }
    }
}

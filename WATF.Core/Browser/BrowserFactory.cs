using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATF.Core.Page;

namespace WATF.Core.Browser
{
    internal abstract class Browser
    {
        public abstract void Open(string URL);
        public abstract IPage Page();
        public abstract void Close();
    }
    public class BrowserFactory : IBrowser
    {
        private Browser m_browser = null;
        private static BrowserFactory m_browserFactory = null;
        public BrowserFactory() { }
        public static IBrowser GetInstance()
        {
            if (null == m_browserFactory)
            {
                m_browserFactory = new BrowserFactory();
            }
            return m_browserFactory;
        }
        public void InitBrowser(string type)
        {
            if (type.Equals("IE"))
            {
                m_browser = new IE.IE();
            }
        }

        public void OpenBrowser(string URL)
        {
            m_browser.Open(URL);
        }

        public WATF.Core.Page.IPage GetPage(string key)
        {
            return m_browser.Page();
        }

        public string BrowserInfo(string key)
        {
            throw new NotImplementedException();
        }

        public void CloseBrowser()
        {
            m_browser.Close();
        }
    }
}

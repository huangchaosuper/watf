using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Core.WebControls
{
    public class WebControlFactory
    {
        private static WebControlFactory m_webControlFactory = null;
        private String m_type = null;
        private WebControlFactory(String type) { this.m_type = type; }
        public static WebControlFactory GetInstance(String type)
        {
            if (m_webControlFactory == null)
            {
                m_webControlFactory = new WebControlFactory(type);
            }
            return m_webControlFactory;
        }
        public IWebControl GetWebControl(IWebControl webControl)
        {
            return webControl;
        }
        public List<IWebControl> GetWebControls(List<HtmlControls.HtmlControl> htmlControls)
        {
            List<IWebControl> webControls = new List<IWebControl>();
            foreach (IWebControl webControl in htmlControls)
            { 
                webControls.Add(webControl);
            }
            return webControls;
        }
        public IWebControl GetWebControl(Page.IPage page,String controlID)
        {
            switch (this.m_type)
            {
                case "HTML": return new HtmlControls.HtmlControl(page, controlID);
            }
            return null;
        }
    }
}

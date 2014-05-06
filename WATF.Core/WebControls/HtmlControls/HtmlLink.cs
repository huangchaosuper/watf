using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Core.WebControls.HtmlControls
{
    public class HtmlLink : HtmlControl
    {
        public HtmlLink(WATF.Core.Page.IPage page, mshtml.IHTMLElement elem)
            : base(page, elem)
        {
            this.m_Page = page;
            this.m_HtmlElement = elem;
        }
        public string Href
        {
            get { return this.m_HtmlElement.getAttribute("href"); }
        }
        public string Target
        {
            get { return this.m_HtmlElement.getAttribute("target"); }
        }
    }
}

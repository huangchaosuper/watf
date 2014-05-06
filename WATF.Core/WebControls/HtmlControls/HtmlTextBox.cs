using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Core.WebControls.HtmlControls
{
    public class HtmlTextBox:HtmlControl
    {
        public HtmlTextBox(WATF.Core.Page.IPage page, mshtml.IHTMLElement elem)
            : base(page, elem)
        {
            this.m_Page = page;
            this.m_HtmlElement = elem;
        }
    }
}

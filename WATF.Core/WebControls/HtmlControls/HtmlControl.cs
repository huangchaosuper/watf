using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Core.WebControls.HtmlControls
{
    public class HtmlControl : IWebControl
    {
        protected WATF.Core.Page.IPage m_Page = null;
        protected mshtml.IHTMLElement m_HtmlElement = null;
        public HtmlControl(WATF.Core.Page.IPage page, mshtml.IHTMLElement elem)
        {
            this.m_Page = page;
            this.m_HtmlElement = elem;
        }
        public virtual void Click()
        {
            this.m_HtmlElement.click();
        }

        public virtual string InnerText()
        {
            return this.m_HtmlElement.innerText;
        }

        public virtual string OuterText()
        {
            return this.m_HtmlElement.outerText;
        }

        public virtual string ControlInfo(string key)
        {
            return this.m_HtmlElement.getAttribute(key);
        }

        public virtual void Write(string value, string key)
        {
            if (key.Equals("textinput"))
            {
                mshtml.IHTMLTxtRange tr = ((mshtml.IHTMLInputElement)this.m_HtmlElement).createTextRange();
                tr.text = value;
                ((mshtml.IHTMLElement3)this.m_HtmlElement).FireEvent("onchange");
            }
            else
            {
                this.m_HtmlElement.setAttribute(key,value);
            }
        }
    }
}

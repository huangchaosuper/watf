using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATF.Core.WebControls;

namespace WATF.Core.Page
{
    public class Page : IPage
    {
        #region "Constructors, fields"
        private mshtml.IHTMLDocument2 m_htmlDocument = null;
        public Page(mshtml.IHTMLDocument2 Document)
        {
            this.m_htmlDocument = Document;
        }
        #endregion
        #region "Properties"
        public String RawHtml
        {
            get { return this.m_htmlDocument.body.innerHTML; }
        }
        public String PageUrl
        {
            get { return this.m_htmlDocument.url; }
        }
        private mshtml.IHTMLDocument Document1
        {
            get { return this.m_htmlDocument; }
        }
        private mshtml.IHTMLDocument2 Document2
        {
            get { return this.m_htmlDocument; }
        }
        private mshtml.IHTMLDocument3 Document3
        {
            get { return this.m_htmlDocument as mshtml.IHTMLDocument3; }
        }
        private mshtml.IHTMLDocument4 Document4
        {
            get { return this.m_htmlDocument as mshtml.IHTMLDocument4; }
        }
        private mshtml.IHTMLDocument5 Document5
        {
            get { return this.m_htmlDocument as mshtml.IHTMLDocument5; }
        }
        #endregion
        #region "Methods"
        public Boolean WaitForReadyPage(Int32 secondWait = 1)
        {
            while (this.m_htmlDocument.readyState != GlobalDefine.Page.HTML.Complete)
            {
                if (secondWait <= 0) break;
                System.Threading.Thread.Sleep(1000);
                secondWait -= 1;
            }
            if (this.m_htmlDocument.readyState != GlobalDefine.Page.HTML.Complete)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private WATF.Core.WebControls.HtmlControls.HtmlControl GetHtmlControlByID(string controlID)
        {
            return new WebControls.HtmlControls.HtmlControl(this, this.Document3.getElementById(controlID));
        }
        private List<WATF.Core.WebControls.HtmlControls.HtmlControl> GetHtmlControlsByName(string Name)
        {
            mshtml.IHTMLElementCollection elems = this.Document3.getElementsByName(Name);
            List<WATF.Core.WebControls.HtmlControls.HtmlControl> lElem = new List<WATF.Core.WebControls.HtmlControls.HtmlControl>();
            foreach (mshtml.IHTMLElement elem in elems)
            {
                lElem.Add(new WATF.Core.WebControls.HtmlControls.HtmlControl(this, elem));
            }
            return lElem;
        }
        private List<WATF.Core.WebControls.HtmlControls.HtmlControl> GetHtmlControlsByClassName(string TAG, string ClassName)
        {
            mshtml.IHTMLElementCollection elems = this.Document3.getElementsByTagName(TAG);
            List<WATF.Core.WebControls.HtmlControls.HtmlControl> lElem = new List<WATF.Core.WebControls.HtmlControls.HtmlControl>();
            foreach (mshtml.IHTMLElement elem in elems)
            {
                if (elem.className == ClassName)
                {
                    lElem.Add(new WATF.Core.WebControls.HtmlControls.HtmlControl(this, elem));
                }
            }
            return lElem;
        }
        private List<WATF.Core.WebControls.HtmlControls.HtmlControl> GetHtmlControlsByTAG(string TAG)
        {
            mshtml.IHTMLElementCollection elems = this.Document3.getElementsByTagName(TAG);
            List<WATF.Core.WebControls.HtmlControls.HtmlControl> lElem = new List<WATF.Core.WebControls.HtmlControls.HtmlControl>();
            foreach (mshtml.IHTMLElement elem in elems)
            {
                lElem.Add(new WATF.Core.WebControls.HtmlControls.HtmlControl(this, elem));
            }
            return lElem;
        }

        public IWebControl PageControl(string key)
        {
            System.Collections.Hashtable hashtable = Common.Common.LexicalAnalysis(key);
            int number = 0;
            String type = GlobalDefine.Page.Html;
            if (hashtable.ContainsKey(GlobalDefine.WebKey.Type))
            {
                type = hashtable[GlobalDefine.WebKey.Type].ToString();
            }
            if (type.Equals(GlobalDefine.Page.Html))
            {
                if (hashtable.ContainsKey(GlobalDefine.WebKey.Number))
                {
                    number = Convert.ToInt32(hashtable[GlobalDefine.WebKey.Number]);
                }
                if (hashtable.ContainsKey(GlobalDefine.WebKey.Id))
                {
                    return GetHtmlControlByID(hashtable[GlobalDefine.WebKey.Id].ToString());
                }
                else if (hashtable.ContainsKey(GlobalDefine.WebKey.Name))
                {
                    return GetHtmlControlsByName(hashtable[GlobalDefine.WebKey.Name].ToString())[number];
                }
                else if (hashtable.ContainsKey(GlobalDefine.WebKey.Tag))
                {
                    if (hashtable.ContainsKey(GlobalDefine.WebKey.Class))
                    {
                        return GetHtmlControlsByClassName(hashtable[GlobalDefine.WebKey.Tag].ToString(), hashtable[GlobalDefine.WebKey.Class].ToString())[number];
                    }
                    else
                    {
                        return GetHtmlControlsByTAG(hashtable[GlobalDefine.WebKey.Tag].ToString())[number];
                    }
                }
            }
            else if (type.Equals(GlobalDefine.Page.Flash))
            {

            }
            else if (type.Equals(GlobalDefine.Page.Sliverlight))
            {

            }
            return null;
        }
        public IWebControl[] PageControls(string key)
        {
            System.Collections.Hashtable hashtable = Common.Common.LexicalAnalysis(key);
            String type = GlobalDefine.Page.Html;
            if (hashtable.ContainsKey(GlobalDefine.WebKey.Type))
            {
                type = hashtable[GlobalDefine.WebKey.Type].ToString();
            }
            if (type.Equals(GlobalDefine.Page.Html))
            {
                if (hashtable.ContainsKey(GlobalDefine.WebKey.Name))
                {
                    return GetHtmlControlsByName(hashtable[GlobalDefine.WebKey.Name].ToString()).ToArray();
                }
                else if (hashtable.ContainsKey(GlobalDefine.WebKey.Tag))
                {
                    if (hashtable.ContainsKey(GlobalDefine.WebKey.Class))
                    {
                        return GetHtmlControlsByClassName(hashtable[GlobalDefine.WebKey.Tag].ToString(), hashtable[GlobalDefine.WebKey.Class].ToString()).ToArray();
                    }
                    else
                    {
                        return GetHtmlControlsByTAG(hashtable[GlobalDefine.WebKey.Tag].ToString()).ToArray();
                    }
                }
            }
            else if (type.Equals(GlobalDefine.Page.Flash))
            {

            }
            else if (type.Equals(GlobalDefine.Page.Sliverlight))
            {

            }
            return null;
        }
        public string PageInfo(string key)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region "Exceptions"

        #endregion

    }
}

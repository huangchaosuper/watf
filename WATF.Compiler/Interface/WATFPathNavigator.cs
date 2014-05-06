using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WATF.Compiler.Interface
{
    public abstract class WATFPathNavigator:Interface.IWATFApp
    {
        protected XPathNavigator m_xPathNavigator = null;
        public WATFPathNavigator(XPathNavigator xPathNavigator)
        {
            this.m_xPathNavigator = xPathNavigator;
        }

        public abstract int Init(string value = "");

        public abstract object Run(object value = null);

        public abstract void UnInit(string value = "");
    }
}

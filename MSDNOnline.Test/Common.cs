using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDNOnline.Test
{
    internal class Common
    {
        static public void WaitForPageReady(mshtml.IHTMLDocument2 document, int secondWait = 30)
        {
            for (int i = 0; i < secondWait; i++)
            {
                if (document != null && document.readyState.Equals("complete"))
                {
                    break;
                }
                System.Console.WriteLine("READY:" + document == null ? "null" : document.readyState);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

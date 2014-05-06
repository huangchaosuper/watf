using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WATF.Plugin.HPST.Assert.IsTrue isTrue = new Plugin.HPST.Assert.IsTrue();
            Dictionary<string,object> parameters= new Dictionary<string,object>();
            parameters.Add("Condition",false);
            parameters.Add("Message","WATF Test");
            isTrue.StartMethod(null, parameters);
            isTrue.EndMethod();
            //WATF.Core.Browser.BrowserFactory mybrowser = new WATF.Core.Browser.BrowserFactory();
            //mybrowser.InitBrowser("IE");
            //mybrowser.OpenBrowser("http://www.baidu.com/");
            //System.Threading.Thread.Sleep(2000);
            //WATF.Core.Page.IPage page = mybrowser.GetPage("");
            //page.PageControl("ID = kw").Write("黄超");
            //page.WaitForReadyPage(2);
            //page.PageControl("ID = su").Click();
            //page.WaitForReadyPage(2);
            //if (page.PageControl("ID = 1").OuterText().Contains("百度百科"))
            //{
            //    System.Console.WriteLine("Success!");
            //}

            //mybrowser.CloseBrowser();
        }
    }
}

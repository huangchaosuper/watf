using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WATF.Core.Browser
{
    [Guid("C9C4CA23-683A-43CF-81E4-DE3163481ACF")]
    public interface IBrowser
    {
        [DispId(1)]
        void InitBrowser(string type);
        [DispId(2)]
        void OpenBrowser(string URL);
        [DispId(3)]
        WATF.Core.Page.IPage GetPage(string key);
        [DispId(4)]
        string BrowserInfo(string key);
        [DispId(5)]
        void CloseBrowser();
    }
}

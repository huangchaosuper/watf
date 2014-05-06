using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WATF.Core.Page
{
    [Guid("961BA471-1B3A-424F-B952-A329D22CABAC")]
    public interface IPage
    {
        [DispId(1)]
        string PageInfo(string key);
        [DispId(2)]
        WATF.Core.WebControls.IWebControl PageControl(string key);
        [DispId(3)]
        WATF.Core.WebControls.IWebControl[] PageControls(string key);
        [DispId(4)]
        Boolean WaitForReadyPage(Int32 secondWait = 1);
    }
}

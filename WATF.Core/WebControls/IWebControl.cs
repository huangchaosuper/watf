using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WATF.Core.WebControls
{
    [Guid("964B0D30-FA5F-4376-A084-043650F1E82A")]
    public interface IWebControl
    {
        [DispId(1)]
        void Click();
        [DispId(2)]
        string InnerText();
        [DispId(3)]
        string OuterText();
        [DispId(4)]
        string ControlInfo(string key);
        [DispId(5)]
        void Write(string value,string key="textinput");
    }
}

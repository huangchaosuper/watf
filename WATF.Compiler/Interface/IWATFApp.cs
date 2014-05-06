using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WATF.Compiler.Interface
{
    [Guid("D9F59DD0-922C-45CF-A963-C52EF389D54E")]
    public interface IWATFApp
    {
        [DispId(1)]
        Int32 Init(String value="");
        [DispId(2)]
        Object Run(Object value = null);
        [DispId(3)]
        void UnInit(String value = "");
    }
}

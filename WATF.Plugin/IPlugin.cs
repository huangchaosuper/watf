using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WATF.Plugin
{
    [Guid("9941CA8F-AE53-4BBC-81C8-BDA178A91217")]
    public interface IPlugin
    {
        [DispId(1)]
        Object StartMethod(Object parent = null, Dictionary<string, Object> parameters = null);
        [DispId(2)]
        void EndMethod();
    }
}

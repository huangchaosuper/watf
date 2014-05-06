﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.HPST.Assert
{
    public class IsFalse : WATF.Plugin.HPST.Assert.Base, WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            //throw new NotImplementedException();
            if ((bool)parent == true)
            {
                string message = parameters.ContainsKey("Message") ? (string)parameters["Message"] : "";
                base.AddReport(0, message);
            }
            return default(object);
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

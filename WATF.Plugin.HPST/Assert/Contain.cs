using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.HPST.Assert
{
    public class Contain : WATF.Plugin.HPST.Assert.Base, WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            //throw new NotImplementedException();
            if (!parameters.ContainsKey("Contain")) throw new ArgumentNullException("Contain");
            string contain = (string)parameters["Contain"];
            string key = (string)parent;
            if (!key.Contains(contain))
            {
                string message = parameters.ContainsKey("Message") ? (string)parameters["Message"] : "";
                base.AddReport(0, message, parent.ToString(), contain.ToString());
            }
            return default(object);
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

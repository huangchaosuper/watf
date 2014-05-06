using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Plugin.HPST.Assert
{
    public class AreNotEqual : WATF.Plugin.HPST.Assert.Base, WATF.Plugin.IPlugin
    {
        public object StartMethod(object parent = null, Dictionary<string, object> parameters = null)
        {
            //throw new NotImplementedException();
            object actual = parent;
            if (!parameters.ContainsKey("Expected")) throw new ArgumentNullException("Expected");
            object expected = parameters["Expected"];
            bool equal = false;
            if (actual == null)
            {
                if (expected == null)
                {
                    equal = true;
                }
                else
                {
                    equal = false;
                }
            }
            else
            {
                equal = actual.Equals(expected);
            }
            if (equal)
            {
                string message = parameters.ContainsKey("Message") ? (string)parameters["Message"] : "";
                base.AddReport(0, message, actual.ToString(), expected.ToString());
            }
            return default(object);
        }

        public void EndMethod()
        {
            //throw new NotImplementedException();
        }
    }
}

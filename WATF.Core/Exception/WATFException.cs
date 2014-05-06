using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Core.Exception
{
    public class WATFException : System.Exception
    {
        public WATFException() : base() { }
        public WATFException(string message) : base(message) { }
        protected WATFException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        public WATFException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}

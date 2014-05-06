using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Compiler.Exception
{
    public class CompilerException : System.Exception
    {
        public CompilerException(string message) : base(message) { }
        protected CompilerException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        public CompilerException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}

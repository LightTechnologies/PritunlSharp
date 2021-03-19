using System;
using System.Collections.Generic;
using System.Text;

namespace Pritunl.Wrapper.Exceptions
{
    /// <summary>
    /// Exception that occurs whenever pritunl returns bad 
    /// </summary>
    public class PritunlException : Exception
    {
        public PritunlException(string message) : base(message)
        {

        }
    }
}

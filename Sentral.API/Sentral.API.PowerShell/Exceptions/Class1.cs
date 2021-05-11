using System;
using System.Collections.Generic;
using System.Text;
namespace Sentral.API.PowerShell.Exceptions
{
    public class SentralApiConnectionException : Exception
    {
        public SentralApiConnectionException()
        {
        }
        public SentralApiConnectionException(string message) :base(message)
        {
        }
        public SentralApiConnectionException(string message, Exception inner) : base(message,  inner)
        {
        }
    }
}

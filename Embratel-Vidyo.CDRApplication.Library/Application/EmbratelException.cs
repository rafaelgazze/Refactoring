using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embratel_Vidyo.CDRApplication.Library.Application
{
    public class EmbratelException : Exception
    {
        public EmbratelException(string message) : base(message)
        {
        }
    }
}

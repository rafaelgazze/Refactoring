using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embratel_Vidyo.CDRApplication.Library
{
    public interface IManagement
    {
        DateTime DataInicial { get; set; }
        DateTime DataFinal { get; set; }
        int CallId { get; set; }
        string UserName { get; set; }

        void Insert();
        bool ExistsCallId();


    }
}

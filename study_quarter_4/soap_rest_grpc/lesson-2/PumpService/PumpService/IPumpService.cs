using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PumpService
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IPumpService
    {
        [OperationContract(IsOneWay = true)]
        void RunScript();

        [OperationContract(IsOneWay = true)]
        void UpdateAndcompileScript(string fileName);

        [OperationContract(IsOneWay = true)]
        void CompileScript();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PumpService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PumpService : IPumpService
    {

        private readonly IScriptService _scriptService;
        private readonly IStatisticsService _statisticsService;
        private readonly ISettingService _settingService;

        public PumpService()
        {
            _statisticsService = new StatisticsService();
            _settingService = new SettingService();
            _scriptService = new ScriptService(_statisticsService, _settingService, Callback);
        }

        public void CompileScript()
        {
            _scriptService.Compile();
        }

        public void RunScript()
        {
            _scriptService.Run();
        }

        public void UpdateAndcompileScript(string fileName)
        {
            _settingService.FileName = fileName;
            _scriptService.Run();
        }

        IPumpServiceCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IPumpServiceCallback>();
            }
        }
    }
}

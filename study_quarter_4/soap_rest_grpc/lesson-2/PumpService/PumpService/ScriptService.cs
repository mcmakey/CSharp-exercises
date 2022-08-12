using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PumpService
{
    public class ScriptService : IScriptService
    {
        CompilerResults compilerResults;

        private readonly IStatisticsService _statisticsService;
        private readonly ISettingService _settingService;
        private readonly IPumpServiceCallback _pumpServiceCallback;

        public ScriptService(
                IStatisticsService statisticsService,
                ISettingService settingService,
                IPumpServiceCallback pumpServiceCallback
            )
        {
            _statisticsService = statisticsService;
            _settingService = settingService;
            _pumpServiceCallback = pumpServiceCallback;
            
        }

        public bool Compile()
        {
            try
            {
                CompilerParameters compilerParameters = new CompilerParameters();

                compilerParameters.GenerateInMemory = true;

                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
                compilerParameters.ReferencedAssemblies.Add("System.CSharp.dll");

                compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

                FileStream fileStream = new FileStream(_settingService.FileName, FileMode.Open);
                byte[] buffer;
                try
                {
                    int length = (int)fileStream.Length;
                    buffer = new byte[length];
                    int count;
                    int sum = 0;
                    while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                        sum += count;
                }
                finally
                {
                    fileStream.Close();
                }

                CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();

                compilerResults =
                    cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, Encoding.UTF8.GetString(buffer));

                if (compilerResults.Errors != null && compilerResults.Errors.Count != 0)
                {
                    string compileErrors = string.Empty;
                    for (int i = 0; i < compilerResults.Errors.Count; i++)
                    {
                        if (compileErrors != string.Empty)
                        {
                            compileErrors += "\n";
                        }
                        compileErrors += compilerResults.Errors[i];
                    }
                    //TODO: log
                    return false;
                }
                return true;
            }
            catch(Exception e)
            {
                //TODO: log
                return false;
            }
        }

        public void Run()
        {
            if (compilerResults == null || compilerResults.Errors != null )
            {
                if (!Compile())
                {
                    return;
                }
            }

            Type type = compilerResults.CompiledAssembly.GetType("Sample.SampleScript");

            if (type == null)
            {
                return;
            }

            MethodInfo entryPointMethod = type.GetMethod("EntryPoint");

            if (entryPointMethod == null)
            {
                return;
            }

            Task.Run(() =>
            {

                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if ((bool)entryPointMethod.Invoke(Activator.CreateInstance(type), new object[] { }))
                        {
                            _statisticsService.SuccessTacts++;
                        }
                        else
                        {
                            _statisticsService.ErrorTacts++;
                        }

                        _statisticsService.AllTacts++;

                        _pumpServiceCallback.UpdateStatistics((StatisticsService)_statisticsService);

                        Thread.Sleep(1000);
                    }
                }
                catch(Exception e)
                {
                    //TODO: log
                }


            });
        }
    }
}
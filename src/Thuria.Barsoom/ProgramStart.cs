using System;
using System.Diagnostics;

using Thuria.Zitidar.Core;
using Thuria.Zitidar.Nancy;
using Thuria.Zitidar.Structuremap;

namespace Thuria.Barsoom
{
  public class ProgramStart
  {
    static void Main()
    {
      IThuriaLogger thuriaLogger = null;

      try
      {
        SetupConsole();

        var thuriaBootstrapper = StructuremapThuriaBootstrapper.Create().Build();
        thuriaLogger           = GetThuriaLogger(thuriaBootstrapper.IocContainer);
        var thuriaSettings     = GetThuriaSettings(thuriaBootstrapper.IocContainer);

        if (thuriaSettings.StartDebugMode)
        {
          Debugger.Launch();
        }

        thuriaLogger.LogMessage(LogSeverity.Info, $"Starting {thuriaSettings.ApplicationName}");

        using (var nancyServiceHost = new NancyServiceHost(thuriaBootstrapper.IocContainer))
        {
          nancyServiceHost.Start();
        }

        thuriaLogger.LogMessage(LogSeverity.Info, $"Shutting down {thuriaSettings.ApplicationName}");
      }
      catch (Exception runtimeException)
      {
        if (thuriaLogger == null)
        {
          Console.WriteLine($"Runtime Exception occurred.\n{runtimeException}");
        }
        else
        {
          thuriaLogger.LogMessage(LogSeverity.Exception, $"Runtime Exception occurred.\n{runtimeException}");
        }
      }

      if (Debugger.IsAttached)
      {
        thuriaLogger.LogMessage(LogSeverity.Info, "Press <ENTER> to terminate application");
        Console.ReadLine();
      }
    }

    private static void SetupConsole()
    {
      Console.Clear();
      Console.TreatControlCAsInput = false;
      Console.CancelKeyPress += (sender, eventArgs) =>
        {
          eventArgs.Cancel = true;
        };
    }

    private static IThuriaLogger GetThuriaLogger(IThuriaIocContainer iocContainer)
    {
      var thuriaLogger = iocContainer.GetInstance<IThuriaLogger>();
      if (thuriaLogger == null)
      {
        throw new Exception("Service do not have a logger defined");
      }

      return thuriaLogger;
    }

    private static IThuriaSettings GetThuriaSettings(IThuriaIocContainer iocContainer)
    {
      var thuriaSettings = iocContainer.GetInstance<IThuriaSettings>();
      if (thuriaSettings == null)
      {
        throw new Exception("Service do not have any settings defined");
      }

      return thuriaSettings;
    }
  }
}

using NLog;
using StructureMap;

using Thuria.Zitidar.Core;
using Thuria.Zitidar.Logging;
using Thuria.Zitidar.Settings;
using Thuria.Zitidar.Structuremap;

namespace Thuria.Barsoom
{
  public class BarsoomIocRegistry : Registry
  {
    public BarsoomIocRegistry()
    {
      For<IThuriaIocContainer>().Use<StructuremapThuriaIocContainer>();
      For<IThuriaLogger>().Use("Create and Configure NLog Logger", context =>
        {
          var logger = (IThuriaLogger)LogManager.GetLogger(context.ParentType == null ? context.RequestedName : context.ParentType.Name, typeof(NLogApplicationLogger));
          return logger;
        }).AlwaysUnique();
      For<IThuriaSettings>().Use<ThuriaSettings>().Singleton()
        .Ctor<ThuriaSettingsType>("SettingsType").Is(ThuriaSettingsType.JsonFileEnvironment);
    }
  }
}

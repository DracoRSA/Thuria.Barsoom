using NLog;
using StructureMap;
using Nancy.Bootstrapper;

using Thuria.Helium.Akka;
using Thuria.Zitidar.Core;
using Thuria.Zitidar.Nancy;
using Thuria.Zitidar.Logging;
using Thuria.Zitidar.Serialization;
using Thuria.Zitidar.Settings;
using Thuria.Zitidar.Structuremap;

namespace Thuria.Barsoom
{
  public class BarsoomIocRegistry : Registry
  {
    public BarsoomIocRegistry()
    {
      For<IThuriaIocContainer>().Use<StructuremapThuriaIocContainer>();

      For<IThuriaLogger>()
        .Use("Create and Configure NLog Logger", 
             context => (IThuriaLogger) LogManager.GetLogger(context.ParentType == null ? context.RequestedName : context.ParentType.Name, typeof(NLogApplicationLogger)))
        .AlwaysUnique();

      For<IThuriaSerializerSettings>().Use<ThuriaDefaultJsonSerializerSettings>();
      For<IThuriaSerializer>().Use<ThuriaJsonSerializer>();

      For<IThuriaSettings>().Use<ThuriaSettings>()
                            .Singleton()
                            .Ctor<ThuriaSettingsType>("SettingsType").Is(ThuriaSettingsType.JsonFileEnvironment);
      For<IThuriaDatabaseSettings>().Use<ThuriaDatabaseSettings>()
                                    .Singleton();

      For<IThuriaNancySettings>().Use<ThuriaNancySettings>()
                                 .Singleton();
      For<INancyBootstrapper>().Use<NancyBootstrapper>();

      For<IThuriaStartable>().Use<HeliumActorSystem>()
                             .Singleton();
      For<IThuriaStoppable>().Use<HeliumActorSystem>()
                             .Singleton();
    }
  }
}
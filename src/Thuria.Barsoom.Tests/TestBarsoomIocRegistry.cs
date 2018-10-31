using StructureMap;

using NUnit.Framework;
using FluentAssertions;

using Thuria.Zitidar.Core;
using Thuria.Zitidar.Logging;
using Thuria.Zitidar.Structuremap;

namespace Thuria.Barsoom.Tests
{
  [TestFixture]
  public class TestBarsoomIocRegistry
  {
    [Test]
    public void Constructor()
    {
      //---------------Set up test pack-------------------
      //---------------Assert Precondition----------------
      //---------------Execute Test ----------------------
      var iocRegistry = new BarsoomIocRegistry();
      //---------------Test Result -----------------------
      iocRegistry.Should().NotBeNull();
    }

    [Test]
    public void Constructor_ShouldRegisterIThuriaIocContainer()
    {
      //---------------Set up test pack-------------------
      var container = new Container(expression =>
          {
            expression.AddRegistry<BarsoomIocRegistry>();
          });
      //---------------Assert Precondition----------------
      //---------------Execute Test ----------------------
      var iocContainer = container.GetInstance<IThuriaIocContainer>();
      //---------------Test Result -----------------------
      iocContainer.Should().NotBeNull();
      iocContainer.Should().BeOfType<StructuremapThuriaIocContainer>();
    }

    [Test]
    public void Constructor_ShouldRegisterIThuriaLogger()
    {
      //---------------Set up test pack-------------------
      var iocContainer = CreateIocContainer();
      //---------------Assert Precondition----------------
      //---------------Execute Test ----------------------
      var instance = iocContainer.GetInstance<IThuriaLogger>();
      //---------------Test Result -----------------------
      instance.Should().NotBeNull();
      instance.Should().BeOfType<NLogApplicationLogger>();
    }

    [Test]
    public void Constructor_ShouldRegisterIThuriaSettings()
    {
      //---------------Set up test pack-------------------
      var iocContainer = CreateIocContainer();
      //---------------Assert Precondition----------------
      //---------------Execute Test ----------------------
      var instance = iocContainer.GetInstance<IThuriaSettings>();
      //---------------Test Result -----------------------
      instance.Should().NotBeNull();
    }

    private IThuriaIocContainer CreateIocContainer()
    {
      var container = new Container(
        expression =>
          {
            expression.AddRegistry<BarsoomIocRegistry>();
          });

      var iocContainer = container.GetInstance<IThuriaIocContainer>();
      iocContainer.Should().NotBeNull();

      return iocContainer;
    }
  }
}

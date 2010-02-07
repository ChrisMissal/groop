using System;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;
using System.Collections;
using Groop.Core;
using Groop.Data;
using Groop.Website.Controllers;
using NUnit.Framework;

namespace Groop.UnitTests
{
    [TestFixture]
    public class WindsorTests
    {
        private static IWindsorContainer GetContainer()
        {
            IWindsorContainer container = new WindsorContainer("windsor.config.xml");

            typeof(HomeController)
                .Assembly.GetTypes()
                .Where(type => typeof (IController).IsAssignableFrom(type))
                .Where(type => !type.IsAbstract)
                .ForEach(type => container.AddComponent(type.Name.ToLower(), type));
            
            return container;
        }

        [Test]
        public void Can_resolve_IPathResolver()
        {
            var container = GetContainer();

            var resolver = container.Resolve<IXmlRepository>();

            Console.WriteLine(resolver.GetType());
        }

        [Test]
        public void Can_initiate_Windsor()
        {
            IWindsorContainer container = GetContainer();
            container.Kernel.GetAssignableHandlers(typeof(object))
                .ForEach(handler=>container.Resolve(handler.ComponentModel.Service));
        }
    }
}
using System;
using System.IO;
using Castle.Core;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace Groop.Website.Helpers
{
    /// <summary>
    /// Inversion of Control container access
    /// </summary>
    public class IoC
    {
        private static IWindsorContainer container;

        private static readonly object _lockDummy = new object();

        private static bool _initiliazed;

        public const string WindsorConfigFilename = @"windsor.config.xml";

        private static void EnsureInitialized()
        {
            if (!_initiliazed)
            {
                lock (_lockDummy)
                {
                    if (!_initiliazed)
                    {
                        var basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                        var configPath = Path.Combine(basePath, WindsorConfigFilename);
                        if (!File.Exists(configPath))
                        {
                            basePath = basePath + @"bin\";
                            configPath = Path.Combine(basePath, WindsorConfigFilename);
                        }

                        var configInterpreter = new XmlInterpreter(configPath);
                        InitializeWith(new WindsorContainer(configInterpreter));
                        _initiliazed = true;
                    }
                }
            }
        }

        public static void InitializeWith(IWindsorContainer container)
        {
            IoC.container = container;
            _initiliazed = true;
        }

        public static T Resolve<T>()
        {
            EnsureInitialized();
            return container.Resolve<T>();
        }

        public static T Resolve<T>(string key)
        {
            EnsureInitialized();
            return container.Resolve<T>(key);
        }

        public static void Register<Interface, Implementation>()
        {
            EnsureInitialized();
            Register<Interface, Implementation>(typeof(Interface).Name);
        }

        public static void Register<Interface, Implementation>(string key)
        {
            EnsureInitialized();
            container.AddComponent(key, typeof(Interface), typeof(Implementation));
        }

        public static void Register(string key, Type type, LifestyleType lifestyleType)
        {
            EnsureInitialized();
            container.AddComponentLifeStyle(key, type, lifestyleType);
        }

        public static IWindsorContainer GetContainer()
        {
            EnsureInitialized();
            return container;
        }

        public static void Reset()
        {
            if (container != null)
            {
                container.Dispose();
                container = null;
            }
        }
    }
}
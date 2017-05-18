using Autofac;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Local.Factory.Pages;

namespace CrossLayer.Autofac
{
    /// <summary>
    /// Autofac Container.
    /// </summary>
    public static class AutofacContainer
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        public static IContainer AContainer { get; private set; }

        /// <summary>
        /// Initializes the <see cref="AutofacContainer"/> class.
        /// </summary>
        static AutofacContainer()
        {
            AutofacContainerSauceLabs();
        }

        private static void AutofacContainerSauceLabs()
        {
            var buildContainer = new ContainerBuilder();
            buildContainer.RegisterType<LocalHomePage>().As<IHomePage>();
            buildContainer.RegisterType<LocalManagerPage>().As<IManagerPage>();
            buildContainer.RegisterType<LocalNewCustomerPage>().As<INewCustomerPage>();
            buildContainer.RegisterType<LocalCustomerRegisteredPage>().As<ICustomerRegisteredPage>();
            buildContainer.RegisterType<LocalSelectEditCustomerPage>().As<ISelectEditCustomerPage>();
            buildContainer.RegisterType<LocalEditCustomerPage>().As<IEditCustomerPage>();
            buildContainer.RegisterType<LocalNewAccountPage>().As<INewAccountPage>();

            AContainer = buildContainer.Build();
        }
    }
}

using Autofac;
using DocumentTracking.Infrastructure.Services;

namespace DocumentTracking.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailService>()
                .As<IEmailService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<IdentityService>()
                .As<IIdentityService>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<OrderRepository>()
            //    .As<IOrderRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();
        }
    }
}

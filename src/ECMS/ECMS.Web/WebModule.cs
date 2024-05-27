using Autofac;

namespace ECMS.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ProductCreateModel>().AsSelf();
        }

    }
}

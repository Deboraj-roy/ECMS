using Autofac;
using ECMS.Web.Areas.User.Models;

namespace ECMS.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductCreateModel>().AsSelf();
            builder.RegisterType<ProductDeleteModel>().AsSelf();
            builder.RegisterType<ProductDetailsModel>().AsSelf();
            builder.RegisterType<ProductListModel>().AsSelf();
            builder.RegisterType<ProductUpdateModel>().AsSelf();
        }

    }
}

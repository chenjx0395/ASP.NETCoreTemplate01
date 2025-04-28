using System.Reflection;
using Autofac;

namespace WebAPI.AutoFaceDI
{
    public class AutofacModuleRegister : Autofac.Module
    {
        // 重写AutoFace中的Load方法，从而实现注入的操作
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var appServices = Assembly.Load("Service");
            var appRepository = Assembly.Load("Repository");
            // 这里做了一个约定，服务层中的类都是以Service结尾，仓储项目中的类都是以Repository结尾
            builder.RegisterAssemblyTypes(appServices)
                .Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(appRepository)
                .Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }
    }
}

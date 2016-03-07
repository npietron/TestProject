using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.DataLayer.Repositories.Concrete;
using TestProject.Model;
using TestProject.Model.Helpers;
using TestProject.Services.REST.Abstract;
using TestProject.Services.REST.Concrete;
using TestProject.WebApi.Controllers;

namespace TestProject.WebApi
{
    public static class AutofacConfig
    {
        public static void RegisterTypes(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.Register<TestProjectDBContext>((context => new TestProjectDBContext(DbHelper.GetConnectionString())))
                .InstancePerLifetimeScope();

            #region Common



            #endregion

            #region Repositories

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MessageRepository>().As<IMessageRepository>().InstancePerLifetimeScope();

            #endregion

            #region Services

            builder.RegisterType<CustomUserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomPostService>().As<IPostService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomMessageService>().As<IMessageService>().InstancePerLifetimeScope();

            #endregion

            #region Controllers

            builder.RegisterType<UserController>().UsingConstructor(typeof(IUserService));
            builder.RegisterType<PostController>().UsingConstructor(typeof(IPostService));
            builder.RegisterType<MessageController>().UsingConstructor(typeof(IMessageService));

            #endregion

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            config.DependencyResolver = resolver;

        }
    }
}
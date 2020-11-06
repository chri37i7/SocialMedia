using Autofac;
using Microsoft.EntityFrameworkCore;

using SocialMedia.Containers;
using SocialMedia.DataAccess;
using SocialMedia.DataAccess.Base;
using SocialMedia.Entities.Models;
using SocialMedia.Entities.Models.Context;

namespace SocialMedia.IoC
{
    public class ContainerConfigurator
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<PostRepository>().As<IRepositoryBase<AspNetPosts>>();
            builder.RegisterType<SocialMediaContext>().As<DbContext>();

            IContainer container = builder.Build();
            AutofacContainer.Initialize(container);
        }
    }
}

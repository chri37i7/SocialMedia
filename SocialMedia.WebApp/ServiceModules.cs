using Autofac;
using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess;
using SocialMedia.DataAccess.Base;
using SocialMedia.Entities.Models;
using SocialMedia.Entities.Models.Context;

namespace SocialMedia.WebApp
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PostRepository>().As<IRepositoryBase<AspNetPosts>>();
            builder.RegisterType<SocialMediaContext>().As<DbContext>();
        }
    }
}
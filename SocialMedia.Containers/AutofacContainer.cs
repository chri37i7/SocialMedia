using Autofac;
using System;

namespace SocialMedia.Containers
{
    public static class AutofacContainer
    {
        private static bool initialized;
        private static IContainer instance;

        public static void Initialize(IContainer container)
        {
            if(container is null)
            {
                throw new ArgumentNullException();
            }

            instance = container;
            initialized = true;
        }

        public static IContainer Instance 
        {
            get 
            {
                if(!initialized)
                {
                    throw new InvalidOperationException("container was never initialized");
                }
                return instance;
            }
        }
    }
}
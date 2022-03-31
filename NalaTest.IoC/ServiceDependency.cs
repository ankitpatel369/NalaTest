using Microsoft.Extensions.DependencyInjection;
using NalaTest.Application.Interfaces;
using NalaTest.Application.Interfaces.Base;
using NalaTest.Application.Services;
using NalaTest.Application.Services.Base;

namespace NalaTest.IoC
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddSingleton<IWebRequestService, WebRequestService>();
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
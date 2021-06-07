using BookApi.Service.Abstractions;
using BookApi.Service.Impls;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookApi.Service
{
    public static class ServiceCollectionExtension
    {
        public static void AddBookService(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IDataService, DataService>();
        }

        public static void ConfigureAutoMap(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
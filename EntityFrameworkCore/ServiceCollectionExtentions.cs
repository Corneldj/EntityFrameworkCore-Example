using EntityFrameworkCore.Repositories.Internface;
using EntityFrameworkCore.Repositories.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EntityFrameworkCore
{
    /// <summary>
    /// We call this only if we want to do dependency injections
    /// </summary>
    public static class ServiceCollectionExtentions
    {
        /// <summary>
        /// This is a [Extention Method] 
        /// 
        /// Documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterContextInjection(this IServiceCollection services, Action<DbContextOptionsBuilder> options) => services
             .AddDbContext<SqlServerContext>(options);

        /// <summary>
        /// Register all the Repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterRepositoryInjections(this IServiceCollection services) => services
            .AddScoped<IStudentRepository, StudentRepository>()
            .AddScoped<ISubjectRepository, SubjectRepository>()
            
            ;
           

    }
}

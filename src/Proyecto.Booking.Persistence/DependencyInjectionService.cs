using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.Booking.Persistence.DataBase;
using Proyecto.Booking.Application.DataBase;

namespace Proyecto.Booking.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseService>(options => options.UseSqlServer(configuration.GetConnectionString("SQL")));
            services.AddScoped<IDataBaseService, DataBaseService>();
            return services;
        }
    }
}

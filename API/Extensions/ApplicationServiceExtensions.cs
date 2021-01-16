using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using API.Interfaces;
using API.Services;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddScoped<ITokenService, TokenService>();

      services.AddScoped<IUserRepository, UserRepository>();

      services.AddDbContext<DataContext>(options =>
      {
        options.UseSqlite(config.GetConnectionString("DefaultConnection"));
      });

      return services;
    }
  }
}
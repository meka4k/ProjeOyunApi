using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjeOyun.Application.Interfaces.Repositories;
using ProjeOyun.Persistence.Context;
using ProjeOyun.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Persistence
{
	public static class Registration
	{
		public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

		}
	}
}

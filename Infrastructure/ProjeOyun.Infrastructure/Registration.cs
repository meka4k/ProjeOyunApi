using Microsoft.Extensions.DependencyInjection;
using ProjeOyun.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Infrastructure;

public static class Registration
{
	public static void AddInfrastructure(this IServiceCollection services)
	{
		services.AddTransient<IMernisService, MernisService>();

	}
}
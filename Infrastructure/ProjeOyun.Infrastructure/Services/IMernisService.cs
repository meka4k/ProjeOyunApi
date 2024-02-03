using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Infrastructure.Services;

public interface IMernisService
{
	Task<bool> ValidateIdentityAsync(string nationalityId, string name, string surname, DateTime dateTime);
}

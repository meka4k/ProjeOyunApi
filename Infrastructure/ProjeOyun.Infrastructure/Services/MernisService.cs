using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Infrastructure.Services;

public class MernisService : IMernisService
{
	public async Task<bool> ValidateIdentityAsync(string nationalityId, string name, string surname, DateTime dateTime)
	{
		var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

		var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(nationalityId),name,surname,dateTime.Year);

		if (response != null && response.Body != null && response.Body.TCKimlikNoDogrulaResult != null)
		{
			return response.Body.TCKimlikNoDogrulaResult;
		}
		else
		{
			return false;
		}
	}
}

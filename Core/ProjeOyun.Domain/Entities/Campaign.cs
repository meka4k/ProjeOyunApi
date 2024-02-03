using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Domain.Entities
{
	public class Campaign
	{
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public decimal DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }


		public ICollection<Sale> Sales { get; set; }
	}
}

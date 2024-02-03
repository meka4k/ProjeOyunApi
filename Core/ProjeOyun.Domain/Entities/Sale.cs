using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Domain.Entities
{
	public class Sale
	{
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Price { get; set; }

		public int PlayerId { get; set; }
		public Player Player { get; set; }

		public int GameId { get; set; }
		public Game Game { get; set; }


		public int? CampaignId { get; set; }
		public Campaign Campaign { get; set; }
	}
}

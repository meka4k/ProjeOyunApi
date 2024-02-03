using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Application.Dto
{
	public class PlayerDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string IdentityNo { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}

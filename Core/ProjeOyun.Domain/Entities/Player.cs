using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNo { get; set; }
    public DateTime DateOfBirth { get; set; }

	
	public ICollection<Sale> Sales { get; set; }


}

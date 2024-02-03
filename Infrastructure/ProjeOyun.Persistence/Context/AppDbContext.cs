using Microsoft.EntityFrameworkCore;
using ProjeOyun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Persistence.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Game> Games { get; set; }
	public DbSet<Player> Players { get; set; }
	public DbSet<Campaign> Campaigns { get; set; }
	public DbSet<Sale> Sales { get; set; }
}

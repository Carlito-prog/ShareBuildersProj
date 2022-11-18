using System;
using Microsoft.EntityFrameworkCore;
using ShareBuilderProj.Data.Models;

namespace ShareBuilderProj.Data
{
	public class StationDbContext : DbContext
	{
		public StationDbContext(DbContextOptions<StationDbContext> options)
			: base(options)
		{
		}
			public DbSet<StationModel> Stations { get; set; }
			public DbSet<UserModel> Users { get; set; }
	}
}


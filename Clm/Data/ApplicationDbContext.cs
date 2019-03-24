using System;
using System.Collections.Generic;
using System.Text;
using Clm.Models.Unit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewAgeClm.Utility;

namespace Clm.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Units> Units { get; set; }
		public DbSet<Types> Types { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//seeded data
			base.OnModelCreating(builder);
			builder.Entity<Types>()
				.HasData(new Types
				{
					IsEnabled = true,
					CodeId = 1,
					Name = StaticData.DefaultDbValueGlobalProject
				}, new Types
				{
					IsEnabled= true,
					CodeId = 2,
					Name = StaticData.DefaultDbValueLocalProject
				}
				);
		}

	}
}

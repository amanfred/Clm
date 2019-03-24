using System;
using System.Collections.Generic;
using System.Text;
using Clm.Models.Unit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
	}
}

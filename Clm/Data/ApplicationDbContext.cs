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
		public DbSet<Statuses> Statuses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//seeded data
			base.OnModelCreating(builder);
			builder.Entity<Types>()
				.HasData(new Types
				{
					IsEnabled = true,
					CodeId = 1,
					Name = StaticData.DefaultDbValueTypeGlobalProject
				}, new Types
				{
					IsEnabled= true,
					CodeId = 2,
					Name = StaticData.DefaultDbValueTypeLocalProject
				}, new Types
				{
					IsEnabled = true,
					CodeId = 3,
					Name = StaticData.DefaultDbValueTypeEpic
				}, new Types
				{
					IsEnabled = true,
					CodeId = 4,
					Name = StaticData.DefaultDbValueTypeUserStory
				}, new Types
				{
					IsEnabled = true,
					CodeId = 5,
					Name = StaticData.DefaultDbValueTypeSubTask
				}, new Types
				{
					IsEnabled = true,
					CodeId = 6,
					Name = StaticData.DefaultDbValueTypeTask
				}
				);

			base.OnModelCreating(builder);
			builder.Entity<Statuses>()
				.HasData(new Statuses
				{
					IsEnabled = true,
					CodeId = 1,
					Name = StaticData.DefaultDbValueStatusBacklog
				}, new Statuses
				{
					IsEnabled = true,
					CodeId = 2,
					Name = StaticData.DefaultDbValueStatusToDo
				}, new Statuses
				{
					IsEnabled = true,
					CodeId = 3,
					Name = StaticData.DefaultDbValueStatusInProgress
				}, new Statuses
				{
					IsEnabled = true,
					CodeId = 4,
					Name = StaticData.DefaultDbValueStatusReadyToQA
				}, new Statuses
				{
					IsEnabled = true,
					CodeId = 5,
					Name = StaticData.DefaultDbValueStatusInTest
				}, new Statuses
				{
					IsEnabled = true,
					CodeId = 6,
					Name = StaticData.DefaultDbValueStatusReadyToRelease
				}, new Statuses
				{
					IsEnabled = true,
					CodeId = 7,
					Name = StaticData.DefaultDbValueStatusDone
				}
				);
		}

	}
}

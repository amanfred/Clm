﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clm.Models.Unit
{
	public class Units
	{
		public int Id { get; set; }

		[Required, StringLength(200, MinimumLength = 5)]
		public string Name { get; set; }

		public string Description { get; set; }

		public int ParentId { get; set; }

	}
}

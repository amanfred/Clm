﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

		[Required]
		public int ParentId { get; set; }

		public int TypeCodeId { get; set; }

		[ForeignKey("TypeCodeId")]
		public virtual Types Types { get; set; }

		public int StatusCodeId { get; set; }

		[ForeignKey("StatusCodeId")]
		public virtual Statuses Statuses { get; set; }
	}
}

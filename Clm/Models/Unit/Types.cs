using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clm.Models.Unit
{
	public class Types
	{
		public int Id { get; set; }
		[Required]
		public int CodeId { get; set; }
		[Required, StringLength(20, MinimumLength = 2)]
		public string Name { get; set; }
	}
}

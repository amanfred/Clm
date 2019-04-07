using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clm.Models.Unit
{
	public class Severities
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None), Key, Required]
		public int CodeId { get; set; }

		[Required, StringLength(20, MinimumLength = 2)]
		public string Name { get; set; }

		[Required]
		public bool IsEnabled { get; set; }
	}
}

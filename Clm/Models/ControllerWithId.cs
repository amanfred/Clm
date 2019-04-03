using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clm.Models
{
	public class ControllerWithId
	{
		public int Id { get; set; }
		public string ControllerName { get; set; }
		public bool ShowDetails { get; set; }

		public ControllerWithId()
		{
			ShowDetails = false;
		}
	}
}

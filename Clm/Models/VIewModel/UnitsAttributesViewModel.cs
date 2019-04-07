using Clm.Models.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clm.Models.VIewModel
{
	public class UnitsAttributesViewModel
	{
		public Units Unit { get; set; }

		public IEnumerable<Units> Units { get; set; }

		public IEnumerable<Types> Types { get; set; }

		public IEnumerable<Statuses> Statuses { get; set; }

		public IEnumerable<Severities> Severities { get; set; }

		public IEnumerable<Priorities> Priorities { get; set; }

		public string ParentName { get; set; }


	}
}

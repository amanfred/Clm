﻿using Clm.Models.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clm.Models.VIewModel
{
	public class UnitsAttributesViewModel
	{
		public Units Units { get; set; }

		public IEnumerable<Types> Types { get; set; }

		public IEnumerable<Statuses> Statuses { get; set; }
	}
}

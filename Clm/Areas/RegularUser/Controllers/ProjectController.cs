using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clm.Data;
using Clm.Models.VIewModel;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Clm.Areas.RegularUser.Controllers
{
	[Area("RegularUser")]
    public class ProjectController : Controller
    {
		private readonly ApplicationDbContext _db;
		private readonly HostingEnvironment _hostingEnvironment;

		[BindProperty]
		public UnitsAttributesViewModel UnitsAttributesViewModel { get; set; }

		public ProjectController(ApplicationDbContext db, HostingEnvironment he)
		{
			this._db = db;
			this._hostingEnvironment = he;
			UnitsAttributesViewModel = new UnitsAttributesViewModel
			{
				Types = _db.Types.ToList(),
				Statuses = _db.Statuses.ToList(),
				Units = new Models.Unit.Units()
			};

		}

		public IActionResult Index(int id)
        {
			var units = _db.Units.Where(m => m.Id == id).ToList();
			if (units == null || units.Count == 0)
				return NotFound();
			if (units.Count > 1)
				return BadRequest();
			return View(units[0]);
		}

	
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clm.Data;
using Clm.Models.VIewModel;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using NewAgeClm.Utility;

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

	/*	public IActionResult Index(int id)
		{
			var units = _db.Units.Where(m => m.Id == id).ToList();
			var otherUnits = _db.Units.Where(m => m.ParentId == id).ToList();
			otherUnits.Add(units[0]);


			if (units == null || units.Count == 0)
				return NotFound();			
			return View(otherUnits);
		}*/

		//GET method for adding a story to project
		public IActionResult Create(int id)
		{
			
			UnitsAttributesViewModel.Types = UnitsAttributesViewModel.Types
				.Where(m =>
				m.Name != StaticData.DefaultDbValueTypeGlobalProject &&
				m.Name != StaticData.DefaultDbValueTypeLocalProject &&
				m.Name != StaticData.DefaultDbValueTypeSubTask);
			
			UnitsAttributesViewModel.Statuses = UnitsAttributesViewModel.Statuses
				.Where(m =>
				m.Name == StaticData.DefaultDbValueStatusBacklog);
			UnitsAttributesViewModel.Units.Id = id;
			return View(UnitsAttributesViewModel);
		}

		//Http POST create new unit
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task <IActionResult> AddUnit(int id)
		{
			if(ModelState.IsValid)
			{
				UnitsAttributesViewModel.Units.ParentId = id;
				_db.Add(UnitsAttributesViewModel.Units);
				await _db.SaveChangesAsync();

				return RedirectToAction("Create", id);
			}

			else
			{
				return BadRequest();
			}
		}
    }
}
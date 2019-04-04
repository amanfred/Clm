using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clm.Data;
using Clm.Models.Unit;
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
				Unit = new Units()
			};

		}
		/*
		public IActionResult Index(int id)
		{
			var units = _db.Units.Where(m => m.Id == id).ToList();
			if (units == null || units.Count == 0)
				return NotFound();
			if (units.Count > 1)
				return BadRequest();
			return View(units[0]);
		}
		*/
		public async Task<IActionResult> Index(int id, string sortOrder)
		{
			//define sort order options
			ViewData[StaticData.ActionValueNameSortParameter] = String.IsNullOrEmpty(sortOrder) ? StaticData.ActionValueNameDesc : String.Empty;

			//We get the project
			UnitsAttributesViewModel.Unit = await _db.Units.FindAsync(id);			

			//These are all the project's children
			UnitsAttributesViewModel.Units = _db.Units.Where(m => m.ParentId == id).ToList();

			if (UnitsAttributesViewModel.Unit == null)
				return NotFound();

			switch (sortOrder)
			{
				case StaticData.ActionValueNameDesc:
					UnitsAttributesViewModel.Units = UnitsAttributesViewModel.Units.OrderByDescending(s => s.Name);
					break;
				default:
					UnitsAttributesViewModel.Units = UnitsAttributesViewModel.Units.OrderBy(s => s.Name);
					break;
			}

			return View(UnitsAttributesViewModel);
		}

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
			UnitsAttributesViewModel.Unit.Id = id;
			return View(UnitsAttributesViewModel);
		}

		//Http POST create new unit
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task <IActionResult> AddUnit(int id)
		{
			if(ModelState.IsValid)
			{
				UnitsAttributesViewModel.Unit.ParentId = id;
				_db.Add(UnitsAttributesViewModel.Unit);
				await _db.SaveChangesAsync();

				return RedirectToAction("Create", id);
			}

			else
			{
				return BadRequest();
			}
		}

		//GET method for edit
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || id < 0)
				return NotFound();

			var unit = await _db.Units.FindAsync(id);

			if (unit == null)
				return NotFound();

			var type = unit.Types.Name;
			switch (type)
			{
				case StaticData.DefaultDbValueTypeEpic:
					UnitsAttributesViewModel.Types = UnitsAttributesViewModel.Types
					.Where(m =>
					m.Name != StaticData.DefaultDbValueTypeGlobalProject &&
					m.Name != StaticData.DefaultDbValueTypeLocalProject &&
					m.Name != StaticData.DefaultDbValueTypeSubTask);
					break;

				default:
					break;
			}

			UnitsAttributesViewModel.Unit = unit;
			
			return View(this.UnitsAttributesViewModel);
		}

		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditSubUnit(int? id)
		{
			if (ModelState.IsValid)
			{
				var projectFromDb = _db.Units.Where(m => m.Id == UnitsAttributesViewModel.Unit.Id).FirstOrDefault();
				projectFromDb.Name = UnitsAttributesViewModel.Unit.Name;
				projectFromDb.StatusCodeId = UnitsAttributesViewModel.Unit.StatusCodeId;
				projectFromDb.TypeCodeId = UnitsAttributesViewModel.Unit.TypeCodeId;
				projectFromDb.Description = UnitsAttributesViewModel.Unit.Description;
				await _db.SaveChangesAsync();
				var s = String.Empty;
				return RedirectToAction(nameof(Index), new {id, String.Empty });
				
			}
			return BadRequest();
		}
	}
}
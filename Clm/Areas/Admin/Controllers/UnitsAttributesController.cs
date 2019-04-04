using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clm.Data;
using Clm.Models.Unit;
using Clm.Models.VIewModel;
using Microsoft.AspNetCore.Mvc;

namespace Clm.Areas.Admin.Controllers
{
	[Area("Admin")] //always add area name
    public class UnitsAttributesController : Controller
    {
		private readonly ApplicationDbContext _db;

		public UnitsAttributesViewModel UnitsAttributesVM;

		public UnitsAttributesController(ApplicationDbContext db)
		{
			this._db = db;
			UnitsAttributesVM = new UnitsAttributesViewModel
			{
				Unit = new Units(), //instance of units
				Types = db.Types.ToList(), //get types from the database
				Statuses = db.Statuses.ToList() //get statuses from the database
			};
		}

		public IActionResult Index()
        {
            return View(UnitsAttributesVM);
        }
    }
}
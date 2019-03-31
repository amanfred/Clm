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
    public class UnitsAttributesController : Controller
    {
		private readonly ApplicationDbContext _db;

		public UnitsAttributesViewModel UnitsAttributesVM;

		public UnitsAttributesController(ApplicationDbContext db)
		{
			this._db = db;
			UnitsAttributesVM = new UnitsAttributesViewModel
			{
				Units = new Units(),
				Types = db.Types.ToList(),
				Statuses = db.Statuses.ToList()
			};
		}

		public IActionResult Index()
        {
            return View(UnitsAttributesVM);
        }
    }
}
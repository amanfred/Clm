﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clm.Data;
using Clm.Models.Unit;
using Clm.Models.VIewModel;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Clm.Areas.PowerUser.Controllers
{
	[Area("PowerUser")]
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

        public IActionResult Index()
        {
			
			var projects = _db.Units.Where(m => m.ParentId == -1).ToList();
            return View(projects);
			//var projects = await _db.Units
			
			//return View(projects);
		}

		// GET: Status/Create
		public IActionResult Create()
		{
			return View(UnitsAttributesViewModel);
		}

		// POST: Status/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateProject()
		{
			try
			{
				if (ModelState.IsValid)
				{
					UnitsAttributesViewModel.Units.ParentId = -1;
					_db.Add(UnitsAttributesViewModel.Units);
					await _db.SaveChangesAsync();

					//Saving Image
					//root path
					string webRootPath = _hostingEnvironment.WebRootPath;
					//rename the image to projects id
					var files = HttpContext.Request.Form.Files;
					var projectsFromDb = _db.Units.Find(UnitsAttributesViewModel.Units.Id);
					/*
										if(files.Count > 0)
										{
											//file (image) has been uploaded
											//find the path of upload
											var upload = Path.Combine(webRootPath, StaticData.ImageFolder); //exact loacation
																											//find extension
											var extension = Path.GetExtension(files[0].FileName);
											using (var fileStream = new FileStream(Path.Combine(upload, ProjectAttributesVM.Projects.Id + extension), FileMode.Create))
											{
												files[0].CopyTo(fileStream);
											}

											projectsFromDb.Image = @"\" + StaticData.ImageFolder + @"\" + ProjectAttributesVM.Projects.Id + extension;
										}
										else
										{
											//dummy image or do nothing...
										}
										*/
					await _db.SaveChangesAsync();
					//return RedirectToAction("Index", "Project", new { area = "RegularUser" });
					return RedirectToAction(nameof(Index));
				}
				return View(UnitsAttributesViewModel);
			}
			catch
			{
				return View();
			}
		}
	}
}
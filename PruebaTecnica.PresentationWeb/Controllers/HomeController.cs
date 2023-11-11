using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Data;
using PruebaTecnica.Domain;
using PruebaTecnica.PresentationWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.PresentationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            CandidateDbContext candidateDbContext = new CandidateDbContext();
            Candidate candidate = new Candidate()
            {
                Birthdate = DateTime.Now,
                Email = "Coor2e@mail.com",
                InsertDate = DateTime.Now,
                Name = "Home",
                Surname = "Home"
            };
            CandidateExperience candidateExperience = new CandidateExperience()
            {
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now,
                Candidate = candidate,
                Company = "Compañia",
                Description = "Descripcion",
                InsertDate = DateTime.Now,
                Job = "Co",
                Salary = 1000
            };
            await candidateDbContext.AddAsync(candidateExperience);
            await candidateDbContext.SaveChangesAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

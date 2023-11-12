using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Features.Candidates.Queries.GetCandidatesList;
using PruebaTecnica.PresentationWeb.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PruebaTecnica.PresentationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetCandidatesListQuery();
            var list = await mediator.Send(query);
            return View(list);
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

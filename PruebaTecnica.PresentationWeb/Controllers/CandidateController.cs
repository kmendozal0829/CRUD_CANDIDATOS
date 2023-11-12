using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Features.Candidates.Commands.CreateCandidate;
using PruebaTecnica.Application.Features.Candidates.Commands.DeleteCandidate;
using PruebaTecnica.Application.Features.Candidates.Commands.EditCandidate;
using PruebaTecnica.Application.Features.Candidates.Queries.GetCandidate;
using PruebaTecnica.Application.Features.Candidates.Queries.GetCandidatesList;
using System;
using System.Threading.Tasks;

namespace PruebaTecnica.PresentationWeb.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IMediator mediator;

        public CandidateController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCandidateCommand model)
        {
            try
            {
                var r = await mediator.Send(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        #endregion

        #region Read
        // GET: CandidateController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var query = new GetCandidateQuery(id);
            var candidate = await mediator.Send(query);
            return View(candidate);
        }

        public async Task<ActionResult> Index()
        {
            var query = new GetCandidatesListQuery();
            var listCandidates = await mediator.Send(query);
            return View(listCandidates);
        }


        #endregion

        #region Update
        public async Task<ActionResult> Edit(int id)
        {
            var query = new GetCandidateQuery(id);
            var candidate = await mediator.Send(query);
            return View(candidate);
        }

        // POST: CandidateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditCandidateCommand model)
        {
            try
            {
                var r = await mediator.Send(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: CandidateController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var query = new GetCandidateQuery(id);
            var candidate = await mediator.Send(query);
            return View(candidate);
        }

        // POST: CandidateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var command = new DeleteCandidateCommand(id);
                var r = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion


    }
}

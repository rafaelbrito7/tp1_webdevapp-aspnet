using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;


namespace TP1_DevWebAppASPNET.Controllers
{
    public class FriendsBirthdayController : Controller
    {
        private AlunoRepository Repository { get; set; }

        public FriendsBirthdayController()
        {
            this.Repository = new AlunoRepository();
        }

        // GET: Lista2Controller
        public ActionResult Index()
        {
            return View(this.Repository.GetAll());
        }

        // GET: AlunoController/Details/5
        public ActionResult Details(int id)
        {
            var aluno = this.Repository.GetAlunoById(id);

            return View(aluno);
        }

        // GET: AlunoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: AlunoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlunoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(int id)
        {
            var aluno = this.Repository.GetAlunoById(id);

            return View(aluno);
        }

        // POST: AlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Aluno aluno)
        {
            try
            {
                this.Repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

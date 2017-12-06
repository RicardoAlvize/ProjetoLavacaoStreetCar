using ProjetoLavacaoStreetCar.Models;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoLavacaoStreetCar.Controllers
{
    public class FuncionarioController : Controller
    {

        private ApplicationDbContext _context;


        public FuncionarioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult Index()
        {

            var funcionario = _context.Funcionarios.ToList();
            if (User.IsInRole(RoleName.CanManageCustomers))
                return View(funcionario);

            return View("ReadOnlyIndex", funcionario);

            
        }
        [Authorize(Roles = RoleName.CanManageFuncionarios)]
        public ActionResult New()
        {
            var funcionario = new Funcionario();

            return View("FuncionarioForm", funcionario);
        }

        [HttpPost] // só será acessada com POST
        [Authorize(Roles = RoleName.CanManageFuncionarios)]
        public ActionResult Save(Funcionario funcionario) // recebemos um cliente
        {

            if (!ModelState.IsValid)
            {
                return View("FuncionarioForm", funcionario);
            }

            if (funcionario.Id == 0)
            {
                // armazena o cliente em memória
                _context.Funcionarios.Add(funcionario);
            }
            else
            {
                var funcionarioInDb = _context.Funcionarios.Single(c => c.Id == funcionario.Id);


                funcionarioInDb.Nome = funcionario.Nome;
                funcionarioInDb.Matricula = funcionario.Matricula;
                funcionarioInDb.Horario = funcionario.Horario;


            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        [Authorize(Roles = RoleName.CanManageFuncionarios)]
        public ActionResult Edit(int id)
        {
            var funcionario = _context.Funcionarios.SingleOrDefault(c => c.Id == id);

            if (funcionario == null)
                return HttpNotFound();


            return View("FuncionarioForm", funcionario);
        }
        [Authorize(Roles = RoleName.CanManageFuncionarios)]
        public ActionResult Delete(int id)
        {
            var funcionario = _context.Funcionarios.SingleOrDefault(c => c.Id == id);

            if (funcionario == null)
                return HttpNotFound();

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}
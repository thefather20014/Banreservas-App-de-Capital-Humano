using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dieta.Models;
using System.Web.Security;

namespace Dieta.Controllers
{
	public class AccountsController : Controller
    {

		private ProcesosDAEntities db = new ProcesosDAEntities();
		// GET: Accounts
		public ActionResult Login()
        {
            return View();
        }

		public bool IsValid(USUARIO user)
		{
			bool valid = db.USUARIOS.Any(x => x.USUARIO1 == user.USUARIO1 && x.PASSWORD == user.PASSWORD);
			return valid;
		}
		[HttpPost]
		public ActionResult Login(USUARIO user, string ReturnUrl)
		{
			if (IsValid(user))
			{
				FormsAuthentication.SetAuthCookie(user.USUARIO1, false);
				return RedirectToAction("Index", "BENEFICIARIOS");
			}
			else
			{
				return View("Login");
			}
		}
		public ActionResult LOgOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Login", "Accounts");
		}
		[Authorize]
		public ActionResult Report()
		{
			return Redirect("~/Reports/WebForm.aspx");
		}
		[Authorize]
		public ActionResult Report2()
		{
			return Redirect("~/Reports/WebForm2.aspx");
		}
	}
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSecurityDemo.Repositories;
using WebSecurityDemo.ViewModels;

namespace WebSecurityDemo.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly RoleRepository _roleRepo;

        public RoleController(ILogger<RoleController> logger,
                              RoleRepository roleRepo)
        {
            _logger = logger;
            _roleRepo = roleRepo;
        }

        public IActionResult Index()
        {
            List<RoleVM> roleVM = _roleRepo.GetAllRoles();
            return View(roleVM);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _roleRepo.CreateRole(roleVM.RoleName);

                if (isSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Role creation failed." +
                                             " The role may already exist.");
                }
            }
            return View(roleVM);
        }

        public RoleRepository Get_roleRepo()
        {
            return _roleRepo;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                TempData["Message"] = "Role name is required.";
                return RedirectToAction(nameof(Index));
            }

            bool success = _roleRepo.DeleteRole(roleName);

            string message = success
                ? $"Role '{roleName}' was deleted."
                : $"Failed to delete role: {roleName}";

            return RedirectToAction(nameof(Index), new { message });
        }
    }
}



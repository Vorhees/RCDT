using System.Collections.Generic;
using RCDT.Models;
using RCDT.Services;
using Microsoft.AspNetCore.Mvc;

namespace RCDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly AdminUserService _adminUserService;

        public AdminUserController(AdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }

        [HttpGet]
        public ActionResult<List<AdminUser>> Get()
        {
            return _adminUserService.GetAdminUsers();
        }

        [HttpGet("{id:length(24)}", Name = "GetAdminUser")]
        public ActionResult<AdminUser> Get(string id)
        {
            var adminUser = _adminUserService.GetAdmin(id);

            if (adminUser == null)
            {
                return NotFound();
            }

            return adminUser;
        }

        [HttpPost]
        public ActionResult<AdminUser> Create(AdminUser adminUser)
        {
            _adminUserService.Create(adminUser);

            return CreatedAtRoute("GetAdminUser", new { id = adminUser.Id.ToString() }, adminUser);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, AdminUser adminUserIn)
        {
            var adminUser = _adminUserService.GetAdmin(id);

            if (adminUser == null)
            {
                return NotFound();
            }

            _adminUserService.Update(id, adminUserIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var adminUser = _adminUserService.GetAdmin(id);

            if (adminUser == null)
            {
                return NotFound();
            }

            _adminUserService.Remove(adminUser.Id);

            return NoContent();
        }
    }
}
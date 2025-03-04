﻿using ASP_Project_BLL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project_PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {

            var data = roleManager.Roles;
            return View(data);
        }

        public IActionResult CreateRole()
        {

           
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole() {

                    Name = model.RoleName
                
                };

                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }



            return View(model);
        }


        public async Task< IActionResult> EditRole(string Id)
        {
            var data = await roleManager.FindByIdAsync(Id);

            var role = new EditRoleVM() { 
            Id=data.Id,
            RoleName=data.Name
            
            };

            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM model)
        {
            if (ModelState.IsValid) {
                var data = await roleManager.FindByIdAsync(model.Id);
                data.Name = model.RoleName;

                var result = await roleManager.UpdateAsync(data);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteRole(string Id)
        {
            var data = await roleManager.FindByIdAsync(Id);
            var role = new EditRoleVM() {
                Id = data.Id,
                RoleName = data.Name
            };

            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(EditRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var data = await roleManager.FindByIdAsync(model.Id);
                data.Name = model.RoleName;

                var result = await roleManager.DeleteAsync(data);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }

            return View(model);
        }
    }
}

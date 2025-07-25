﻿using AutoMapper;
using CRUDUsingEFCoreCodeFirst.Models;
using EFCoreCodeFirst.Models;
using EFCoreCodeFirst.Models.Entities;
using EFCoreCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Controllers
{
    public class UsersController : Controller
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMyService _myService;
        private readonly IMyService _myService1;


        public UsersController(ProductDbContext dbContext, IMapper mapper,
            IMyService myService, IMyService myService1)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _myService = myService;
            _myService1 = myService1;
        }

        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.InstanceCount = _myService.InstanceCount;
            ViewBag.InstanceCount1 = _myService1.InstanceCount;

            var users = _dbContext.Users.ToList();

            var usersViewModel = _mapper.Map<List<UserViewModel>>(users); 
            // User and View expecting UserViewModel
            return View(usersViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var dbUser = _mapper.Map<User>(user); // from userViewModel to User
                _dbContext.Users.Add(dbUser);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var user = _dbContext.Users.FirstOrDefault(c => c.Id == id);
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var user = _dbContext.Users.FirstOrDefault(c => c.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            try
            {
                _dbContext.Users.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
           var user = _dbContext.Users.FirstOrDefault(c => c.Id == id);
            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(c => c.Id == id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

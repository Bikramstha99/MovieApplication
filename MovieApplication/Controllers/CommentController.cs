using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;
using MovieApplication.Repository.Implementations;
using MovieApplication.Repository.Interfaces;

namespace MoviesCRUD.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IComment _iComment;

        public CommentController(UserManager<IdentityUser> userManager, IComment iComment)
        {
            _userManager = userManager;
            _iComment = iComment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var comment = _iComment.GetAllComment();
            return View(comment);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddComment addcomment)
        {
            _iComment.AddComment(addcomment);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var comment = _iComment.GetCommentById(Id);
            return View(comment);
        }

        [HttpPost]
        public IActionResult Edit(UpdateComment updatecomment)
        {
            _iComment.UpdateComment(updatecomment);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie= _iComment.GetCommentById(id);
            return View(movie);

        }
        [HttpPost]
        public IActionResult Delete(UpdateComment deletecomment)
        {
            _iComment.deleteComment(deletecomment);

            return RedirectToAction("Index");
        }

    }
}

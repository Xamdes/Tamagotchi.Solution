using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
  public class TamagotchiController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View(Lifeform.GetAll());
    }

    [HttpGet("/life/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/life")]
    public ActionResult Create(string name)
    {
      Lifeform newLife = new Lifeform(name);
      newLife.Save();
      return RedirectToAction("Index");
    }

    [HttpPost("/life/delete")]
    public ActionResult DeleteAll()
    {
      Lifeform.ClearAll();
      return View();
    }

    [HttpGet("/life/{id}")]
    public ActionResult Details(int id)
    {
        Lifeform life = Lifeform.Find(id);
        return View(life);
    }
  }
}

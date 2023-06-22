using BulkyFormWeb.Data;
using BulkyFormWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BulkyFormWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; // контекст БД приложения
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //ПОЛУЧИТЬ
        public IActionResult Create()
        {
            return View();
        }
        //ДОБАВИТЬ
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Порядок не может совпадать с Именем"); //проверка на совпадение
            }
            if (ModelState.IsValid) //Проверка корректности ввода
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Успешно создано";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //РЕДАКТИРОВАТЬ
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }
            var categoryFromdDb = _db.Categories.Find(id); // пытается найти элемент в первичном ключе таблицы, находит категорию на основе и назначает идентификатор перменной
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id); *
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); *способы извлечения категории из базы данных на основе id
            if (categoryFromdDb == null)
            {
                return NotFound();
            }
            return View(categoryFromdDb);
        }
        //РЕДАКТИРОВАТЬ
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Порядок не может совпадать с Именем"); //проверка на совпадение
            }
            if (ModelState.IsValid) //Проверка ввода данных
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Успешно изменено";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //УДАЛИТЬ
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromdDb = _db.Categories.Find(id); // пытается найти элемен в первичном ключе таблицы, находит категорию на основе и назначает идентификатор перменной
            if (categoryFromdDb == null)
            {
                return NotFound();
            }
            return View(categoryFromdDb);
        }
        //УДАЛИТЬ
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Успешно удалено";
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly SetBookDAL _dal;

        public BookController(SetBookDAL dal)
        {
            _dal = dal;
        }

        public IActionResult BookList(string bookidSearch,string booknameSearch)
        {
            var book = _dal.GetAllBook();
            if (!string.IsNullOrEmpty(bookidSearch))
            {
               
                book = book
                   .Where(s => s.BookId.ToString().Contains(bookidSearch))
                   .ToList();
            }
            if (!string.IsNullOrEmpty(booknameSearch))
                {
              
               
                book = book
                  .Where(s => s.BookName.ToString().Contains(booknameSearch))
                  .ToList();
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult AddBook(int? Id)
        {
            BookModel books = new BookModel();
            books = _dal.GetBookById(Id);
            return View(books);
            
        }

        [HttpPost]
        public IActionResult AddBook(BookModel model)
        {
            _dal.SetBook(model);
            return RedirectToAction("BookList");
        }

        public IActionResult Delete(int Id)
        {
            _dal.DeleteBookById(Id); // Call DAL to delete
            return RedirectToAction("BookList"); ;
            
        }
    }
}

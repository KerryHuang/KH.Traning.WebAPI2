using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [RoutePrefix("books")]
    public class BooksController : ApiController
    {
        private BookAPIContext db = new BookAPIContext();

        // GET: api/Books
        [Route("")]
        public IQueryable<Book> GetBooks()
        {
            return db.Books;
        }

        // GET: api/Books/5
        [Route("{id:int}")]
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [Route("{genre}")]
        public IHttpActionResult GetBookByGenre(string genre)
        {
            var books = db.Books.Include(b => b.Author)
                .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));

            return Ok(books);
        }


        //[Route("{genre}")]
        //public IHttpActionResult GetBookByGenre(Book book)
        //{
        //    var books = db.Books.Include(b => b.Author)
        //        .Where(b => b.Genre.Equals(book.Genre, StringComparison.OrdinalIgnoreCase));

        //    return Ok(books);
        //}

        [Route("date/{*pubdate:datetime}")]
        //[Route("date/{pubdate:datetime:regex(\\d{2}/\\d{2}/\\d{4})}")]
        public IHttpActionResult Get(DateTime pubdate)
        {
            var books = db.Books.Include(b => b.Author)
                .Where(b => DbFunctions.TruncateTime(b.PublishDate)
                         == DbFunctions.TruncateTime(pubdate));

            return Ok(books);
        }

        [Route("date/{day:int:min(1):max(31)/{month:int:min(1):max(12)}/{year:int}}")]
        public IHttpActionResult GetByDate(int day, int month, int year)
        {
            DateTime pubdate = new DateTime(year, month, day);
            var books = db.Books.Include(b => b.Author)
                .Where(b => DbFunctions.TruncateTime(b.PublishDate)
                         == DbFunctions.TruncateTime(pubdate));

            return Ok(books);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.BookId)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.BookId == id) > 0;
        }
    }
}
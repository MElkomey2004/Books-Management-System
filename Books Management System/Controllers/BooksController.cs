using Books_Management_System.DTOs;
using Books_Management_System.Models;
using Books_Management_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books_Management_System.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class BooksController : ControllerBase
	{
		private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [HttpPost]
		public async Task<IActionResult> CreateBook(BookDto book)
		{
			if (book == null)
			{
				return BadRequest();
			}

			await _bookRepository.CreateBook(book);



			return Ok("The Book is created Successfully");
		}


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var books  = await _bookRepository.GetAll();

			if (books == null)
				return NotFound();

			return Ok(books);	
		}

		[HttpGet]
		[Route("{id:int}")]

		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var book = await _bookRepository.GetById(id);
			if (book == null)
				return NotFound();

			return Ok(book); 

		}


		[HttpPut]
		[Route("{id:int}")]

		public async Task<IActionResult> Update([FromRoute] int id , [FromBody] BookDto book)
		{
			var bookFromdb = await  _bookRepository.Update(id, book);
			if (bookFromdb == null)
				return NotFound();

			return Ok(bookFromdb);
		}


		[HttpDelete]
		[Route("{id:int}")]

		public async Task<IActionResult> Delete([FromRoute] int id)
		{

			var bookFromdb = await _bookRepository.GetById(id);
			if (bookFromdb == null)
				return NotFound();

			await _bookRepository.Delete(id);

			return Ok("The book Will Deleted Successfully");
		
		}




	}
}

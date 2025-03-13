
using AutoMapper;
using Books_Management_System.Data;
using Books_Management_System.DTOs;
using Books_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_Management_System.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;
        public BookRepository(ApplicationDbContext dbContext , IMapper mapper)
        {
			_dbContext = dbContext;
			_mapper = mapper;
            
        }
        public async Task CreateBook(BookDto book)
		{

			var bookFromDb = _mapper.Map<Book>(book);

			await _dbContext.Books.AddAsync(bookFromDb);
			await _dbContext.SaveChangesAsync();

			
		}

		public async Task Delete(int id)
		{
			var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
			 _dbContext.Books.Remove(book);
			await _dbContext.SaveChangesAsync();	

		}

		public async Task<IEnumerable<BookDto>> GetAll()
		{
			var booksFromDb = await _dbContext.Books.ToListAsync();

			if(booksFromDb == null)
			{
				return null;
			}

			var books = _mapper.Map<List<BookDto>>(booksFromDb);


			return books;
		}

		public async Task<BookDto> GetById(int id)
		{
			var bookFromDb = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);	

			if(bookFromDb == null)
			{
				return null;
			}

			var book = _mapper.Map<BookDto>(bookFromDb);	
			return book;
		}

		public async Task<BookDto> Update(int id, BookDto book)
		{
			var bookFromDb = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);	

			if(bookFromDb == null)
			{
				return null;
			}

			bookFromDb.Author = book.Author;
			bookFromDb.Title = book.Title;
			bookFromDb.publishedDate = book.publishedDate;

			_mapper.Map(bookFromDb, book);

			_dbContext.Books.Update(bookFromDb);
			await _dbContext.SaveChangesAsync();

			_mapper.Map(book, bookFromDb);


			return book;


		}
	}
}

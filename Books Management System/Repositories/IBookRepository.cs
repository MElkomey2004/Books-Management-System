using Books_Management_System.DTOs;
using Books_Management_System.Models;

namespace Books_Management_System.Repositories
{
	public interface IBookRepository
	{
		Task CreateBook(BookDto book);
		Task<IEnumerable<BookDto>> GetAll();
		Task<BookDto> GetById(int id);
		Task<BookDto> Update(int id , BookDto book);

		Task Delete(int id);

	}
}

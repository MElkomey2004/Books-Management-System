﻿namespace Books_Management_System.DTOs
{
	public class BookDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public DateTime publishedDate { get; set; } = DateTime.Now;
	}
}

﻿namespace Books_Management_System.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }	
		public string Author { get; set; }	
		public DateTime publishedDate { get;set; } = DateTime.Now;

	}
}

using System;
using ApiUsers.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUsers.Database
{
	public class UserContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public UserContext(DbContextOptions options) : base(options)
		{
		}
	}
}


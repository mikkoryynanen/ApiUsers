using System;
using System.ComponentModel.DataAnnotations;

namespace ApiUsers.Models
{
	public class User
	{
		[Key]
		public Guid ID { get; set; }
		public Guid ApiKey { get; set; }
	}
}


using System;
using System.ComponentModel.DataAnnotations;

namespace ShareBuilderProj.Data.Models
{
	public class UserModel
	{
		public int Id { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }

		public int Age { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}


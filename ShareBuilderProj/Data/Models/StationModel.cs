using System;
using System.ComponentModel.DataAnnotations;

namespace ShareBuilderProj.Data.Models
{
	public class StationModel
	{
		[Key]
		public int Id { get; set; }

		public string? Letters { get; set; }

		public string? Market { get; set; }

		public Affiliation Affiliation { get; set; }

		public List<UserModel>? Users { get; set; }
    }
}


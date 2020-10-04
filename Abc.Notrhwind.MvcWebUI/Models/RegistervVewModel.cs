using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Notrhwind.MvcWebUI.Models
{
	public class RegistervVewModel
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
		[Required]
		public string Email { get; set; }
	}
}

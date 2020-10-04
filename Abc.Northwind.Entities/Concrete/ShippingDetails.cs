﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abc.Northwind.Entities.Concrete
{
	public class ShippingDetails
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		[Range(18,90)]
		public int Age { get; set; }
	}
}

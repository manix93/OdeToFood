﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
	[Route("company/[controller]/[action]")]
	public class AboutController
	{
		public string Phone()
		{
			return "1+555+555+5555";
		}

		[Route("adresik")]
		public string Address()
		{
			return "USA";
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Application.Dto;

public class GameDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	public int StockStatus { get; set; }
	public string Description { get; set; }


}

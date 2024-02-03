using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeOyun.Application.Dto;
using ProjeOyun.Application.Interfaces.Repositories;
using ProjeOyun.Domain.Entities;

namespace ProjeOyun.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SalesController : ControllerBase
	{
		private readonly IGenericRepository<Sale> _repository;
		private readonly IGenericRepository<Campaign> _campaignRepository;
		private readonly IGenericRepository<Game> _gameRepository;
		private readonly IMapper _mapper;

		public SalesController(IGenericRepository<Sale> repository, IMapper mapper, IGenericRepository<Campaign> campaignRepository, IGenericRepository<Game> gameRepository)
		{
			_repository = repository;
			_mapper = mapper;
			_campaignRepository = campaignRepository;
			_gameRepository = gameRepository;
		}
		[HttpPost]
		public async Task<IActionResult> AddSale(SaleDto saleDto)
		{
			Sale sale = _mapper.Map<Sale>(saleDto);

			if (sale.GameId > 0)
			{
				var game = await _gameRepository.FindAsync(sale.GameId);
					sale.Price = game.Price;
			}

			if (sale.CampaignId.HasValue)
            {
				var campaign = await _campaignRepository.FindAsync(sale.CampaignId.Value);
				if(campaign != null && campaign.DiscountRate > 0)
				{
					sale.Price -= (sale.Price * campaign.DiscountRate / 100);
				}
            }
			
            await _repository.AddAsync(sale);
			await _repository.SaveAsync();

			return Ok("Sale created successfully.");
		}

		[HttpGet]
		public async Task<IActionResult> GetAllSales()
		{
			var datas = await _repository.GetAllAsync
			(
			);
			return Ok(datas);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSale(SaleDto saleDto)
		{
			var data = _mapper.Map<Sale>(saleDto);
			await _repository.UpdateAsync(data);
			await _repository.SaveAsync();
			return Ok("Update success!");

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSale(int id)
		{
			var data = await _repository.FindAsync(id);
			await _repository.HardDelete(data);
			await _repository.SaveAsync();
			return Ok("Sale deleted!");
		}

	}
}

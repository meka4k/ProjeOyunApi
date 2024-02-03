using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjeOyun.Application.Dto;
using ProjeOyun.Application.Interfaces.Repositories;
using ProjeOyun.Domain.Entities;
using ProjeOyun.Infrastructure.Services;

namespace ProjeOyun.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayersController : ControllerBase
	{
		private readonly IGenericRepository<Player> _repository;
		private readonly IMernisService _mernisService;
		private readonly IMapper _mapper;

		public PlayersController(IMernisService mernisService, IGenericRepository<Player> repository, IMapper mapper)
		{
			_mernisService = mernisService;
			_repository = repository;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> AddPlayer(PlayerDto player)
		{
			try
			{
				bool isIdentityValid = await _mernisService.ValidateIdentityAsync(player.IdentityNo, player.FirstName.ToUpper(), player.LastName.ToUpper(), player.DateOfBirth);

				if (!isIdentityValid)
				{
					return BadRequest("Not a valid person!");
				}
				var user = _mapper.Map<Player>(player);
				await _repository.AddAsync(user);
				await _repository.SaveAsync();

				return Ok("Player created successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Bir hata oluştu. Lütfen tekrar deneyin.");
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPlayer()
		{
			var datas = await _repository.GetAllAsync();
			return Ok(datas);
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePlayer(PlayerDto playerDto)
		{

			var data =_mapper.Map<Player>(playerDto);

			await _repository.UpdateAsync(data);
			await _repository.SaveAsync();
			return Ok("Update success!");

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePlayer(int id)
		{
			var data = await _repository.FindAsync(id);
			await _repository.HardDelete(data);
			await _repository.SaveAsync();
			return Ok("Player deleted!");
		}
	}
}


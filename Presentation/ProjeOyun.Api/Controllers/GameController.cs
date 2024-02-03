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
	public class GameController : ControllerBase
	{
		private readonly IGenericRepository<Game> _repository;
		private readonly IMapper _mapper;

		public GameController( IGenericRepository<Game> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> AddGame(GameDto game)
		{

				var data = _mapper.Map<Game>(game);
				await _repository.AddAsync(data);
				await _repository.SaveAsync();

				return Ok("Game created successfully.");
		}

		[HttpGet]
		public async Task<IActionResult> GetAllGames()
		{
			var datas = await _repository.GetAllAsync();
			return Ok(datas);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateGame(GameDto gamedto)
		{

			var data = _mapper.Map<Game>(gamedto);
			await _repository.UpdateAsync(data);
			await _repository.SaveAsync();
			return Ok("Update success!");

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGame(int id)
		{
			var data = await _repository.FindAsync(id);
			await _repository.HardDelete(data);
			await _repository.SaveAsync();
			return Ok("Game deleted!");
		}
	}
}

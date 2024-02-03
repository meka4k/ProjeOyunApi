using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjeOyun.Application.Dto;
using ProjeOyun.Application.Interfaces.Repositories;
using ProjeOyun.Domain.Entities;

namespace ProjeOyun.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CampaignController : ControllerBase
{
	private readonly IGenericRepository<Campaign> _repository;
	private readonly IMapper _mapper;

	public CampaignController(IGenericRepository<Campaign> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}
	[HttpPost]
	public async Task<IActionResult> AddCampaign(CampaignDto campaign)
	{

		var data = _mapper.Map<Campaign>(campaign);
		await _repository.AddAsync(data);
		await _repository.SaveAsync();

		return Ok("Campaign created successfully.");
	}

	[HttpGet]
	public async Task<IActionResult> GetAllCampaigns()
	{
		var datas = await _repository.GetAllAsync();
		return Ok(datas);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateCampaign(CampaignDto gamedto)
	{

		var data = _mapper.Map<Campaign>(gamedto);
		await _repository.UpdateAsync(data);
		await _repository.SaveAsync();
		return Ok("Update success!");

	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCampaign(int id)
	{
		var data = await _repository.FindAsync(id);
		await _repository.HardDelete(data);
		await _repository.SaveAsync();
		return Ok("Campaign deleted!");
	}
}


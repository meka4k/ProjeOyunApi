using AutoMapper;
using ProjeOyun.Application.Dto;
using ProjeOyun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOyun.Application.Mapping
{
	public class MapProfile:Profile
	{
        public MapProfile()
        {
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<Campaign, CampaignDto>().ReverseMap();
        }
    }
}

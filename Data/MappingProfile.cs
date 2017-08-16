using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bpt.api.Models;
using bpt.api.DTOs;

namespace bpt2.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bullet, BulletDTO>();
            CreateMap<BulletDTO, Bullet>();
            CreateMap<BulletPage, BulletPageDTO>().ForMember(dest => dest.BulletCount, opts => opts.MapFrom(src => src.Bullets.Count));
        }
    }
}

using Core.DTO.Usuarios;
using Data.Data.APIContext.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcercaPartnersApi.API.Assets
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Get Usuarios
            CreateMap<Cars, DtoCar>();
            #endregion
            #region Post Usuarios
            CreateMap<DtoCarCreate, Cars>()
                .ForMember(des => des.Id, opt => opt.Ignore());
            #endregion
            #region Put Usuarios
            CreateMap<DtoCarUpdate, Cars>();
            #endregion
        }
    }
}

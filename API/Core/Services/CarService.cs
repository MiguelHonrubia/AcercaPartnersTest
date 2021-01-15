using Core.DTO.Helpers;
using Core.DTO.Usuarios;
using Core.Helpers;
using Core.Interfaces.Services;
using Data.Data.APIContext.Context;
using Data.Data.APIContext.Models;
using Data.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CarService : ICarService
    {
        #region Constructor

        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly ICarsRepository _carRepository;

        public CarService(APIContext context, IMapper mapper, ICarsRepository carRepository)
        {
            _context = context;
            _mapper = mapper;
            _carRepository = carRepository;
        }
        #endregion
        #region Actions

        /// <summary>
        /// Get Car by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoCar> GetCarId(int id)
        {
            DtoCar User = await _carRepository.GetCars().AsNoTracking().Where(c => c.Id == id).ProjectTo<DtoCar>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return User;
        }

        /// <summary>
        /// Get All cars 
        /// </summary>
        /// <returns></returns>
        public async Task<PagedList<DtoCar>> GetAllCars(DtoFilterPagedList pagedListParams)
        {
            //Servicio con paginacion en servidor

            PagedList<DtoCar> listResult = null;

            var query = _carRepository.GetCars().AsNoTracking().IgnoreQueryFilters().ProjectTo<DtoCar>(_mapper.ConfigurationProvider);

            if (pagedListParams.Active)
            {
                listResult = await PagedList<DtoCar>.ToPagedListAsync(query, pagedListParams.PageNumber, pagedListParams.PageSize);
                return listResult;
            }

            listResult = await PagedList<DtoCar>.ToOnlyListAsync(query);

            return listResult;
        }


        /// <summary>
        /// Create car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int?> CreateCar(DtoCarCreate data)
        {
            int? result = null;

            Cars entity = _mapper.Map<Cars>(data);
            _carRepository.AddCar(entity);
            await _context.SaveChangesAsync();

            result = entity.Id;


            return result;
        }

        /// <summary>
        /// Update car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int?> UpdateCar(DtoCarUpdate data)
        {
            int? result = null;


            var lastEntity = await _carRepository.GetCars().IgnoreQueryFilters().Where(c => c.Id == data.Id).FirstOrDefaultAsync();

            if (lastEntity != null)
            {
                Cars entity = _mapper.Map(data, lastEntity);
                _carRepository.UpdateCar(entity);
                await _context.SaveChangesAsync();

                result = entity.Id;
            }

            return result;
        }

        /// <summary>
        /// Remove car by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveCar(int id)
        {
            var entity = await _carRepository.GetCars().IgnoreQueryFilters().Where(c => c.Id == id).FirstOrDefaultAsync();

            if (entity != null)
            {
                _carRepository.DeleteCar(entity);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
        #region Private Method

        #endregion
    }
}

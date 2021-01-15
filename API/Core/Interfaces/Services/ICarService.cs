using Core.DTO.Helpers;
using Core.DTO.Usuarios;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICarService
    {
        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        Task<DtoCar> GetCarId(int id);

        /// <summary>
        /// Get All Users 
        /// </summary>
        /// <returns></returns>
        Task<PagedList<DtoCar>> GetAllCars(DtoFilterPagedList pagedListParams);


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<int?> CreateCar(DtoCarCreate data);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<int?> UpdateCar(DtoCarUpdate data);

        /// <summary>
        /// Remove User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveCar(int id);
    }
}

using Data.Data.APIContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interfaces.Repositories
{
    public interface ICarsRepository
    {
        /// <summary>
        /// Get Entities from cars
        /// </summary>
        /// <returns></returns>
        IQueryable<Cars> GetCars();

        /// <summary>
        /// Add new Entity car
        /// </summary>
        /// <param name="entity"></param>
        void AddCar(Cars entity);

        /// <summary>
        /// Update Entity car
        /// </summary>
        /// <param name="entity"></param>
        void UpdateCar(Cars entity);

        /// <summary>
        /// Delete Entity car
        /// </summary>
        /// <param name="entity"></param>
        void DeleteCar(Cars entity);
    }
}

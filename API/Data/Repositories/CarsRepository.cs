using Data.Data.APIContext.Context;
using Data.Data.APIContext.Models;
using Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Data.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        #region Constructor
        private readonly APIContext _context;
        public CarsRepository(APIContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Get Entities from Users
        /// </summary>
        /// <returns></returns>
        public IQueryable<Cars> GetCars()
        {
            return _context.Cars;
        }

        /// <summary>
        /// Add new Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        public void AddCar(Cars entity)
        {
            _context.Cars.Add(entity);
        }

        /// <summary>
        /// Update Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateCar(Cars entity)
        {
            _context.Cars.Update(entity);
        }

        /// <summary>
        /// Delete Entity Usuarios
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteCar(Cars entity)
        {
            _context.Cars.Remove(entity);
        }
    }
}

using Data.Data.APIContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Data.APIContext.Database
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var _context = new APIContext.Context.APIContext(serviceProvider.GetRequiredService<DbContextOptions<APIContext.Context.APIContext>>()))
            {
                if (_context.Cars.Any())
                {
                    return;
                }

                for(int i= 0; i< 50; i++)
                {
                    Cars car = new Cars(){
                        //Id = i,
                        OrderNumber = i,
                        Frame = (321 * i+1).ToString(),
                        Model = "&&&&&",
                        Enrollment = "1234ABC",
                        Deadline = new DateTime()

                    };

                    _context.Cars.Add(car);
                    _context.SaveChanges();
                }

                 

            }
        }
    }
}

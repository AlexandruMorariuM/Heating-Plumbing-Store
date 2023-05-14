using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class OrderService
    {
        private readonly UnitOfWork unitOfWork;
        public OrderService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Order> GetAll()
        {
            try
            {
                var results = unitOfWork.Orders.GetAll();
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine("Core.Services => List<Order> GetAll(): " + e.Message);
                throw new Exception("Error while reading all orders! ", e);
            }
        }
    }
}

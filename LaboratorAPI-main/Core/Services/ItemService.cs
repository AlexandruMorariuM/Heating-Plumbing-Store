using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ItemService
    {
        private readonly UnitOfWork unitOfWork;
        public ItemService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Item> GetAll()
        {
            try
            {
                var results = unitOfWork.Items.GetAll();
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine("Core.Services => List<Item> GetAll(): " + e.Message);
                throw new Exception("Error while reading all items! ", e);
            }
        }

        public Item GetById(int itemId)
        {
            try
            {
                var result = unitOfWork.Items.GetById(itemId);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Core.Services => Item GetById(int itemId): " + e.Message);
                throw new Exception("Error while reading ID: " + itemId + " item.", e);
            }
        }

        public void Add(AddItemDto payload)
        {
            try
            {
                if (payload == null) return;

                var item = new Item
                {
                    Name = payload.Name,
                    Description = payload.Description,
                    StockCount = payload.StockCount
                };

                unitOfWork.Items.Insert(item);
                unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Core.Services => Add(AddItemDto payload): " + e.Message);
                throw new Exception("Error while adding item. ", e);
            }
        }

        public bool Edit(EditItemDto payload)
        {
            try
            {
                if (payload == null) return false;

                var result = unitOfWork.Items.GetById(payload.Id);
                if (result == null) return false;

                result.Description = payload.Description;
                result.Name = payload.Name;
                result.StockCount = payload.StockCount;

                unitOfWork.Items.Update(result);
                unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Core.Services => bool EditItem(EditItemDto payload): " + e.Message);
                throw new Exception("Error while editing item. ", e);
            }
        }

        public bool Delete(int itemId)
        {
            try
            {
                var result = unitOfWork.Items.GetById(itemId);
                if (result == null) return false;

                unitOfWork.Items.Remove(result);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Core.Services => bool Delete(int itemId): " + e.Message);
                throw new Exception("Error while deleting item. ", e);
            }
        }
    }
}

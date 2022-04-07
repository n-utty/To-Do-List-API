using RestAPi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPi.Server.Models
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> Search(string Task);
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(int ItemId);
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task DeleteItem(int ItemId);
    }
}

using Microsoft.EntityFrameworkCore;
using RestAPi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPi.Server.Models
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;
        public ItemRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Item> AddItem(Item item)
        {
            var Item = await _db.AddAsync(item);
            await _db.SaveChangesAsync();
            return Item.Entity;
        }

        public async Task DeleteItem(int ItemId)
        {
            var item = await _db.Items.FirstOrDefaultAsync(it => it.ItemId == ItemId);
            if (item != null)
            {
                _db.Remove(item);
                await _db.SaveChangesAsync();

            }
        }

        public async Task<Item> GetItem(int ItemId)
        {
            var item = await _db.Items.FirstOrDefaultAsync(it => it.ItemId == ItemId);
   
             return item;
            

        }

        public async  Task<IEnumerable<Item>> GetItems()
        {
            return await _db.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> Search(string Task)
        {
            IQueryable<Item> query = _db.Items;

            if (!string.IsNullOrEmpty(Task))
            {
                query = query.Where(it => it.Task == Task);

                return await query.ToListAsync();
                    
            }
            return null;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            var result = await _db.Items.FirstOrDefaultAsync(it => it.ItemId == item.ItemId);
            if (result != null)
            {
                result.Status = item.Status;
                result.Task = item.Task;
                result.Priority = item.Priority;
                return result;
            }
            return null;
        }
    }
}

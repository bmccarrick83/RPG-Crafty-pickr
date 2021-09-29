using System;
using System.Collections.Generic;
using RPG_Crafty_pickr.Entitities;
using System.Threading.Tasks;

    public interface IItemsRepository
    {
        Task<Items> GetItemAsync(Guid id);
        Task<IEnumerable<Items>> GetItemsAsync();
        Task CreateItemAsync(Items item);
        Task DeleteItemAsync(Guid id);

    }



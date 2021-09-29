using Microsoft.AspNetCore.Mvc;
using RPG_Crafty_pickr.Dtos;
using System;
using System.Collections.Generic;



namespace RPG_Crafty_pickr.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new List<ItemDto>()
        {
            new ItemDto(Guid.NewGuid(), "Potion","Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow)
        };
        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }
    }
}

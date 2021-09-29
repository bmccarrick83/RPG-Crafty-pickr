using System;
using System.ComponentModel.DataAnnotations;


namespace RPG_Crafty_pickr.Dtos
{
  //a record is a reference type that encapsulates data
        public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
        public record CreateItemDto([Required] string Name, string Description, [Range(1, 1000)] decimal Price);
        public record UpdateItemDto([Required] string Name, string Description, [Range(1, 1000)] decimal Price);
    
}

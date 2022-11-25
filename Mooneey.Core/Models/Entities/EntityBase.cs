using System;
namespace Mooneey.Core.Models.Entities
{
	public class EntityBase
	{
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EpdatedAt { get; set; }
    }
}


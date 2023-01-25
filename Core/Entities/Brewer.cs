using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Brewer : BaseEntity
    {
        
        [Required]
        public string Name { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

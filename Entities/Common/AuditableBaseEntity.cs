using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities.Common
{
    public abstract class AuditableBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? UserCreatedId { get; set; }
        public int? UserModifiedId { get; set; }
    }
}

using WebApi.Entities.Common;
using WebApi.Entities.Players;

namespace WebApi.Entities.Misc
{
    public class Inventory : AuditableBaseEntity
    {
        public string Name { get; set; }

        public InventoryType InventoryType { get; set; }

        public long UserId { get; set; }
    }
}

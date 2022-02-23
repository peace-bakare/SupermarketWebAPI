using System.Collections;
using System.Collections.Generic;

namespace SupermarketWebAPI.Domain.Models
{
    public enum AdministratorPermissions
    {
        ManageUsers = 1,
        ManageWarehouses = 2,
        ManageProducts = 3
    }

    public enum WarehousePermissions
    {
        ViewProducts = 1,
        BuyProducts = 2,
        ManageProducts = 3
    }

    public class UserPermissions
    {
        public ICollection<AdministratorPermissions> Administrators { get; set; }

        public IDictionary<int, ICollection<WarehousePermissions>> WarehousePermissions { get; set; } 
            //= new Dictionary<int, ICollection<WarehousePermissions>>();
    }
}
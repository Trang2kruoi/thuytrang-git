using System.Collections.Generic;
using thuytrang.Roles.Dto;

namespace thuytrang.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}

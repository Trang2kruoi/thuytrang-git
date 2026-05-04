using System.Collections.Generic;
using thuytrang.Roles.Dto;

namespace thuytrang.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

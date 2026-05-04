using System.Collections.Generic;
using thuytrang.Roles.Dto;

namespace thuytrang.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
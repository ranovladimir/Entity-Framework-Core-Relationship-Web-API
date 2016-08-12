using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TouchCloudBackEnd.Entities.Administrations
{
    public class RoleUser
    {
        [Key]
        public int? IdRoleUser { get; set; }

        public int NumberRoleUser { get; set; }

        public string NameRoleUser { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


        //one role to many user
        public List<User> Users { get; set; }


        public RoleUser()
        {

        }
    }
}
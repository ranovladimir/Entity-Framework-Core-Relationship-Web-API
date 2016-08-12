using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TouchCloudBackEnd.Entities.Administrations
{
    public class User
    {
       [Key]
        public int IdUser { get; set; }


        [/*Required,*/ MaxLength(50)]
        [Display(Name = "Identifiants")]
        public string PseudoUser { get; set; }

        [Required, MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string PasswordUser { get; set; }

        public string EmailUser { get; set; }

        public DateTime? BirthdateUser { get; set; }

        public string HiddenInfos { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }



        //many-to-many relationship between User and Group class
        //done with Fluent API (in TouchcloudDbContext) and UserGroup class
        public List<User_Group> UserGroups { get; set; }


        ////many users to one role
        public int? RoleUser_Id { get; set; }
        [JsonIgnore]
        public RoleUser RoleUser { get; set; }


        public User()
        {

        }
    }
}

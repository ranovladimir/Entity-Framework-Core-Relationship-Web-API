using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TouchCloudBackEnd.Entities.Administrations
{
    public class Group
    {
        [Key]
        public int? IdGroup { get; set; }

        public string NameGroup { get; set; }

        public string DescriptionGroup { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


        //many-to-many relationship between User and Group class
        //done with Fluent API (in TouchcloudDbContext) and UserGroup class
        public List<User_Group> UserGroups { get; set; }

        // many-to-many relationship between Group and Action
        //(https://docs.efproject.net/en/latest/modeling/relationships.html#many-to-many)
        public List<ActionGroup> ActionGroups { get; set; }



        public Group()
        {

        }
    }
}

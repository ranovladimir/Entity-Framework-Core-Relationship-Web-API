using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TouchCloudBackEnd.Entities.Administrations
{
    public class Action
    {
        [Key]
        public int? IdAction { get; set; }

        public string NameAction { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


        //relation many-to-many
        public List<ActionGroup> ActionGroups { get; set; }

        public Action()
        {

        }
    }
}
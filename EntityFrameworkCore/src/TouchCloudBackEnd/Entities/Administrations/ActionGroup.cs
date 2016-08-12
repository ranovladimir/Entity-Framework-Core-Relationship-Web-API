namespace TouchCloudBackEnd.Entities.Administrations
{
    public class ActionGroup
    {
        //  [Key]
        public int? IdGroup { get; set; }
        public Group Group { get; set; }

        // [Key]
        public int? IdAction { get; set; }
        public Action Action { get; set; }
    }
}

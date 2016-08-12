namespace TouchCloudBackEnd.Entities.Administrations
{
    public class User_Group
    {
        public int? IdUser { get; set; }

        public User User { get; set; }

        public int? IdGroup { get; set; }

        public Group Group { get; set; }
    }
}

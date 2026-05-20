namespace ApiProjeKampi.WebApi.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int MapLocation{ get; set; }
        public int Address{ get; set; }

        public int Phone { get; set; }
        public int Email { get; set; }
        public int OpenHours { get; set; }
    }
}

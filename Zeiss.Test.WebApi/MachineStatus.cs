namespace Zeiss.Test.WebApi
{
    public class MachineStatus
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Guid MachineId { get; set; }
        public Guid Id { get; set; }
    }
}
namespace FoodTrucksMenus.Data.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Enable { get; set; }
        public ICollection<TruckSchedule>? TruckSchedules { get; set; }
    }
}
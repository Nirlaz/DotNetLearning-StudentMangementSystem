namespace StudentsMangement.Models.Entitles
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Grade { get; set; }
        public string? Gender { get; set; }
    }
}

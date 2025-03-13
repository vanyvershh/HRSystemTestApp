namespace HRSystemTestApp.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Candidate>? Candidates { get; set; }
    }
}

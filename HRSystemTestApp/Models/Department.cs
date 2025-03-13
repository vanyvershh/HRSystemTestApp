namespace HRSystemTestApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Vacancy>? Vacancies { get; set; }
    }
}

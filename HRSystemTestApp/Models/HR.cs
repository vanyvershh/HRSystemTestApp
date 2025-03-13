namespace HRSystemTestApp.Models
{
    public class HR
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Vacancy>? Vacancies { get; set; }
    }
}

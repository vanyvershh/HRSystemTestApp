namespace HRSystemTestApp.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// ссылка на резюме
        /// </summary>
        public string CVLink {  get; set; }

        /// <summary>
        /// этап приема на работу
        /// </summary>
        public string RecruitmentStage {  get; set; }

        /// <summary>
        /// дата начала рассмотрения
        /// </summary>
        public DateTime ApplicationDate { get; set; }

        /// <summary>
        /// дата окончания испытательного срока. Выставляется после приема на работу
        /// </summary>
        public DateTime? ProbationaryPeriodEndDate {  get; set; }
        public int? VacancyId { get; set; }
        public Vacancy? Vacancy { get; set; }
        public int? HRId { get; set; }
        public HR? HR { get; set; }
    }
}

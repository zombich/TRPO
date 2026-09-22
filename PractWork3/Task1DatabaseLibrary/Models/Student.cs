namespace Task1DatabaseLibrary.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly Birthday { get; set; }
        public int CategoryId { get; set; } 
        public int Course {  get; set; }
        public bool IsScholarshipHolder { get; set; }
        public Category Category { get; set; }
    }
}

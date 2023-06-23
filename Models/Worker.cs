namespace Attendance_List_Generator.Models;

internal class Worker
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long Pesel { get; set; }
    public Workplace Workplace { get; set; }
    public Agreement AgreementType { get; set; }
}

namespace OrderManagerCore.Common.Models;

public class EmployeeViewModel
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? TitleOfCourtesy { get; set; }
}
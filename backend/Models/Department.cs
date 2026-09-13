namespace Backend.Model;

public class Department{
    public int Id {get;set;}
    public string DepartmentName {get;set;}="";
    public List<Employee> Employees { get; set; } = new();

}
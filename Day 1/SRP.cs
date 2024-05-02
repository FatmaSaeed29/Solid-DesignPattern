public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }

    public decimal CalculateYearlySalary()
    {
        return Salary * 12;
    }
    public void GenerateReport(string reportType)
    {

    }
    public void SendNotification(string recipient, string message)
    {

    }

}


//? 1- Identify the responsibilities of the Employee class.
    /*

    1- know the employee info
    2- Calculate the Employee Salary
    3- Generate Reports For The Employee
    4- Send Notifications
    
    */

//? Create separate classes for each responsibility, adhering to the SRP.

// I will Create A Separate Class For Each Responsibility in order to make each class responsible for only one thing
// (Achieve the SRP)

//* 1- Class To Know the employee Info (name - Salary - Department)
public class EmployeeInfo
{
    public string Name { get; set; }    
    public decimal Salary { get; set; }
    public string Department { get; set; }
}

//* 2- Class To calculate the employee salary
public class EmployeeSalary
{
    public decimal CalculateYearlySalary(decimal Salary)
    {
        return Salary * 12;
    }
}

//* 3- Class To Generate the reports for the Employee
public class ReportGenerator
{
    public void GenerateReport(string reportType)
    {
        // Report generation logic
    }
}

//* 4- Class To Send Notifications
public class SendNotifications
{
    public void SendEmail(string recipient, string message)
    {
        // Email sending logic
    }
}

//? 3-  Refactor the Employee class and other classes to ensure that each class has a single responsibility

public class Employee
{
    private readonly EmployeeInfo EmpInfo;
    private readonly EmployeeSalary EmpSal;
    private readonly ReportGenerator reportGenerator;
    private readonly SendNotifications _SendNotification;

    public Employee(EmployeeData employeeData, SalaryCalculator salaryCalculator, ReportGenerator reportGenerator, EmailNotifier emailNotifier)
    {
        _employeeData = employeeData;
        _salaryCalculator = salaryCalculator;
        _reportGenerator = reportGenerator;
        _emailNotifier = emailNotifier;
    }

    public void GenerateReport(string reportType)
    {
        decimal yearlySalary = _salaryCalculator.CalculateYearlySalary(_employeeData.Salary);
        _reportGenerator.GenerateReport(_employeeData.Name, _employeeData.Department, yearlySalary, reportType);
    }

    public void SendEmailNotification(string recipient, string subject, string body)
    {
        _emailNotifier.SendEmail(recipient, subject, body);
    }

    // Other methods related to employee behavior can be added here
}
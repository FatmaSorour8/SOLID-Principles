namespace SingleResponsibilityPrinciple
{
    // Interface
    public interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    // Class for sending email notifications
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            // Code 
        }
    }

    // Class for generating reports
    public class ReportGenerator
    {
        public void GenerateReport(string reportType)
        {
            // Code 
        }
    }

    // Employee Class 
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public decimal CalculateYearlySalary()
        {
            return Salary * 12;
        }
    }
}

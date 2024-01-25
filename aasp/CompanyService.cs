using Microsoft.Extensions.Configuration;

public class CompanyService
{
    private readonly IConfiguration _configuration;

    public CompanyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void DisplayMostEmployedCompany()
    {
        var configSection = _configuration.GetSection("Companies");
        int maxEmployees = 0;
        string companyNameWithMostEmployees = "";

        foreach (var company in configSection.GetChildren())
        {
            var name = company["Name"];
            var employees = company["Employees"] != null ? int.Parse(company["Employees"]) : 0;

            if (employees > maxEmployees)
            {
                maxEmployees = employees;
                companyNameWithMostEmployees = name;
            }
        }

        System.Console.WriteLine($"Company with the most employees: {companyNameWithMostEmployees}");
    }

    public Company GetMostEmployedCompany()
    {
        var configSection = _configuration.GetSection("Companies");
        int maxEmployees = 0;
        Company mostEmployedCompany = new Company();

        foreach (var company in configSection.GetChildren())
        {
            var name = company["Name"];
            var employees = company["Employees"] != null ? int.Parse(company["Employees"]) : 0;

            if (employees > maxEmployees)
            {
                maxEmployees = employees;
                mostEmployedCompany = new Company { Name = name, Employees = employees };
            }
        }

        return mostEmployedCompany;
    }
}
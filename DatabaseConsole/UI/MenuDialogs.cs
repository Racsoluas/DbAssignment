using DatabaseConsole.Models;
using DatabaseConsole.Services;

namespace DatabaseConsole.UI;

public class MenuDialogs
{
    private readonly ProjectService _projectService;
    private readonly CustomerService _customerService;
    private readonly ProjectManagerService _managerService;

    public MenuDialogs(
        ProjectService projectService,
        CustomerService customerService,
        ProjectManagerService managerService
    )
    {
        _projectService = projectService;
        _customerService = customerService;
        _managerService = managerService;
    }

    public async Task ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Projects");
            Console.WriteLine("2. Customers");
            Console.WriteLine("3. Project Managers");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        await ShowProjectMenu();
                        break;
                    case 2:
                        await ShowCustomerMenu();
                        break;
                    case 3:
                        await ShowProjectManagerMenu();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    public async Task ShowProjectMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Projects ===\n");
            Console.WriteLine("1. List All Projects");
            Console.WriteLine("2. View Project Details");
            Console.WriteLine("3. Create New Project");
            Console.WriteLine("4. Edit Project");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("\nSelect an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        var projects = await _projectService.GetAllProjects();
                        DisplayProjects(projects);
                        break;
                    case 2:
                        await ViewProjectDetails();
                        break;
                    case 3:
                        await CreateProject();
                        break;
                    case 4:
                        await EditProject();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    private void DisplayProjects(List<Project> projects)
    {
        Console.Clear();
        Console.WriteLine("=== Project List ===\n");

        if (!projects.Any())
        {
            Console.WriteLine("No projects found.");
        }
        else
        {
            foreach (var project in projects)
            {
                Console.WriteLine($"Project Number: {project.ProjectNumber}");
                Console.WriteLine($"Name: {project.Name}");
                Console.WriteLine($"Status: {project.Status}");
                Console.WriteLine("------------------------");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task ViewProjectDetails()
    {
        Console.Write("\nEnter Project Number: ");
        var projectNumber = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(projectNumber))
        {
            Console.WriteLine("Invalid project number.");
            return;
        }

        var project = await _projectService.GetProject(projectNumber);
        if (project != null)
        {
            Console.Clear();
            Console.WriteLine($"Project Number: {project.ProjectNumber}");
            Console.WriteLine($"Name: {project.Name}");
            Console.WriteLine($"Start Date: {project.StartDate:yyyy-MM-dd}");
            Console.WriteLine($"End Date: {project.EndDate:yyyy-MM-dd}");
            Console.WriteLine($"Project Manager: {project.ProjectManager}");
            Console.WriteLine($"Customer: {project.Customer}");
            Console.WriteLine($"Service: {project.Service}");
            Console.WriteLine($"Total Price: {project.TotalPrice:C}");
            Console.WriteLine($"Status: {project.Status}");
        }
        else
        {
            Console.WriteLine("Project not found.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public async Task ShowCustomerMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Customers ===\n");
            Console.WriteLine("1. List All Customers");
            Console.WriteLine("2. View Customer Details");
            Console.WriteLine("3. Create New Customer");
            Console.WriteLine("4. Edit Customer");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("\nSelect an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        await ListCustomers();
                        break;
                    case 2:
                        await ViewCustomerDetails();
                        break;
                    case 3:
                        await CreateCustomer();
                        break;
                    case 4:
                        await EditCustomer();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    public async Task ShowProjectManagerMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Project Managers ===\n");
            Console.WriteLine("1. List All Project Managers");
            Console.WriteLine("2. View Project Manager Details");
            Console.WriteLine("3. Create New Project Manager");
            Console.WriteLine("4. Edit Project Manager");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("\nSelect an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        await ListProjectManagers();
                        break;
                    case 2:
                        await ViewProjectManagerDetails();
                        break;
                    case 3:
                        await CreateProjectManager();
                        break;
                    case 4:
                        await EditProjectManager();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    // Project Methods
    private async Task CreateProject()
    {
        var project = new Project
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(1),
            Status = ProjectStatus.NotStarted,
        };

        Console.Clear();
        Console.WriteLine("=== Create New Project ===\n");

        Console.Write("Project Name: ");
        project.Name = Console.ReadLine() ?? "";

        Console.Write("Project Manager: ");
        project.ProjectManager = Console.ReadLine() ?? "";

        Console.Write("Customer: ");
        project.Customer = Console.ReadLine() ?? "";

        Console.Write("Service: ");
        project.Service = Console.ReadLine() ?? "";

        Console.Write("Total Price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            project.TotalPrice = price;
        }

        if (await _projectService.CreateProject(project))
        {
            Console.WriteLine("\nProject created successfully!");
        }
        else
        {
            Console.WriteLine("\nFailed to create project.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task EditProject()
    {
        Console.Write("\nEnter Project Number to edit: ");
        var projectNumber = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(projectNumber))
        {
            Console.WriteLine("Invalid project number.");
            return;
        }

        var project = await _projectService.GetProject(projectNumber);
        if (project == null)
        {
            Console.WriteLine("Project not found.");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine($"=== Edit Project {project.ProjectNumber} ===\n");

        Console.Write($"Project Name [{project.Name}]: ");
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            project.Name = input;

        Console.Write($"Project Manager [{project.ProjectManager}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            project.ProjectManager = input;

        Console.Write($"Customer [{project.Customer}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            project.Customer = input;

        Console.Write($"Service [{project.Service}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            project.Service = input;

        Console.Write($"Total Price [{project.TotalPrice}]: ");
        input = Console.ReadLine();
        if (decimal.TryParse(input, out decimal price))
            project.TotalPrice = price;

        Console.WriteLine("\nStatus:");
        Console.WriteLine("1. Not Started");
        Console.WriteLine("2. In Progress");
        Console.WriteLine("3. Completed");
        Console.Write($"Select status [{(int)project.Status + 1}]: ");
        if (
            int.TryParse(Console.ReadLine(), out int statusChoice)
            && statusChoice >= 1
            && statusChoice <= 3
        )
            project.Status = (ProjectStatus)(statusChoice - 1);

        if (await _projectService.UpdateProject(projectNumber, project))
        {
            Console.WriteLine("\nProject updated successfully!");
        }
        else
        {
            Console.WriteLine("\nFailed to update project.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task ListCustomers()
    {
        var customers = await _customerService.GetAllCustomers();
        Console.Clear();
        Console.WriteLine("=== Customer List ===\n");

        if (!customers.Any())
        {
            Console.WriteLine("No customers found.");
        }
        else
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}");
                Console.WriteLine($"Company: {customer.CompanyName}");
                Console.WriteLine($"Contact: {customer.ContactPerson}");
                Console.WriteLine("------------------------");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task ViewCustomerDetails()
    {
        Console.Write("\nEnter Customer ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var customer = await _customerService.GetCustomer(id);
        if (customer != null)
        {
            Console.Clear();
            Console.WriteLine($"Company Name: {customer.CompanyName}");
            Console.WriteLine($"Contact Person: {customer.ContactPerson}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.PhoneNumber}");
            Console.WriteLine($"Address: {customer.Address}");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task CreateCustomer()
    {
        var customer = new Customer();

        Console.Clear();
        Console.WriteLine("=== Create New Customer ===\n");

        Console.Write("Company Name: ");
        customer.CompanyName = Console.ReadLine() ?? "";

        Console.Write("Contact Person: ");
        customer.ContactPerson = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        customer.Email = Console.ReadLine() ?? "";

        Console.Write("Phone Number: ");
        customer.PhoneNumber = Console.ReadLine() ?? "";

        Console.Write("Address: ");
        customer.Address = Console.ReadLine();

        if (await _customerService.CreateCustomer(customer))
        {
            Console.WriteLine("\nCustomer created successfully!");
        }
        else
        {
            Console.WriteLine("\nFailed to create customer.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task EditCustomer()
    {
        Console.Write("\nEnter Customer ID to edit: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var customer = await _customerService.GetCustomer(id);
        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine($"=== Edit Customer {customer.Id} ===\n");

        Console.Write($"Company Name [{customer.CompanyName}]: ");
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            customer.CompanyName = input;

        Console.Write($"Contact Person [{customer.ContactPerson}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            customer.ContactPerson = input;

        Console.Write($"Email [{customer.Email}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            customer.Email = input;

        Console.Write($"Phone Number [{customer.PhoneNumber}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            customer.PhoneNumber = input;

        Console.Write($"Address [{customer.Address}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            customer.Address = input;

        if (await _customerService.UpdateCustomer(id, customer))
        {
            Console.WriteLine("\nCustomer updated successfully!");
        }
        else
        {
            Console.WriteLine("\nFailed to update customer.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task ListProjectManagers()
    {
        var managers = await _managerService.GetAllProjectManagers();
        Console.Clear();
        Console.WriteLine("=== Project Manager List ===\n");

        if (!managers.Any())
        {
            Console.WriteLine("No project managers found.");
        }
        else
        {
            foreach (var manager in managers)
            {
                Console.WriteLine($"ID: {manager.Id}");
                Console.WriteLine($"Name: {manager.FullName}");
                Console.WriteLine($"Email: {manager.Email}");
                Console.WriteLine("------------------------");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task ViewProjectManagerDetails()
    {
        Console.Write("\nEnter Project Manager ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var manager = await _managerService.GetProjectManager(id);
        if (manager != null)
        {
            Console.Clear();
            Console.WriteLine($"Name: {manager.FullName}");
            Console.WriteLine($"Email: {manager.Email}");
            Console.WriteLine($"Phone: {manager.PhoneNumber}");
        }
        else
        {
            Console.WriteLine("Project manager not found.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task CreateProjectManager()
    {
        var manager = new ProjectManager();

        Console.Clear();
        Console.WriteLine("=== Create New Project Manager ===\n");

        Console.Write("First Name: ");
        manager.FirstName = Console.ReadLine() ?? "";

        Console.Write("Last Name: ");
        manager.LastName = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        manager.Email = Console.ReadLine() ?? "";

        Console.Write("Phone Number: ");
        manager.PhoneNumber = Console.ReadLine() ?? "";

        if (await _managerService.CreateProjectManager(manager))
        {
            Console.WriteLine("\nProject manager created successfully!");
        }
        else
        {
            Console.WriteLine("\nFailed to create project manager.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private async Task EditProjectManager()
    {
        Console.Write("\nEnter Project Manager ID to edit: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var manager = await _managerService.GetProjectManager(id);
        if (manager == null)
        {
            Console.WriteLine("Project manager not found.");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine($"=== Edit Project Manager {manager.Id} ===\n");

        Console.Write($"First Name [{manager.FirstName}]: ");
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            manager.FirstName = input;

        Console.Write($"Last Name [{manager.LastName}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            manager.LastName = input;

        Console.Write($"Email [{manager.Email}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            manager.Email = input;

        Console.Write($"Phone Number [{manager.PhoneNumber}]: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            manager.PhoneNumber = input;

        if (await _managerService.UpdateProjectManager(id, manager))
        {
            Console.WriteLine("\nProject manager updated successfully!");
        }
        else
        {
            Console.WriteLine("\nFailed to update project manager.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}

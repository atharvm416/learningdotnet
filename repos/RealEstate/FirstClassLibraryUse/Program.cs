using ClassLibrary1;

// Keep the old logic
//Console.WriteLine("First Name:");
//string? fname = Console.ReadLine();

//Console.WriteLine("Last Name:");
//string? lname = Console.ReadLine();

//string fullname = PersonProcessor.JoinName(fname ?? "", lname ?? "");
//Console.WriteLine("Full Name is: " + fullname);


//Console.WriteLine("\nEnter Property Price:");
//decimal price = decimal.Parse(Console.ReadLine() ?? "0");

//Console.WriteLine("Enter Property Location:");
//string location = Console.ReadLine() ?? "";

//if (RealEstateProcessor.IsValidProperty(price, location))
//{
//    decimal commission = RealEstateProcessor.CalculateCommission(price);
//    Console.WriteLine($"Commission: {commission:C}");
//}
//else
//{
//    Console.WriteLine("Invalid property details!");
//}

// new approach RealEstateProcessor
//IRealEstateOperations processor = new RealEstateProcessor();

//// Use the processor through the interface
//List<int> unorderedList = new List<int> { 4, 6, 2, 1 };

//List<int> sortedList = processor.SorttheList(unorderedList);
//Console.WriteLine("Sorted list: " + string.Join(", ", sortedList));

//int averageValue = processor.Average(unorderedList);
//Console.WriteLine($"Average value: {averageValue}");

//// Test other methods
//decimal commission = processor.CalculateCommission(100_000m);
//Console.WriteLine($"Commission for $100,000: ${commission}");

//bool isValid = processor.IsValidProperty(200_000m, "123 Main St");
//Console.WriteLine($"Is property valid? {isValid}");

//new Approach Bank Approach


using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;

class Program
{
    static string connectionString = "Server=localhost;Database=realestate;Integrated Security=True;TrustServerCertificate=True;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== BRAND MANAGEMENT ===");
            Console.WriteLine("1. Add New Brand");
            Console.WriteLine("2. View All Brands");
            Console.WriteLine("3. Update a Brand");
            Console.WriteLine("4. Delete a Brand");

            Console.WriteLine("5. Read the Projects");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBrand();
                    break;
                case "2":
                    ReadBrands();
                    break;
                case "3":
                    UpdateBrand();
                    break;
                case "4":
                    DeleteBrand();
                    break;
                case "5":
                    ReadProjects();
                    break;
                case "6":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddBrand()
    {
        Console.Write("Enter Brand Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Country: ");
        string country = Console.ReadLine();

        Console.Write("Enter Founded Year: ");
        int foundedYear = int.Parse(Console.ReadLine());

        Console.Write("Is Active (true/false): ");
        bool isActive = bool.Parse(Console.ReadLine());

        string query = "INSERT INTO brands (Name, Country, FoundedYear, IsActive) VALUES (@Name, @Country, @FoundedYear, @IsActive)";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Parameters.AddWithValue("@FoundedYear", foundedYear);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} brand(s) added successfully ✅");
        }
    }

    static void ReadBrands()
    {
        string query = "SELECT * FROM brands";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("\n--- BRANDS ---");
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Country: {reader["Country"]}, FoundedYear: {reader["FoundedYear"]}, IsActive: {reader["IsActive"]}");
                }
            }
        }
    }

    static void UpdateBrand()
    {
        ReadBrands();
        Console.Write("\nEnter the ID of the brand you want to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Brand Name: ");
        string name = Console.ReadLine();

        Console.Write("New Country: ");
        string country = Console.ReadLine();

        Console.Write("New Founded Year: ");
        int foundedYear = int.Parse(Console.ReadLine());

        Console.Write("Is Active (true/false): ");
        bool isActive = bool.Parse(Console.ReadLine());

        string query = "UPDATE brands SET Name = @Name, Country = @Country, FoundedYear = @FoundedYear, IsActive = @IsActive WHERE Id = @Id";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Parameters.AddWithValue("@FoundedYear", foundedYear);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} brand(s) updated ✅");
        }
    }

    static void DeleteBrand()
    {
        ReadBrands();
        Console.Write("\nEnter the ID of the brand you want to delete: ");
        int id = int.Parse(Console.ReadLine());

        string query = "DELETE FROM brands WHERE Id = @Id";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} brand(s) deleted 🗑️");
        }
    }

    static void ReadProjects()
    {
        string query = "SELECT * FROM Projects";
        List<Dictionary<string, string>> projects = new List<Dictionary<string, string>>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // Step 1: Read all projects
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var project = new Dictionary<string, string>
                    {
                        ["ProjectId"] = reader["ProjectId"].ToString(),
                        ["ProjectName"] = reader["ProjectName"].ToString(),
                        ["Location"] = reader["Location"].ToString(),
                        ["StartDate"] = Convert.ToDateTime(reader["StartDate"]).ToShortDateString(),
                        ["CompanyId"] = reader["CompanyId"].ToString()
                    };

                    projects.Add(project);
                }
            }

            // Step 2: For each project, get company name from Brands table
            foreach (var project in projects)
            {
                string brandQuery = "SELECT Name FROM Brands WHERE Id = @companyId";
                using (SqlCommand brandCmd = new SqlCommand(brandQuery, conn))
                {
                    brandCmd.Parameters.AddWithValue("@companyId", project["CompanyId"]);
                    using (SqlDataReader brandReader = brandCmd.ExecuteReader())
                    {
                        if (brandReader.Read())
                        {
                            project["CompanyName"] = brandReader["Name"].ToString();
                        }
                        else
                        {
                            project["CompanyName"] = "Unknown";
                        }
                    }
                }

                // Step 3: Display the result
                Console.WriteLine($"\nProject ID: {project["ProjectId"]}");
                Console.WriteLine($"Project Name: {project["ProjectName"]}");
                Console.WriteLine($"Location: {project["Location"]}");
                Console.WriteLine($"Start Date: {project["StartDate"]}");
                Console.WriteLine($"Company ID: {project["CompanyId"]}");
                Console.WriteLine($"Company Name: {project["CompanyName"]}");
            }
        }
    }

}

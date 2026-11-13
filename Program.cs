using G_NET68_EF_Assignment_4.Context;
using G_NET68_EF_Assignment_4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace G_NET68_EF_Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new Appdbcontext();

            #region seeddata
            //if (!dbContext.Branches.Any())
            //{
            //    var branches = new List<Branch>
            //    {
            //        new Branch
            //        {
            //            Name = "Cairo Main Branch",
            //            Address = "15 Tahrir Square, Downtown, Cairo",
            //            PhoneNumber = "0225741001"
            //        },
            //        new Branch
            //        {
            //            Name = "Alexandria Branch",
            //            Address = "42 Fouad Street, Attarin, Alexandria",
            //            PhoneNumber = "034872002"
            //        },
            //        new Branch
            //        {
            //            Name = "El Sheikh Zayed Branch",
            //            Address = "26th of July Corridor, El Sheikh Zayed, Giza",
            //            PhoneNumber = "0238503003"
            //        }
            //    };
            //    dbContext.Branches.AddRange(branches);
            //    dbContext.SaveChanges();

            //    if (!dbContext.Managers.Any())
            //    {
            //        var managers = new List<Manager>
            //        {
            //            new Manager
            //            {
            //                FullName = "Tarek El-Masry",
            //                Email = "tarek.elmasry@nationalbank.eg",
            //                PhoneNumber = "01001112233",
            //                HireDate = new DateTime(2019, 3, 15),
            //                BranchID = branches[0].Code
            //            },
            //            new Manager
            //            {
            //                FullName = "Nadia Mansour",
            //                Email = "nadia.mansour@nationalbank.eg",
            //                PhoneNumber = "01004445566",
            //                HireDate = new DateTime(2020, 7, 1),
            //                BranchID = branches[1].Code
            //            },
            //            new Manager
            //            {
            //                FullName = "Karim Hassan",
            //                Email = "karim.hassan@nationalbank.eg",
            //                PhoneNumber = "01007778899",
            //                HireDate = new DateTime(2021, 11, 10),
            //                BranchID = branches[2].Code
            //            }
            //        };

            //        dbContext.Managers.AddRange(managers);
            //        dbContext.SaveChanges();
            //    }
            //}
            #endregion

            while (true)
            {
                Console.Clear();
                Console.WriteLine("National Bank Management");
                Console.WriteLine("====================================");
                Console.WriteLine("1) Add a new Customer");
                Console.WriteLine("2) Open a new Account for a Customer");
                Console.WriteLine("3) Update Account Status (Active / Closed)");
                Console.WriteLine("4) Remove an Account from a Customer");
                Console.WriteLine("5) List all Customers (with accounts)");
                Console.WriteLine("0) Exit");
                Console.WriteLine();
                Console.Write("Enter choice: ");

                string? choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddNewCustomer(dbContext);
                        Pause();
                        break;
                    case "2":
                        OpenNewAccount(dbContext);
                        Pause();
                        break;
                    case "3":
                        UpdateAccountStatus(dbContext);
                        Pause();
                        break;
                    case "4":
                        RemoveAccountFromCustomer(dbContext);
                        Pause();
                        break;
                    case "5":
                        ListAllCustomers(dbContext);
                        Pause();
                        break;
                    case "0":
                        Console.WriteLine("Closing connection and exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 5.");
                        Pause();
                        break;
                }
            }
        }

        static void AddNewCustomer(Appdbcontext dbContext)
        {
            Console.WriteLine("Add New Customer");

            string fullName = ReadRequiredString("Full Name        : ");
            string nationalId = ReadRequiredString("National ID      : ");
            DateTime dateOfBirth = ReadDate("Date of Birth (yyyy-MM-dd): ");
            string email = ReadRequiredString("Email            : ");
            string phone = ReadRequiredString("Phone            : ");
            string address = ReadRequiredString("Address          : ");

            Console.WriteLine("Customer Type:");
            Console.WriteLine("1) Individual");
            Console.WriteLine("2) Business");
            int typeChoice = ReadChoiceInRange("Choice: ", 1, 2);
            string customerType = typeChoice == 1 ? "Individual" : "Business";

            var customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                CustomerType = customerType
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            Console.WriteLine($"Customer created successfully. CustomerId = {customer.Id}");
        }

        static void OpenNewAccount(Appdbcontext dbContext)
        {
            Console.WriteLine("Open New Account");

            Console.Write("Is this a new account? (y/n): ");
            bool isNew = Console.ReadLine()?.Trim().Equals("y", StringComparison.OrdinalIgnoreCase) ?? true;

            int existingAccountNumber = 0;
            string accountType = "Savings";

            if (!isNew)
            {
                existingAccountNumber = ReadInt("Existing Account Number: ");
            }
            else
            {
                Console.WriteLine("Account Type:");
                Console.WriteLine("1) Savings");
                Console.WriteLine("2) Current");
                Console.WriteLine("3) Business");
                int accountTypeChoice = ReadChoiceInRange("Choice: ", 1, 3);
                accountType = accountTypeChoice switch
                {
                    1 => "Savings",
                    2 => "Current",
                    _ => "Business"
                };
            }

            int branchCode = ReadInt("Branch Code      : ");
            int customerId = ReadInt("Customer Id      : ");

            Console.WriteLine("Ownership Role:");
            Console.WriteLine("1) Primary");
            Console.WriteLine("2) CoHolder");
            int roleChoice = ReadChoiceInRange("Choice: ", 1, 2);
            string ownershipRole = roleChoice == 1 ? "Primary" : "CoHolder";

            Console.WriteLine($"Validating branch '{branchCode}' and customer #{customerId}...");

            var branch = dbContext.Branches.Find(branchCode);
            if (branch is null)
            {
                Console.WriteLine($"Error: Branch with code '{branchCode}' does not exist.");
                return;
            }

            var customer = dbContext.Customers.Find(customerId);
            if (customer is null)
            {
                Console.WriteLine($"Error: Customer #{customerId} does not exist.");
                return;
            }

            Account targetAccount;

            if (isNew)
            {
                targetAccount = new Account
                {
                    AccountType = accountType,
                    CurrentBalance = 0m,
                    OpeningDate = DateTime.Now,
                    BranchID = branchCode
                };

                dbContext.Accounts.Add(targetAccount);
                dbContext.SaveChanges();
            }
            else
            {
                var found = dbContext.Accounts.Find(existingAccountNumber);
                if (found is null)
                {
                    Console.WriteLine($"Error: Account '{existingAccountNumber}' does not exist.");
                    return;
                }

                bool alreadyLinked = dbContext.CustomerAccounts
                    .Any(ca => ca.AccountId == existingAccountNumber && ca.CustomerId == customerId);

                if (alreadyLinked)
                {
                    Console.WriteLine($"Error: Customer #{customerId} is already linked to account '{existingAccountNumber}'.");
                    return;
                }

                targetAccount = found;
            }

            var customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountId = targetAccount.AccountNumber,
                OwnershipType = ownershipRole,
                OwnershipStartDate = DateTime.Now,
                AccountStatus = "Active"
            };

            dbContext.CustomerAccounts.Add(customerAccount);
            dbContext.SaveChanges();

            Console.WriteLine($"Account {targetAccount.AccountNumber} created and linked to customer {customerId} as {ownershipRole} owner.");
        }
        static void UpdateAccountStatus(Appdbcontext dbContext)
        {
            Console.WriteLine("Update Account Status");

            int accountNumber = ReadInt("Account Number   : ");
            int customerId = ReadInt("Customer Id      : ");

            var customerAccount = dbContext.CustomerAccounts
                .FirstOrDefault(ca => ca.AccountId == accountNumber && ca.CustomerId == customerId);

            if (customerAccount is null)
            {
                Console.WriteLine($"Error: No ownership record found for Account '{accountNumber}' and Customer #{customerId}.");
                return;
            }

            Console.WriteLine("New Status:");
            Console.WriteLine("1) Active");
            Console.WriteLine("2) Closed");
            int statusChoice = ReadChoiceInRange("Choice: ", 1, 2);

            customerAccount.AccountStatus = statusChoice == 1 ? "Active" : "Closed";
            dbContext.SaveChanges();

            Console.WriteLine($"Status updated to {customerAccount.AccountStatus}.");
        }

        static void RemoveAccountFromCustomer(Appdbcontext dbContext)
        {
            Console.WriteLine("Remove Account From Customer");

            int accountNumber = ReadInt("Account Number   : ");
            int customerId = ReadInt("Customer Id      : ");

            var customerAccount = dbContext.CustomerAccounts
                .FirstOrDefault(ca => ca.AccountId == accountNumber && ca.CustomerId == customerId);

            if (customerAccount is null)
            {
                Console.WriteLine($"Error: No ownership record found for Account '{accountNumber}' and Customer #{customerId}.");
                return;
            }

            dbContext.CustomerAccounts.Remove(customerAccount);
            dbContext.SaveChanges();
            Console.WriteLine("Ownership link deleted.");

            bool hasOtherOwners = dbContext.CustomerAccounts.Any(ca => ca.AccountId == accountNumber);
            if (!hasOtherOwners)
            {
                var account = dbContext.Accounts.Find(accountNumber);
                if (account is not null)
                {
                    dbContext.Accounts.Remove(account);
                    dbContext.SaveChanges();
                    Console.WriteLine($"That was the last owner — account '{accountNumber}' was also removed.");
                }
            }
        }

        static void ListAllCustomers(Appdbcontext dbContext)
        {
            Console.WriteLine("All Customers");

            var customers = dbContext.Customers
                .Include(c => c.customerAccounts)
                    .ThenInclude(ca => ca.Account)
                        .ThenInclude(a => a.branch)
                .AsNoTracking()
                .ToList();

            if (!customers.Any())
            {
                Console.WriteLine("No customers found.");
                return;
            }
            
            foreach (var customer in customers)
            {
                Console.WriteLine($"#{customer.Id} {customer.FullName} ({customer.CustomerType})");

                if (!customer.customerAccounts.Any())
                {
                    Console.WriteLine("   (no accounts)");
                }
                else
                {
                    foreach (var ca in customer.customerAccounts)
                    {
                        var acc = ca.Account;
                        string branchName = acc.branch?.Name ?? "Unknown Branch";
                        Console.WriteLine($"   {acc.AccountNumber}  {acc.AccountType,-8}  Balance: {acc.CurrentBalance,12:N2}  {ca.OwnershipType,-8}  {ca.AccountStatus,-6}  @ {branchName}");
                    }
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to return to the menu...");
            Console.ReadKey(true);
        }

        static string ReadRequiredString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine()?.Trim(), out int result))
                    return result;

                Console.WriteLine("Invalid number. Please enter a valid integer.");
            }
        }

        static int ReadChoiceInRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine()?.Trim(), out int choice) && choice >= min && choice <= max)
                    return choice;

                Console.WriteLine($"Invalid choice. Please enter a number between {min} and {max}.");
            }
        }

        static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine()?.Trim();
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                    return date;

                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd (e.g., 2000-01-25).");
            }
        }
    }
}
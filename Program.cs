using G_NET68_EF_Assignment_4.Context;
using G_NET68_EF_Assignment_4.Models;
using Microsoft.EntityFrameworkCore;

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
            //        }
            //        }
            #endregion

                }
            }
        }
    



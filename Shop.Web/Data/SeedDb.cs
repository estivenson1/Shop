namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            if (!this.context.Countries.Any())
            {
                var cities = new List<City>();
                cities.Add(new City { Name = "Medellín" });
                cities.Add(new City { Name = "Bogotá" });
                cities.Add(new City { Name = "Calí" });

                this.context.Countries.Add(new Country
                {
                    Cities = cities,
                    Name = "Colombia"
                });

                await this.context.SaveChangesAsync();
            }



            var user = await this.userHelper.GetUserByEmailAsync("csharp_eov@hotmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Estivenson",
                    LastName = "Ortega Villar",
                    Email = "csharp_eov@hotmail.com",
                    UserName = "csharp_eov@hotmail.com",
                    PhoneNumber="3017915843",
                    Address = "Calle Luna Calle Sol",
                    CityId = this.context.Countries.FirstOrDefault().Cities.FirstOrDefault().Id,
                    City = this.context.Countries.FirstOrDefault().Cities.FirstOrDefault()

                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
                var token = await this.userHelper.GenerateEmailConfirmationTokenAsync(user);
                await this.userHelper.ConfirmEmailAsync(user, token);

            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product", user);
                this.AddProduct("Second Product", user);
                this.AddProduct("Third Product", user);
                await this.context.SaveChangesAsync();
            }
        }


        //if (!this.context.Products.Any())
        //{
        //    this.AddProduct("iPhone X");
        //    this.AddProduct("Magic Mouse");
        //    this.AddProduct("iWatch Series 4");
        //    await this.context.SaveChangesAsync();
        //}


        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }


}



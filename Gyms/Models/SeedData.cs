using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gyms.Models
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GymsContext(
                serviceProvider.GetRequiredService<DbContextOptions<GymsContext>>()))
            {
                if (!context.Client.Any())
                    context.Client.AddRange(
                        new Client
                        {
                            Name = "Test",
                            DateOfBirth = DateTime.Parse("1980-01-01")
                        },
                        new Client
                        {
                            Name = "Test 1",
                            DateOfBirth = DateTime.Parse("1990-01-01")
                        },
                        new Client
                        {
                            Name = "Test 2",
                            DateOfBirth = DateTime.Parse("2000-01-01")
                        }
                    );

                if (!context.Instructor.Any())
                    context.AddRange(
                        new Instructor
                        {
                            Name = "Test",
                            DateOfBirth = DateTime.Parse("1980-01-01")
                        },
                        new Instructor
                        {
                            Name = "Test 1",
                            DateOfBirth = DateTime.Parse("1990-01-01")
                        },
                        new Instructor
                        {
                            Name = "Test 2",
                            DateOfBirth = DateTime.Parse("2000-01-01")
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
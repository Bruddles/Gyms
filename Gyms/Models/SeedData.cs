using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;

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
                            FirstName = "Test",
                            Surname = "Test",
                            DateOfBirth = DateTime.Parse("1980-01-01")
                        },
                        new Client
                        {
                            FirstName = "Test 1",
                            Surname = "Test 1",
                            DateOfBirth = DateTime.Parse("1990-01-01")
                        },
                        new Client
                        {
                            FirstName = "Test 2",
                            Surname = "Test 2",
                            DateOfBirth = DateTime.Parse("2000-01-01")
                        }
                    );

                if (!context.Instructor.Any())
                    context.AddRange(
                        new Instructor
                        {
                            FirstName = "Test",
                            Surname = "Test",
                            DateOfBirth = DateTime.Parse("1980-01-01")
                        },
                        new Instructor
                        {
                            FirstName = "Test 1",
                            Surname = "Test 1",
                            DateOfBirth = DateTime.Parse("1990-01-01")
                        },
                        new Instructor
                        {
                            FirstName = "Test 2",
                            Surname = "Test 2",
                            DateOfBirth = DateTime.Parse("2000-01-01")
                        }
                    );

                if (!context.Class.Any())
                    context.AddRange(
                        new Class
                        {
                            Name = "Class 1",
                            Instructor = context.Instructor.FirstOrDefault(),
                            Duration = Duration.FromHours(1),
                            Date = new DateTime(2018, 1, 1, 12, 00, 00)
                        });

                if (!context.ClassAttendance.Any())
                    context.AddRange(
                        new ClassAttendance
                        {
                            Class = context.Class.FirstOrDefault(),
                            Client = context.Client.FirstOrDefault()
                        }
                    );
                
                context.SaveChanges();
            }
        }
    }
}
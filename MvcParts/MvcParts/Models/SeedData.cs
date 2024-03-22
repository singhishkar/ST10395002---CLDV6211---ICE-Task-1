using Microsoft.EntityFrameworkCore;
using MvcParts.Data;

namespace MvcParts.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPartsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPartsContext>>()))
            {
                // Look for any Partss.
                if (context.Parts.Any())
                {
                    return;   // DB has been seeded
                }
                context.Parts.AddRange(
                    new Parts
                    {
                        Code = "176357",
                        Name = "Timing Chain",
                        partManufacturer = "Continental",
                        carManufacturer = "BMW",
                        carModel = "335i",
                        Description = "Everything you need to service your timing chain is included, down to the last bolt.",
                        Category = "Engine",
                        Quantity = 2,
                        Price = 7299,
                        Location = "Shelf A"
                    },
                    new Parts
                    {
                        Code = "284519",
                        Name = "Brake Pad Set",
                        partManufacturer = "Brembo",
                        carManufacturer = "Audi",
                        carModel = "A4",
                        Description = "High-performance brake pads designed for maximum stopping power and durability.",
                        Category = "Braking System",
                        Quantity = 4,
                        Price = 2999,
                        Location = "Shelf B"
                    }
,
                    new Parts
                    {
                        Code = "843612",
                        Name = "Air Filter",
                        partManufacturer = "K&N",
                        carManufacturer = "Toyota",
                        carModel = "Camry",
                        Description = "Reusable and washable air filter designed to improve airflow and engine performance.",
                        Category = "Filters",
                        Quantity = 6,
                        Price = 1499,
                        Location = "Shelf C"
                    },
                    new Parts
                    {
                        Code = "632145",
                        Name = "Radiator",
                        partManufacturer = "Valeo",
                        carManufacturer = "Volkswagen",
                        carModel = "Golf GTI",
                        Description = "OEM-quality aluminum radiator designed for efficient cooling and durability.",
                        Category = "Cooling System",
                        Quantity = 3,
                        Price = 3899,
                        Location = "Shelf F"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
using FoodTrucksMenus.Data.Entities;

namespace FoodTrucksMenus.Data
{
    public class SeedDB
    {
        public readonly DataContext _context;

        public SeedDB(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoryAsync();
            await CheckPlatformsAsync();
            await CheckContriesAsync();
        }

        private async Task CheckPlatformsAsync()
        {
            if (!_context.Platforms.Any())
            {
                _context.Platforms.Add(new Platform { Name = "Hugo" , IconLogo = "hugo.png"});
                _context.Platforms.Add(new Platform { Name = "PedidosYa", IconLogo = "pedidosyalogo.png" });
                _context.Platforms.Add(new Platform { Name = "Uber Eats ", IconLogo = "ubereat.png" });
                _context.Platforms.Add(new Platform { Name = "DiDi Food", IconLogo = "didifood.png" });
                _context.Platforms.Add(new Platform { Name = "Rapi", IconLogo = "rappi.png" });
                _context.Platforms.Add(new Platform { Name = "InDriver", IconLogo = "indriver.png" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckContriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Republica Dominicana",
                    States = new List<State>()
                    {
                        new State() {
                            Name ="Santo Domingo",
                            Cities = new List<City>()
                            {
                                new City {Name = "Santo Domingo Este"},
                                new City {Name = "Santo Domingo Norte"},
                                new City {Name = "Santo Domingo Oeste"},
                                new City {Name = "Distito Nacional"}
                            }
                        },
                        new State() {
                            Name ="Santiago",
                            Cities = new List<City>()
                            {
                                new City {Name = "Cien fuegos"},
                                new City {Name = "Licey"}
                            }
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State() {
                            Name = "Florida",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Orlando" },
                                new City() { Name = "Miami" },
                                new City() { Name = "Tampa" },
                                new City() { Name = "Fort Lauderdale" },
                                new City() { Name = "Key West" },
                            }
                        },
                        new State() {
                            Name = "Texas",
                            Cities = new List<City>() {
                                new City() { Name = "Houston" },
                                new City() { Name = "San Antonio" },
                                new City() { Name = "Dallas" },
                                new City() { Name = "Austin" },
                                new City() { Name = "El Paso" },
                            }
                        },
                        new State() {
                            Name = "California",
                            Cities = new List<City>() {
                                new City() { Name = "Los Angeles" },
                                new City() { Name = "San Francisco" },
                                new City() { Name = "San Diego" },
                                new City() { Name = "San Bruno" },
                                new City() { Name = "Sacramento" },
                                new City() { Name = "Fresno" },
                            }
                        },
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCategoryAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { NameCat = "Carnes" });
                _context.Categories.Add(new Category { NameCat = "Empanadas" });
                _context.Categories.Add(new Category { NameCat = "Sopas" });
                _context.Categories.Add(new Category { NameCat = "Bebidas" });
                _context.Categories.Add(new Category { NameCat = "Batidos" });
                _context.Categories.Add(new Category { NameCat = "Jugos" });
                _context.Categories.Add(new Category { NameCat = "Cervesas" });
                _context.Categories.Add(new Category { NameCat = "Pastas" });
                _context.Categories.Add(new Category { NameCat = "Postres" });

                await _context.SaveChangesAsync();
            }
        }
    }
}

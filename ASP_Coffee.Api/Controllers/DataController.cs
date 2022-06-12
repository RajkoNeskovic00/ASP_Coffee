using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Coffee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
       private readonly Coffee_Context _context;
       public DataController(Coffee_Context context)
        {
            _context = context;
        }

        // POST api/<DataController>
        [HttpPost]
        public IActionResult Post()
        {
           
                var origins = new List<Origin>
                {
                    new Origin
                    {
                        Name = "Indonesia"
                    },
                    new Origin
                    {
                        Name = "Columbia"
                    },
                    new Origin
                    {
                        Name = "Vietnam"
                    },
                    new Origin
                    {
                        Name = "Brazil"
                    },
                    new Origin
                    {
                        Name = "Ethiopia"
                    }
                };

                var beans = new List<Bean>
                {
                    new Bean
                    {
                        Name = "Arabica"
                    },
                    new Bean
                    {
                        Name = "Robusta"
                    },
                    new Bean
                    {
                        Name = "Liberica"
                    },
                    new Bean
                    {
                        Name = "Excelsa"
                    }
                };

                var coffees = new List<Coffee>
                {
                    new Coffee
                    {
                        Name = "Ethiopian Lion",
                        Description = "Black Lion Coffee drum roasts coffee beans daily in small batches and deliver promptly to our customers to ensure they enjoy maximum quality from our brand. ",
                        ImagePath = "ethLion.jpg",
                        Bean = beans.ElementAt(0),
                        Origin = origins.ElementAt(4)
                    },
                    new Coffee
                    {
                        Name = "Serrano Lavado",
                        Description = "Our Coffee comes from the 2,700 tonnes produced in the Sierra Maestra Mountain area between 1st January and 31st March 2018. From a flavour point of view, our Cuban Serrano Lavado gives an intense rich flavour of Swiss Chocolate, Peanuts, Caramel and Tobacco with a very sweet aroma",
                        ImagePath = "lavadoSer.jpg",
                        Bean = beans.ElementAt(1),
                        Origin = origins.ElementAt(2)
                    },
                    new Coffee
                    {
                        Name = "Black Diamond",
                        Description = "Since our founding we have been supplying an engagingly superior coffee blend to our food store and restaurant customers in Brooklyn, Queens and on Long Island.",
                        ImagePath = "blackDia.jpg",
                        Bean = beans.ElementAt(0),
                        Origin = origins.ElementAt(0)
                    },
                    new Coffee
                    {
                        Name = "Night Blend",
                        Description = "Sweet and smooth with notes of dark chocolate, candied stone fruits, and sweet caramel. Night Moves blend is appealing to those who love drinking dark roasted coffee, but without the bitterness they might expect.",
                        ImagePath = "nightBle.jpg",
                        Bean = beans.ElementAt(2),
                        Origin = origins.ElementAt(2)
                    },
                    new Coffee
                    {
                        Name = "Maragogype",
                        Description = "Maragogype is an arabica bean, grown in Guatemala, also referred to as “Elephant Bean” due to its large size. Grown high up, and wet-processed, the coffee is mellow and rich but with fine acidity and notes of tropical fruit. Roasted as a full roast, slightly darker than a medium, the oils are just breaking through.",
                        ImagePath = "maragogype.jpg",
                        Bean = beans.ElementAt(3),
                        Origin = origins.ElementAt(3)
                    },
                    new Coffee
                    {
                        Name = "Cruz Grande",
                        Description = "This coffee only roasts and ships on Mondays. All orders placed after midnight on Sunday night will be roasted and shipped the following Monday.",
                        ImagePath = "cruz.jpg",
                        Bean = beans.ElementAt(0),
                        Origin = origins.ElementAt(0)
                    },
                    new Coffee
                    {
                        Name = "Supremo",
                        Description = "Our fresh roasted Colombian Supremo coffee is a rich, perfectly roasted coffee house staple. With alluring notes of honey and cherry, a balanced body, bold flavor and bright finish, this medium roast coffee is an excellent choice for any coffee lover!",
                        ImagePath = "supremo.jpg",
                        Bean = beans.ElementAt(0),
                        Origin = origins.ElementAt(1)
                    },
                    new Coffee
                    {
                        Name = "Brazilian Tiger",
                        Description = "Our new coffee is a combination of two great single origin coffees, Brazil Rainforest Alliance Yellow Bourbon and Indian Tiger Mountain, together with our popular blend Mocha Harari. The result is a medium strength, full bodied flavour with a sweet aftertaste on the palette.",
                        ImagePath = "brazTiger.jpg",
                        Bean = beans.ElementAt(0),
                        Origin = origins.ElementAt(3)
                    },
                    new Coffee
                    {
                        Name = "Brazilian Coffee",
                        Description = "A great high quality Brazil coffee is soft, nutty, low acid, with nice bittersweet chocolate tastes. It is also quite an exceptional base for making flavored coffees because of it's softness in the cup.",
                        ImagePath = "brazCoffee.jpg",
                        Bean = beans.ElementAt(0),
                        Origin = origins.ElementAt(3)
                    },
                };

                var amounts = new List<Amount>
                {
                    new Amount
                    {
                        AmountPack = 250
                    },
                    new Amount
                    {
                        AmountPack = 500
                    },
                    new Amount
                    {
                        AmountPack = 1000
                    }
                };

                var AmountCoffees = new List<AmountCoffee>
                {
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(0),
                        Amount = amounts.ElementAt(0),
                        Price = 220
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(0),
                        Amount = amounts.ElementAt(1),
                        Price = 240
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(0),
                        Amount = amounts.ElementAt(2),
                        Price = 260
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(1),
                        Amount = amounts.ElementAt(0),
                        Price = 220
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(1),
                        Amount = amounts.ElementAt(1),
                        Price = 230
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(1),
                        Amount = amounts.ElementAt(2),
                        Price = 240
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(2),
                        Amount = amounts.ElementAt(0),
                        Price = 265
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(2),
                        Amount = amounts.ElementAt(1),
                        Price = 270
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(2),
                        Amount = amounts.ElementAt(2),
                        Price = 290
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(3),
                        Amount = amounts.ElementAt(1),
                        Price = 260
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(4),
                        Amount = amounts.ElementAt(1),
                        Price = 240
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(4),
                        Amount = amounts.ElementAt(2),
                        Price = 270
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(5),
                        Amount = amounts.ElementAt(0),
                        Price = 210
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(5),
                        Amount = amounts.ElementAt(1),
                        Price = 230
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(6),
                        Amount = amounts.ElementAt(0),
                        Price = 245
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(6),
                        Amount = amounts.ElementAt(1),
                        Price = 290
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(6),
                        Amount = amounts.ElementAt(2),
                        Price = 299
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(7),
                        Amount = amounts.ElementAt(0),
                        Price = 300
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(7),
                        Amount = amounts.ElementAt(2),
                        Price = 320
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(8),
                        Amount = amounts.ElementAt(1),
                        Price = 330
                    },
                    new AmountCoffee
                    {
                        Coffee = coffees.ElementAt(8),
                        Amount = amounts.ElementAt(2),
                        Price = 370
                    }
                };

                var roles = new List<Role>
                {
                    new Role
                    {
                        Name = "Admin"
                    },
                    new Role
                    {
                        Name = "User"
                    }
                };

                var users = new List<User>
                {
                    new User
                    {
                        FirstName = "Rajko",
                        LastName = "Neskovic",
                        Email = "neskovic@gmail.com",
                        Password = "sifra123",
                        Role = roles.ElementAt(0)
                    },
                    new User
                    {
                        FirstName = "Pera",
                        LastName = "Peric",
                        Email = "peric@gmail.com",
                        Password = "sifra11",
                        Role = roles.ElementAt(1)
                    },
                    new User
                    {
                        FirstName = "Mika",
                        LastName = "Mikic",
                        Email = "mikic@gmail.com",
                        Password = "sifra22",
                        Role = roles.ElementAt(1)
                    },
                    new User
                    {
                        FirstName = "Laza",
                        LastName = "Lazic",
                        Email = "laza@gmail.com",
                        Password = "sifra33",
                        Role = roles.ElementAt(1)
                    },
                };

                _context.Beans.AddRange(beans);
                _context.Origins.AddRange(origins);
                _context.Amounts.AddRange(amounts);
                _context.Coffees.AddRange(coffees);
                _context.AmountCoffees.AddRange(AmountCoffees);
                _context.Roles.AddRange(roles);
                _context.Users.AddRange(users);

                _context.SaveChanges();

                return StatusCode(201, new { message = "The data was successfully entered into the database." });
            }
            

        

       
        
    }
}

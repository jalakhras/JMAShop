using JMAShop.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JMAShopTest.Model
{
    public class RepositoryMocks
    {
        public static Mock<IItemRepository> GetItemRepository()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Apple Item",
                    Price = 12.95M,
                    ShortDescription = "Our famous apple items!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Fruit items"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/appleitem.jpg",
                    InStock = true,
                    IsItemOfTheWeek = true,
                    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/appleitemsmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Blueberry Cheese Cake",
                    Price = 18.95M,
                    ShortDescription = "You'll love it!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Cheese cakes"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
                    InStock = true,
                    IsItemOfTheWeek = false,
                    ImageThumbnailUrl =
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecakesmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Cheese Cake",
                    Price = 18.95M,
                    ShortDescription = "Plain cheese cake. Plain pleasure.",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Cheese cakes"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
                    InStock = true,
                    IsItemOfTheWeek = false,
                    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Cherry Item",
                    Price = 15.95M,
                    ShortDescription = "A summer classic!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Fruit items"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherryitem.jpg",
                    InStock = true,
                    IsItemOfTheWeek = false,
                    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherryitemsmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Christmas Apple Item",
                    Price = 13.95M,
                    ShortDescription = "Happy holidays with this item!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Seasonal items"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasappleitem.jpg",
                    InStock = true,
                    IsItemOfTheWeek = false,
                    ImageThumbnailUrl =
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasappleitemsmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Cranberry Item",
                    Price = 17.95M,
                    ShortDescription = "A Christmas favorite",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Seasonal items"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberryitem.jpg",
                    InStock = true,
                    IsItemOfTheWeek = false,
                    ImageThumbnailUrl =
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberryitemsmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Peach Item",
                    Price = 15.95M,
                    ShortDescription = "Sweet as peach",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Fruit items"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachitem.jpg",
                    InStock = false,
                    IsItemOfTheWeek = false,
                    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachitemsmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Pumpkin Item",
                    Price = 12.95M,
                    ShortDescription = "Our Halloween favorite",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Seasonal items"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinitem.jpg",
                    InStock = true,
                    IsItemOfTheWeek = true,
                    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinitemsmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Rhubarb Item",
                    Price = 15.95M,
                    ShortDescription = "My God, so sweet!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Fruit items"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbitem.jpg",
                    InStock = true,
                    IsItemOfTheWeek = true,
                    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbitemsmall.jpg",
                    AllergyInformation = ""
                },
                new Item
                {
                    Name = "Strawberry Item",
                    Price = 15.95M,
                    ShortDescription = "Our delicious strawberry item!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake item chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon item muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart item cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Category = Categories["Fruit items"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberryitem.jpg",
                    InStock = true,
                    IsItemOfTheWeek = false,
                    ImageThumbnailUrl =
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberryitemsmall.jpg",
                    AllergyInformation = ""
                },
            };

            var mockItemRepository = new Mock<IItemRepository>();
            mockItemRepository.Setup(repo => repo.Items).Returns(items);
            mockItemRepository.Setup(repo => repo.GetItemById(It.IsAny<int>())).Returns(items[0]);
            return mockItemRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Fruit Items",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Cheese cakes",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Fruit Items",
                    Description = "Seasonal items"
                }
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.Categories).Returns(categories);

            return mockCategoryRepository;
        }

        private static Dictionary<string, Category> _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Fruit items" },
                        new Category { CategoryName = "Cheese cakes" },
                        new Category { CategoryName = "Seasonal items" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (var genre in genresList)
                    {
                        _categories.Add(genre.CategoryName, genre);
                    }
                }

                return _categories;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Com.Jamim.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Com.Jamim.Model.Entities;
    using Com.Jamim.Model.Carts;
    using Com.Jamim.Model.Catalog;
    using Com.Jamim.Model.Customers;
    using Com.Jamim.Model.Locations;
    using Com.Jamim.Model.Manufacturers;
    using Com.Jamim.Model.Orders;
    using Com.Jamim.Model.Products;
    using Com.Jamim.Model.Retailers;
    using Com.Jamim.Model.Stores;
    using Com.Jamim.Model.Taxes;
    using Com.Jamim.Model.ValueObjects;

    using Com.Jamim.Model.Images;

    internal sealed class Configuration : DbMigrationsConfiguration<Com.Jamim.Repository.JamimDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(Com.Jamim.Repository.JamimDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            #region "useful-code"
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            #endregion

            #region "ImagePath Seed"
            var ImagePaths = new List<ImagePath>
            {
                new ImagePath{Path="Products/Grocery"},
                new ImagePath{Path="Products/Diary"},
                new ImagePath{Path="Products/Pantry"},
                new ImagePath{Path="Products/HomeCare"},
                new ImagePath{Path="Products/PersonalCare"},
                new ImagePath{Path="Products/Beverages"},
                new ImagePath{Path="Products/Organic"},
                new ImagePath{Path="Products/FruitsAndVegetables"},
                new ImagePath{Path="Customer/Avatar"},
                new ImagePath{Path="Retailer/Avatar"}

            };
            ImagePaths.ForEach(s => context.ImagePaths.AddOrUpdate(s));
            context.SaveChanges();

            #endregion

            #region "ImageType Seed"

            var ImageTypes = new List<ImageType>
            {
                new ImageType{Type="png"},
                new ImageType{Type="jpg"},
                new ImageType{Type="tif"},
                new ImageType{Type="weppy"}
            };
            ImageTypes.ForEach(s => context.ImageTypes.AddOrUpdate(s));
            context.SaveChanges();
            #endregion

            #region "Image Seed"

            var Images = new List<Image>
            {
                new Image{ Name="horlicks", ImagePathId=1, ImageTypeId=2 }
            };
            Images.ForEach(s => context.Images.AddOrUpdate(s));
            context.SaveChanges();
            #endregion

            #region "Group Seed"

            var Groups = new List<Group>
            {
                new Group{ Name = "Grocery", Description = "All househlod grocery"},
                new Group{ Name="Diary", Description = "All milk products"},
                new Group{ Name = "Pantry", Description = "Breakfast, fast foods, snacks related items"},
                new Group{ Name = "Home Care",Description = "Home Care Related Products"},
                new Group{ Name="Personal Care",Description = "Stuffs related to personal care like cosmetics, beauty products, hair care and a lot more"},
                new Group{ Name = "Beverages", Description = "All types of beverages like cold drinks, energy drinks etc" },
                new Group{ Name= "Organic", Description = "Fresh Organic Foods" },
                new Group{ Name = "Fruits and Vegetables", Description = "Fresh Fruits and Vegetables"}

            };

            Groups.ForEach(s => context.Groups.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            #endregion

            #region "Category seed"

            var Categories = new List<Category>
            {
                // Grocery Related SubCategories
                new Category 
                { 
                    Name = "dry fruits and nuts",
                    Description = "porcessed dry fruits and nuts of various brands",
                    GroupId = Groups.Single(s=>s.Name == "Grocery").Id,
                    ImageId = null
                },
                new Category
                {
                    Name = "dals and pulses",
                    Description = "packaged dals and pulse like red, green, black, yellow",
                    GroupId = Groups.Single(s=>s.Name == "Grocery").Id,
                    ImageId = null
                },
                 new Category
                {
                    Name = "edible oils and ghees",
                    Description = "Refined, Mustard, coconut oils and ghee of various brands",
                    GroupId = Groups.Single(s=>s.Name == "Grocery").Id,
                    ImageId = null
                },
                 new Category
                {
                    Name = "flours",
                    Description = "wheat flour, mix flour, gram flour etc from various brands",
                    GroupId = Groups.Single(s=>s.Name == "Grocery").Id,
                    ImageId = null
                },
                 new Category
                {
                    Name = "masala and spices",
                    Description = "mix and tradional indian spices of various brands",
                    GroupId = Groups.Single(s=>s.Name == "Grocery").Id,
                    ImageId = null
                },
                 new Category
                {
                    Name = "rice and rice products",
                    Description = "various type of rice and their products",
                    GroupId = Groups.Single(s=>s.Name == "Grocery").Id,
                    ImageId = null
                },
                 new Category
                {
                    Name = "salt sugar and jaggery",
                    Description = "salt, sugar and  jaggery items",
                    GroupId = Groups.Single(s=>s.Name == "Grocery").Id,
                    ImageId = null
                },

                // Diary Related SubproductTypes
                new Category 
                {
                    Name = "milk",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Diary").Id,
                    ImageId = null
                },
                new Category 
                {
                    Name = "condensed milk",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Diary").Id,
                    ImageId = null
                },
                new Category 
                {
                    Name = "flavoured milk",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Diary").Id,
                    ImageId = null
                },
                new Category 
                {
                    Name = "cream",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Diary").Id,
                    ImageId = null
                },
                new Category 
                {
                    Name = "buttermilk",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Diary").Id,
                    ImageId = null
                },
                new Category 
                {
                    Name = "butter",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Diary").Id,
                    ImageId = null
                },
                new Category 
                {
                    Name = "lassi",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Diary").Id,
                    ImageId = null
                },

                // Pantry Related SubproductTypes
                new Category 
                {
                    Name = "noodles and vermicelli",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },
                new Category 
                {
                    Name = "jams & spreads",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },
                new Category 
                {
                    Name = "pickles & papads",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },

                new Category 
                {
                    Name = "sauces & ketchup",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },

                new Category 
                {
                    Name = "baking",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },

                new Category 
                {
                    Name = "buiscuits, cookies & rusk",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },
                 new Category 
                {
                    Name = "snacks",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },
                 new Category 
                {
                    Name = "Instant foods & ready mix",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },
                 new Category 
                {
                    Name = "candies",
                    Description = null,
                    GroupId = Groups.Single(s=>s.Name == "Pantry").Id,
                    ImageId = null
                },


                // Home Care 
                new Category
                {
                    Name = "Laundry",
                    Description = "Shop, Detergent etc of varios brands",
                    GroupId = Groups.Single(s=>s.Name == "Home Care").Id,
                    ImageId = null
                },
                new Category
                {
                    Name = "Cleaning",
                    Description = "various room and kitchen cleaning items",
                    GroupId = Groups.Single(s=>s.Name == "Home Care").Id,
                    ImageId = null
                },
                new Category
                {
                    Name = "Paper & Plastics",
                    Description = "various products of paper and plastics",
                    GroupId = Groups.Single(s=>s.Name == "Home Care").Id,
                    ImageId = null
                },
                new Category
                {
                    Name = "Freshners",
                    Description = "room freshners of various brands",
                    GroupId = Groups.Single(s=>s.Name == "Home Care").Id,
                    ImageId = null
                },
                new Category
                {
                    Name = "Fight Mosquitoes",
                    Description = "various mosquitoes liquidator, coils and cake",
                    GroupId = Groups.Single(s=>s.Name == "Home Care").Id,
                    ImageId =null
                },


            };


            Categories.ForEach(s => context.Categories.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            #endregion

            #region "Units Seed"

            var Units = new List<Unit>
            {
                new Unit
                {
                    Notation = "gm",
                    Description = "grams"
                },
                new Unit
                {
                    Notation = "kg",
                    Description = "kilograms"
                },
                new Unit
                {
                    Notation = "ml",
                    Description = "milliliter"
                },
                new Unit
                {
                    Notation = "l",
                    Description = "liter"
                },
                new Unit
                {
                    Notation = "mm",
                    Description = "millimeter"
                },
                new Unit
                {
                    Notation = "cm",
                    Description = "centimeter"
                },
                new Unit
                {
                    Notation = "m",
                    Description = "meter"
                },
                new Unit
                {
                    Notation = "doz",
                    Description = "dozen"
                }


            };

            Units.ForEach(s => context.Units.AddOrUpdate(x => x.Notation, s));
            context.SaveChanges();


            #endregion

            #region "Tax Seed"

            var taxes = new List<Tax>
            {
                new Tax
                {
                    Type = "VAT",
                    Description = "Value Added Tax"
                },
                new Tax
                {
                    Type = "ST",
                    Description = "Service Tax"
                }
            };
            taxes.ForEach(s => context.Taxs.AddOrUpdate(s));
            context.SaveChanges();

            #endregion

            #region "TaxRate Seed"

            var taxrates = new List<TaxRate>
            {
                new TaxRate
                {
                    TaxId = 1,
                    Rate = 12.24,
                    CreatedDate = DateTime.Parse("2015-03-01"),
                    ModifiedDate = DateTime.Parse("2015-03-01")
                },
                new TaxRate
                {
                    TaxId = 2,
                    Rate = 22.20,
                    CreatedDate = DateTime.Parse("2015-03-01"),
                    ModifiedDate = DateTime.Parse("2015-03-01")
                }

            };

            taxrates.ForEach(s => context.TaxRates.AddOrUpdate(s));
            context.SaveChanges();

            #endregion

            #region "Manufacturer Seed"

            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Name = "Indian Tobacco Company",
                    NameShrtDesc = "ITC",
                    ManufacturerURL = "www.itc.com"
                },
                new Manufacturer
                {
                    Name = "Hindustan Unilever Limited",
                    NameShrtDesc = "HUL",
                    ManufacturerURL = "www.hul.com/india"
                },
                new Manufacturer
                {
                    Name = "Procter & Gamble",
                    NameShrtDesc = "PNG",
                    ManufacturerURL = "www.png.in"
                },
                new Manufacturer
                {
                    Name = "Nestle India",
                    NameShrtDesc = "Nestle",
                    ManufacturerURL = "www.nestle-india.com"
                }


            };
            manufacturers.ForEach(s => context.Manufacturers.AddOrUpdate(s));
            context.SaveChanges();

            #endregion
            #region "weight seed"
            var weights = new List<Weight>
            {
                new Weight
                {
                     Name="100"
                },
                new Weight{
                    Name="250"
                },
                new Weight
                {
                    Name ="500"
                },
                new Weight
                {
                   Name = "1000"
                }

            };

            weights.ForEach(s => context.Weights.AddOrUpdate(s));
            context.SaveChanges();
            #endregion
            #region "Product seed"

            var products = new List<Product>
            {
                new Product
                {
                    CategoryId = 1,
                    Name = "Almonds",
                    ShortDescription = "Dry Brown Nilgiri Almonds",
                    Description = "Almonds are one of the world’s most nutritious and versatile nuts, renowned for their many health benefits and culinary uses",
                    CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=1,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=220,
                    ItemsPerUnit=null,
                    WeightId=2
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Raw Cashews",
                    ShortDescription = "Raw cashews",
                    Description = "Cashews are more than just a good-for-you snack bursting with protein and nutrients, as you’ll discover once you taste our premium, jumbo-sized cashew nuts.",
                    CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=1,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=200,
                    ItemsPerUnit=null,
                    WeightId=2
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Salted Cashews",
                    ShortDescription = "Salted fried cashews",
                    Description = "Cashews are more than just a good-for-you snack bursting with protein and nutrients, as you’ll discover once you taste our premium, jumbo-sized cashew nuts.",
                    CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=2,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=300,
                    ItemsPerUnit=null,
                    WeightId=2
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Peanuts",
                    ShortDescription = "Raw dry peanuts",
                    Description = "Cashews are more than just a good-for-you snack bursting with protein and nutrients, as you’ll discover once you taste our premium, jumbo-sized cashew nuts.",
                    CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=2,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=290,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                    
                   CategoryId = 1,
                   Name = "Dates",
                   ShortDescription = "Seedless dates",
                   Description = "Date is full of protein and nutrients",
                   CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=3,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=100,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                   CategoryId = 2,
                   Name = "Toor Dal",
                   ShortDescription = "Loose toor dal",
                   Description = "Toor dal is full of protein and nutrients",
                   CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=2,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=700,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                   CategoryId = 2,
                   Name = "Udhaiyam Toor",
                   ShortDescription = "Udhaiyam Toor Dal",
                   Description = "Udhaiyam Toor Dal",
                  CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=4,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=185,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                   CategoryId = 2,
                   Name = "Urad Dal Whole Black",
                   ShortDescription = "Urad Dal Whole Black",
                   Description = "Urad Dal Whole Black",
                   CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=4,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=200,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                   CategoryId = 2,
                   Name = "Moong Dal Split",
                   ShortDescription = "Moong Dal Split",
                   Description = "Moong Dal Split",
                   CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=4,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=200,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                 CategoryId = 2,
                   Name = "Udhaiyam moong dal",
                   ShortDescription =  "Udhaiyam moong dal",
                   Description =  "Udhaiyam moong dal",
                  CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=4,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=200,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                    CategoryId = 3,
                   Name = "Gold Winner Refined Sunflower Oil 1 lt",
                   ShortDescription = "Gold Winner Refined Sunflower Oil 1 lt",
                   Description = "Gold Winner Refined Sunflower Oil 1 lt",
                 CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=3,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=76,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                      CategoryId = 3,
                   Name = "Fortune Sunlite Refined Sunflower Oil 5 lt Can",
                   ShortDescription = "Fortune Sunlite Refined Sunflower Oil 5 lt Can",
                   Description = "Fortune Sunlite Refined Sunflower Oil 5 lt Can",
                 CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=2,
                    TaxId=null,
                    ImageId=1,
                    IsActive=true,
                    MRP=200,
                    ItemsPerUnit=null,
                    WeightId=2
                },new Product
                {
                      CategoryId = 3,
                   Name = "Saffola Total Blended Vegetable Oil 5 lt. Free 1 lt",
                   ShortDescription = "Saffola Total Blended Vegetable Oil 5 lt. Free 1 lt",
                   Description = "Saffola Total Blended Vegetable Oil 5 lt. Free 1 lt",
               CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=1,
                    TaxId=null,
                      ImageId=1,
                    IsActive=true,
                    MRP=200,
                    ItemsPerUnit=null,
                    WeightId=2
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Fortune Filtered Mustard Oil 1 litre",
                    ShortDescription = "Fortune Filtered Mustard Oil 1 litre",
                    Description = "Fortune Filtered Mustard Oil 1 litre",
                    CreatedOrModifiedOn=DateTime.Parse("2015-03-01"),
                    CreatedOrModifiedBy = "JAMIM-AD-1112",
                    ApprovedOrCancelledOn=null,
                    ApprovedOrCancelledBy=null,
                    ApprovalStatus = ApprovalStatus.MarkedForApproval,
                    Notation=Units.Single(s=>s.Notation == "gm").Notation,
                    ManufacturerId=1,
                    TaxId=null,
                     ImageId=1,
                    IsActive=true,
                    MRP=200,
                    ItemsPerUnit=null,
                    WeightId=2
                }
            };
            products.ForEach(s => context.Products.AddOrUpdate(x => x.Name, s));
            context.SaveChanges();

            #endregion



            #region "Address seed"
            var addresses = new List<Address>
            {
                new Address
                {
                    Name = "Arvind Kumar",
                    AddressDetail = "Flat-402, Plot 23, Royal Homes, Arul Nagar, Urappakkam",
                    City = "Chennai",
                    Country = "India",
                    EMail = "avind.java@hotmail.com",
                    ContactNo = "9962995988",
                    ZipCode = "600089",
                    Latitude = 13.0827m,
                    Longitude = 80.2707m,
                    
                },
                new Address
                {
                    Name = "Asif Jamal",
                    AddressDetail = "Flat-403,Plot 23, Royal Homes, Arul Nagar, Urappakkam",
                    City = "Chennai",
                    Country = "India",
                    EMail = "asifrehankhan@hotmail.com",
                    ContactNo = "8056151164",
                    ZipCode = "600089",
                    Latitude = 13.0827m,
                    Longitude = 80.2707m,
                   
                },

                new Address
                {
                    Name = "Ikrar Ahmed",
                    AddressDetail = "Plot 12, Shine Super Market, Arul Nagar, Urappakkam",
                    City = "Chennai",
                    Country = "India",
                    EMail = "ikrarhusna@gmail.com",
                    ContactNo = "8056151765",
                    AlternateContactNo = "9965446734",
                    ZipCode = "600089",
                    Latitude = 13.0825m,
                    Longitude = 80.2704m,                  
                },
                new Address
                {
                    Name = "Adil Jamal",
                    AddressDetail = "Plot 78, Heritage Super Market, Shanti Nagar, Urappakkam",
                    City = "Chennai",
                    Country = "India",
                    EMail = "adiljamal@gmail.com",
                    ContactNo = "8056157856",
                    AlternateContactNo = "9965886734",
                    ZipCode = "600089",
                    Latitude = 13.0825m,
                    Longitude = 80.2704m,                  
                },
                new Address
                {
                    Name = "Ajeet Singh Parihar",
                    AddressDetail = "Plot 23, Reliance Super Market, Vigyan Nagar, Urappakkam",
                    City = "Chennai",
                    Country = "India",
                    EMail = "ajeetsingh@gmail.com",
                    ContactNo = "8053651765",
                    AlternateContactNo = "8095446721",
                    ZipCode = "600089",
                    Latitude = 13.0825m,
                    Longitude = 80.2704m,                  
                },
                new Address
                {
                    Name = "Imran Khan",
                    AddressDetail = "Plot 12, Chennai Super Market, Arul Nagar, Urappakkam",
                    City = "Chennai",
                    Country = "India",
                    EMail = "imrankhan@gmail.com",
                    ContactNo = "8054581726",
                    AlternateContactNo = "9916754734",
                    ZipCode = "600088",
                    Latitude = 13.0825m,
                    Longitude = 80.2704m,                  
                },
                new Address
                {
                    Name = "Shaswat Rai",
                    AddressDetail = "Plot 12, Shaswat Provision Store, Arul Nagar, Urappakkam",
                    City = "Chennai",
                    Country = "India",
                    EMail = "ikrarhusna@gmail.com",
                    ContactNo = "8056151765",
                    AlternateContactNo = "9965446734",
                    ZipCode = "600088",
                    Latitude = 13.0825m,
                    Longitude = 80.2704m,                  
                },

            };

            addresses.ForEach(s => context.Addresses.AddOrUpdate(x => x.Name, s));
            context.SaveChanges();

            #endregion

            #region "Customer seed"

            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName="Arvind",
                    LastName = "Kumar",
                    Image = null,
                    AddressId = addresses.Single(i=>i.Name == "Arvind Kumar" ).Id,    
                },
                new Customer 
                {
                    FirstName = "Asif",
                    LastName = "Jamal",
                    Image = null,
                   AddressId = addresses.Single(i=>i.Name == "Asif Jamal" ).Id,
                }
            };

            customers.ForEach(s => context.Customers.AddOrUpdate(x => x.FirstName, s));
            context.SaveChanges();

            #endregion

            #region "ServiceArea Seed"

            var serviceareas = new List<ServiceArea>
            {
                new ServiceArea
                {
                    CityShrtDesc = "SACHEN",
                    City = "Chennai",
                    State = "Tamil Nadu",
                    IsActive = true
                },
                new ServiceArea
                {
                    CityShrtDesc = "SALUCK",
                    City = "Lucknow",
                    State = "Uttar Pradesh",
                    IsActive = false
                },
                new ServiceArea
                {
                    CityShrtDesc = "SAALLD",
                    City = "Allahabad",
                    State = "Uttar Pradesh",
                    IsActive = true
                }
            };

            serviceareas.ForEach(s => context.ServiceAreas.AddOrUpdate(x => x.CityShrtDesc, s));
            context.SaveChanges();

            #endregion

            #region "Region Seed"

            var regions = new List<Region>
            {
                new Region
                {
                    RegionDesc = "Urappakkam, South Chennai",
                    ZipCode = "600089",
                    ServiceAreaId = serviceareas.Single(i=>i.CityShrtDesc == "SACHEN").Id,

                },
                new Region
                {
                    RegionDesc = "arul nagar, west urappakkam",
                    ZipCode = "600091",
                    ServiceAreaId = serviceareas.Single(i=>i.CityShrtDesc == "SACHEN").Id,

                },
                new Region
                {
                    RegionDesc = "Karely",
                    ZipCode = "822564",
                    ServiceAreaId = serviceareas.Single(i=>i.CityShrtDesc == "SAALLD").Id,                    
                }
            };

            regions.ForEach(s => context.Regions.AddOrUpdate(x => x.RegionDesc, s));
            context.SaveChanges();

            #endregion

            #region "Retailer Seed"

            var retailers = new List<Retailer>
            {
                new Retailer
                {
                    FirstName = "Ikrar",
                    LastName = "Ahmed",
                    Image = null,
                    RetailerCategory = RetailerCategory.Freemium,
                    AddressId = addresses.Single(i=>i.Name == "Ikrar Ahmed" ).Id,               
                    Rating = Rating.Excellent,
                    RegionId = regions.Single(i => i.RegionDesc == "arul nagar, west urappakkam").Id

                },
                new Retailer
                {
                    FirstName = "Adil",
                    LastName = "Jamal",
                    Image = null,
                    RetailerCategory = RetailerCategory.Freemium,
                    AddressId = addresses.Single(i=>i.Name == "Adil Jamal" ).Id,               
                    Rating = Rating.Poor,
                    RegionId = regions.Single(i => i.RegionDesc.Contains("arul nagar, west urappakkam")).Id

                },
                new Retailer
                {
                    FirstName = "Ajeet",
                    LastName = "Singh Parihar",
                    Image = null,
                    RetailerCategory = RetailerCategory.Freemium,
                    AddressId = addresses.Single(i=>i.Name == "Ajeet Singh Parihar" ).Id,               
                    Rating = Rating.Average,
                    RegionId = regions.Single(i => i.RegionDesc.Contains("arul nagar, west urappakkam")).Id

                }
            };

            retailers.ForEach(s => context.Retailers.AddOrUpdate(x => x.FirstName, s));
            context.SaveChanges();

            #endregion


            #region "Store seed"


            var stores = new List<Store>
            {
                new Store
                {
                      Name = "Shine super market",
                      Description="get grocery delivered to your doorsteps",
                      RegionId = 1,
                      RetailerId = 1,
                      StoreType = StoreType.Grocery,
                      Status = Status.Open,                    
                },
                new Store
                {
                      Name = "WallMart",
                      Description="get grocery delivered to your doorsteps",
                      RegionId = 1,
                      RetailerId = 2,
                      StoreType = StoreType.Grocery,
                      Status = Status.Open,                    
                },
                new Store
                {
                      Name = "Rite Buy Super Market",
                      Description="get grocery delivered to your doorsteps",
                      RegionId = 1,
                      RetailerId = 3,
                      StoreType = StoreType.Grocery,
                      Status = Status.Open,                    
                }

            };
            stores.ForEach(s => context.Stores.AddOrUpdate(s));
            context.SaveChanges();
            #endregion

            #region "CatagoryAccess Seed"
            var categoryaccess = new List<CategoryAccess>
            {
                new CategoryAccess
                {
                    RetailerId=1,
                    CategoryId=1
                },
                new CategoryAccess
                {
                    RetailerId=1,
                    CategoryId=2
                },new CategoryAccess
                {
                    RetailerId=1,
                    CategoryId=3
                },new CategoryAccess
                {
                    RetailerId=1,
                    CategoryId=4
                },new CategoryAccess
                {
                    RetailerId=1,
                    CategoryId=5
                },new CategoryAccess
                {
                    RetailerId=1,
                    CategoryId=6
                },new CategoryAccess
                {
                    RetailerId=1,
                    CategoryId=7
                },new CategoryAccess
                {
                    RetailerId=1,
                    CategoryId=8
                },
                new CategoryAccess
                {
                    RetailerId=2,
                    CategoryId=1
                },new CategoryAccess
                {
                    RetailerId=2,
                    CategoryId=2
                },new CategoryAccess
                {
                    RetailerId=3,
                    CategoryId=3
                },
            };

            categoryaccess.ForEach(s => context.CategoryAccess.AddOrUpdate(s));
            context.SaveChanges();
            #endregion





        }
    }
}


//namespace Com.Jamim.Repository.Migrations
//{
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<Com.Jamim.Repository.JamimDataContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false;
//        }

//        protected override void Seed(Com.Jamim.Repository.JamimDataContext context)
//        {
//            //  This method will be called after migrating to the latest version.

//            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
//            //  to avoid creating duplicate seed data. E.g.
//            //
//            //    context.People.AddOrUpdate(
//            //      p => p.FullName,
//            //      new Person { FullName = "Andrew Peters" },
//            //      new Person { FullName = "Brice Lambson" },
//            //      new Person { FullName = "Rowan Miller" }
//            //    );
//            //
//        }
//    }
//}

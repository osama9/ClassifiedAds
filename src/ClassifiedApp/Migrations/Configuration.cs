namespace ClassifiedApp.Migrations
{
    using ClassifiedApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassifiedApp.DAL.ClassifiedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClassifiedApp.DAL.ClassifiedContext context)
        {
            #region InitializeCategory
            IList<Category> defaultCategories = new List<Category>();
            defaultCategories.Add(new Category() { EnglishName = "Video Games", ArabicName = "ألعاب كونسول" });
            defaultCategories.Add(new Category() { EnglishName = "Appliances", ArabicName = "ÃÌåÒÉ" });
            defaultCategories.Add(new Category() { EnglishName = "Auto Parts", ArabicName = "قطع غيار" });
            defaultCategories.Add(new Category() { EnglishName = "Baby & Kid Stuff", ArabicName = "منتجات الأطفال" });
            defaultCategories.Add(new Category() { EnglishName = "Bicycles", ArabicName = "الدراجات" });
            defaultCategories.Add(new Category() { EnglishName = "Boats", ArabicName = "الفوارب" });
            defaultCategories.Add(new Category() { EnglishName = "Books", ArabicName = "الكتب" });
            defaultCategories.Add(new Category() { EnglishName = "Clothing & Accessories", ArabicName = "ملابس واكسسورات" });
            defaultCategories.Add(new Category() { EnglishName = "Collectibles", ArabicName = "التحف الفنية" });
            defaultCategories.Add(new Category() { EnglishName = "Computers", ArabicName = "كومبيوترات" });
            defaultCategories.Add(new Category() { EnglishName = "Electronics", ArabicName = "الكترونيات" });
            defaultCategories.Add(new Category() { EnglishName = "Free Items", ArabicName = "أدوات للتنازل" });
            defaultCategories.Add(new Category() { EnglishName = "Furniture", ArabicName = "أثاث" });
            defaultCategories.Add(new Category() { EnglishName = "Health & Beauty", ArabicName = "الصحة والجمال" });
            defaultCategories.Add(new Category() { EnglishName = "Household Items", ArabicName = "أدوات منزلية" });
            defaultCategories.Add(new Category() { EnglishName = "Jewelry", ArabicName = "مجوهرات" });
            //defaultCategories.Add(new Category() { EnglishName = "Materials", ArabicName = "ãæÇÏ" });
            defaultCategories.Add(new Category() { EnglishName = "Mobile Phones", ArabicName = "الجوالات" });
            defaultCategories.Add(new Category() { EnglishName = "Motorcycles", ArabicName = "الدراجات النارية" });
            defaultCategories.Add(new Category() { EnglishName = "Musical Instruments", ArabicName = "أدوات موسيقية" });
            defaultCategories.Add(new Category() { EnglishName = "Photo & Video", ArabicName = "صور وفيديو" });
            defaultCategories.Add(new Category() { EnglishName = "Sports", ArabicName = "أدوات رياضية" });
            defaultCategories.Add(new Category() { EnglishName = "Tablets", ArabicName = "أجهزة لوحية" });
            defaultCategories.Add(new Category() { EnglishName = "Tickets", ArabicName = "تذاكر" });
            //defaultCategories.Add(new Category() { EnglishName = "Tools", ArabicName = "ÃÏæÇÊ ÚÏÉ" });
            defaultCategories.Add(new Category() { EnglishName = "Toys & Games", ArabicName = "ألعاب أطفال" });
            defaultCategories.Add(new Category() { EnglishName = "Vehicles", ArabicName = "مركبات" });

            foreach (Category category in defaultCategories)
            {
                context.Categories.AddOrUpdate(category);
            }
            #endregion InitializeCategory

            #region InitializeCountry
            IList<Country> defaultCountries = new List<Country>();
            defaultCountries.Add(new Country() { ArabicName = "المملكة العربية السعودية", EnglishName = "Saudi Arabia" });
            foreach (Country country in defaultCountries)
            {
                context.Countries.Add(country);
            }


            #endregion

            #region InitializeCity
            IList<City> defaultCities = new List<City>();
            Country defaultCountry = context.Countries.Where(x => x.CountryId == 1).FirstOrDefault();
            defaultCities.Add(new City() { ArabicName = "أبها", EnglishName = "Abha", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الباحة", EnglishName = "Al-Baha", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الأحساء", EnglishName = "Al-Hasa", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الخرج", EnglishName = "Al-Kharj", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "عرعر", EnglishName = "Arar", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "بريدة", EnglishName = "Buraidah", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الدمام", EnglishName = "Dammam", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الظهران", EnglishName = "Dhahran", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "حفر الباطن", EnglishName = "Hafar Al-Batin", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "حائل", EnglishName = "Hail", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "جده", EnglishName = "Jeddah", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "جيزان", EnglishName = "Jizan", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الجبيل", EnglishName = "Jubail", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الخفجي", EnglishName = "Khafji", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الخبر", EnglishName = "Khobar", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "المدينة المنورة", EnglishName = "Madinah", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "مكة المكرمة", EnglishName = "Makkah", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "رابغ", EnglishName = "Rabigh", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "رأس تنورة", EnglishName = "Ras Tanura", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الرياض", EnglishName = "Riyadh", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "تبوك", EnglishName = "Tabouk", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "الطائف", EnglishName = "Taif", Country = defaultCountry });
            defaultCities.Add(new City() { ArabicName = "ينبع", EnglishName = "Yanbu", Country = defaultCountry });

            foreach (City city in defaultCities)
            {
                context.Cities.Add(city);
            }
            #endregion InitializeCity

            context.SaveChanges();
        }
    }
}

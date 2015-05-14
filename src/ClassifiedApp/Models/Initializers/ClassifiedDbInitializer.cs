using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassifiedApp.DAL;
using System.Data.Entity;

namespace ClassifiedApp.Models.Initializers
{
    public class ClassifiedDbInitializer<T> : DropCreateDatabaseIfModelChanges<ClassifiedContext>
    {
        protected override void Seed(ClassifiedContext context)
        {
            
            

            base.Seed(context);
        }
    }
}
namespace BigRock.Migrations
{
    using BigRock.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BigRock.Models.BigRockConnection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BigRock.Models.BigRockConnection context)
        {
            context.Person.AddOrUpdate(i => i.LastName,
                new Person
                {
                    FirstName = "Tristan",
                    MiddleName = "Hobart",
                    LastName = "Mendenhall",
                    FamilyCode = "0000",
                    TypeCode = Person.TypeCodes.Parent
                },
                new Person
                {
                    FirstName = "Emily",
                    MiddleName = "Wilkins",
                    LastName = "Mendenhall",
                    FamilyCode = "0000",
                    TypeCode = Person.TypeCodes.Parent
                },
                new Person
                {
                    FirstName = "Hayden",
                    MiddleName = "Reed",
                    LastName = "Mendenhall",
                    FamilyCode = "0000",
                    TypeCode = Person.TypeCodes.Child
                },
                new Person
                {
                    FirstName = "Alden",
                    MiddleName = "Pierce",
                    LastName = "Mendenhall",
                    FamilyCode = "0000",
                    TypeCode = Person.TypeCodes.Child
                });
        }
    }
}

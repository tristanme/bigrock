namespace BigRock.Migrations
{
    using BigRock.Models;
    using BigRock.Models.Helpers;
    using System;
    using System.Collections.Generic;
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
            Address homeAddress = new Address
            {
                Block = "310 Cypress Walk Way",
                City = "Charleston",
                ZipCode = "29492"
            };

            context.Person.AddOrUpdate(i => new { i.FirstName, i.LastName, i.FamilyCode },
                new Person
                {
                    FirstName = "Tristan",
                    MiddleName = "Hobart",
                    LastName = "Mendenhall",
                    FamilyCode = "0000",
                    TypeCode = Enumerations.TypeCodes.Parent,
                    Address = homeAddress
                },
                new Person
                {
                    FirstName = "Emily",
                    MiddleName = "Wilkins",
                    LastName = "Mendenhall",
                    FamilyCode = "0000",
                    TypeCode = Enumerations.TypeCodes.Parent,
                    Address = homeAddress
                },
                new Person
                {
                    FirstName = "Hayden",
                    MiddleName = "Reed",
                    LastName = "Mendenhall",
                    FamilyCode = "0000",
                    TypeCode = Enumerations.TypeCodes.Child,
                    Address = homeAddress
                },
                new Person
                {
                    FirstName = "Alden",
                    MiddleName = "Pierce",
                    LastName = "Mendenhall",
                    FamilyCode = "0000",
                    TypeCode = Enumerations.TypeCodes.Child,
                    Address = homeAddress
                });
        }
    }
}

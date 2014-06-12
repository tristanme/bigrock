using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Text;
using System.Collections.Generic;
using BigRock.Models.Helpers;

namespace BigRock.Models
{
    public class BigRockConnection : DbContext
    {
        public DbSet<Person> Person { get; set; }
    }

    public class Person
    {

        [Key]
        public int ID { get; set; }

        [Display(Name = "First name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Middle name")]
        [DataType(DataType.Text)]
        public string MiddleName { get; set; }

        [Display(Name = "Last name")]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string DisplayName
        {
            get
            {
                return BuildDisplayName();
            }
        }

        [Display(Name = "Family code")]
        [DataType(DataType.Text)]
        [StringLength(4, MinimumLength = 4)]
        [RegularExpression(@"^\d+$", ErrorMessage = "The family code must be exactly four numbers each between 0-9.")]
        [Required]
        public string FamilyCode { get; set; }

        [Display(Name = "Security card")]
        [DataType(DataType.Text)]
        public string SecurityCard { get; set; }

        [Display(Name = "Type")]
        [EnumDataType(typeof(Enumerations.TypeCodes))]
        [Required]
        public Enumerations.TypeCodes TypeCode { get; set; }

        [Display(Name = "Other")]
        [DataType(DataType.Text)]
        public string TypeCodeOther { get; set; }

        public Address Address { get; set; }

        #region Helper functions

        private string BuildDisplayName()
        {
           // TODO: add support for name formatting functions
            StringBuilder nameBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(this.FirstName))
            {
                nameBuilder.Append(this.FirstName);
            }

            if (!string.IsNullOrEmpty(this.MiddleName))
            {
                nameBuilder.Append(string.Format(" {0}.", this.MiddleName.Substring(0, 1)));
            }

            if (nameBuilder.Length > 0)
            {
                nameBuilder.Append(" ");
            }

            nameBuilder.Append(this.LastName);

            return nameBuilder.ToString();

        }

        #endregion
    }
}
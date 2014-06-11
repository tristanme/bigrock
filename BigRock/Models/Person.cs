using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;

namespace BigRock.Models
{
    public class Person
    {
        public enum TypeCodes
        {
            [Description("Parent")]
            Parent,

            [Description("Child")]
            Child,

            [Description("Employee")]
            Employee,

            [Description("Other")]
            Other
        }
 
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

        [Display(Name = "Family code")]
        [DataType(DataType.Text)]
        [StringLength(4, MinimumLength = 4)]
        [RegularExpression(@"^\d+$",ErrorMessage = "The family code must be exactly four numbers each between 0-9.")]
        [Required]
        public string FamilyCode { get; set; }

        [Display(Name = "Security card")]
        [DataType(DataType.Text)]
        public string SecurityCard { get; set; }

        [Display(Name = "Type")]
        [EnumDataType(typeof(TypeCodes))]
        [Required]
        public TypeCodes TypeCode { get; set; }

        [Display(Name = "Other")]
        [DataType(DataType.Text)]
        public string TypeCodeOther { get; set; }
    }

    public class BigRockConnection : DbContext
    {
        public DbSet<Person> Person { get; set; }
    }
}
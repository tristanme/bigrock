using System.ComponentModel;

namespace BigRock.Models.Helpers
{
    public sealed class Enumerations
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

    }
}
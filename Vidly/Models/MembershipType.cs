using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public static readonly byte Unknown = 0;

        public static readonly byte PayAsYouGo = 1;

        public byte Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
    }
}
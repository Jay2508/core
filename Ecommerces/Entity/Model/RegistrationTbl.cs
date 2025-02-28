using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWithNTierEcommerceDotNETCORE.Entity.Model
{
    [Table("RegistrationTbl")]
    public class RegistrationTbl
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

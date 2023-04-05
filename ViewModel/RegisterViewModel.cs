using System.ComponentModel.DataAnnotations;

namespace Kotabko.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string userName { set; get; }

        [DataType(DataType.Password)]
        public string password { set; get; }

        [DataType(DataType.Password)]
        [Compare("password")]
        public string Confirmpassword { set; get; }
        public string city {set; get; }
        public string governorate { set; get; }
        public string Image { set; get; }
    }
}

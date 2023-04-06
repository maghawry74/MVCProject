using System.ComponentModel.DataAnnotations;

namespace Kotabko.ViewModel
{
    public class LoginViewModel
    {
        public string userName { set; get; }

        [DataType(DataType.Password)]
        public string password { set; get; }
       
        public bool remmemberMe { set; get; }
    }
}

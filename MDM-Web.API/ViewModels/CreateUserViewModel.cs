using FluentValidation;

namespace MDM_Web.API.ViewModels
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    
}
namespace Project.App.Models
{
    public class UserEditViewModel : UserIndexViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Message { get; set; }
    }
}
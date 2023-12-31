﻿namespace APPVIEW.ViewModels
{
    public class RegisterVm
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public Guid  ?Id_Role { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }=string.Empty;
        public string ?ResetPasswordcode { get; set; }
        public string ?ConfirmPassword { get; set; }
    }
}

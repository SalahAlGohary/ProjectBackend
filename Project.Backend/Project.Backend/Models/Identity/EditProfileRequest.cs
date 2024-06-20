namespace NativeBackend.Application.Common.Models.Identity
{
    public class EditProfileRequest
    {
        public string? userId { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? TwitterUserName { get; set; }
    }
}

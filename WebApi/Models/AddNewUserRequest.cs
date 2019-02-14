using WebApi.Entity;

namespace WebApi.Models
{
    public class AddNewUserRequest
    {
        public UserDto User { get; set; }
        public AddressDto Address { get; set; }
    }
}
using System;

namespace WebService.DTOs
{
    public class UserForCreateOrUpdateDto
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

using logo_odev4.Business.DTOs;

namespace logo_odev4.Business.Abstracts
{
    public interface IJwtService
    {
        TokenDto Authenticate(UserDto user);
    }
}

using be.DTOs;

namespace be.Services.IServices
{
    public interface IAuthService
    {
        Task RegisterUser(SignUpDTO signUpDTO);
        Task LoginUser(LoginDTO loginDTO);  
    }
}

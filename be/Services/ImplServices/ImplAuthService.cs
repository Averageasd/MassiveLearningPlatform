using be.DBContext;
using be.DTOs;
using be.Services.IServices;

namespace be.Services.ImplServices
{
    public class ImplAuthService : IAuthService
    {

        private DapperContext _context;
        public ImplAuthService(DapperContext dapperContext)
        {
            _context = dapperContext;
        }
        public Task LoginUser(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public Task RegisterUser(SignUpDTO signUpDTO)
        {
            throw new NotImplementedException();
        }
    }
}

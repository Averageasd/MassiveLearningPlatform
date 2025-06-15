using be.DBContext;
using be.DTOs;
using be.Services.IServices;
using Dapper;
using System.Data;
using System.Data.Common;

namespace be.Services.ImplServices
{
    public class ImplAuthService : IAuthService
    {

        private DapperContext _context;
        private IJwtService _jwtService;
        public ImplAuthService(DapperContext dapperContext, IJwtService jwtService)
        {
            _context = dapperContext;
            _jwtService = jwtService;
        }
        public async Task<AuthenticatedUserDTO> LoginUser(LoginDTO loginDTO)
        {
            try
            {
                using (IDbConnection connection = _context.CreateConnection())
                {
                    string query = "SELECT [user].Id, [user].UserName, [user].Age, [user].DateJoin FROM [dbo].[User] AS [user] WHERE [user].UserName = @UserName AND [user].UserPassword = @UserPassword";
                    var authenticatedUserDTO = await connection.QueryFirstOrDefaultAsync<AuthenticatedUserDTO>(query, new
                    {
                        UserName = loginDTO.UserName,
                        UserPassword = loginDTO.Password
                    });
                    if (authenticatedUserDTO == null)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    var token = _jwtService.GenerateToken(authenticatedUserDTO.Id);
                    authenticatedUserDTO.Token = token;
                    return authenticatedUserDTO;
                }
            }
            catch (DbException)
            {
                throw;
            }

        }

        public async Task RegisterUser(SignUpDTO signUpDTO)
        {
            try
            {
                using (IDbConnection connection = _context.CreateConnection())
                {
                    string query = "INSERT INTO [dbo].[User] (UserName, Age, UserPassword) VALUES (@UserName, @Age, @UserPassword)";

                    await connection.ExecuteAsync(query, new
                    {
                        UserName = signUpDTO.UserName,
                        UserPassword = signUpDTO.Password
                    });
                }
            }
            catch (DbException)
            {
                throw;
            }

        }
    }
}

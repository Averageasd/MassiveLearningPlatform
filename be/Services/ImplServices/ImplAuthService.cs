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
        public ImplAuthService(DapperContext dapperContext)
        {
            _context = dapperContext;
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
                        Age = signUpDTO.Age,
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

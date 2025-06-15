namespace be.Services.IServices
{
    public interface IJwtService
    {
        public string GenerateToken(int userId);
    }
}

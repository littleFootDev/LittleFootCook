using LittleFootCook.Application.DTOs;
using LittleFootCook.Application.Interfaces;

namespace LittleFootCook.API.Endpoints
{
    public static class AuthEndpoint
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/auth");

            
            group.MapPost("/register", Register);
            group.MapPost("/login", Login);

        }

        private static async Task<IResult> Register(RegisterDto dto, IAuthService service)
        {
            try
            {
                var result = await service.RegisterAsync(dto);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }


        }
        private static async Task<IResult> Login(LoginDto dto, IAuthService service)
        {
            try
            {
                var result = await service.LoginAsync(dto);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }

}

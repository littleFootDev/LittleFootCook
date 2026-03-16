using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.DTOs;

namespace LittleFootCook.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}

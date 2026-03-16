using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Application.DTOs
{
    public record AuthResponseDto
    (
        string Token,
        string Email,
        string Username,
        DateTime ExpiresAt
    );
}

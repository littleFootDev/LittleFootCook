using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Application.DTOs
{
    public record RegisterDto
    (
        string Email,
        string Password,
        string Username
    );
}

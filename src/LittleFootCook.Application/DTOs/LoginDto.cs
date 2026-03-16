using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Application.DTOs
{
    public record LoginDto
   (
        string Email,
        string Password
    );
}

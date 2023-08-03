﻿using Backend.Dto.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Backend.Dto.Auth.Login;

public class LoginResponseDto : EntityDto
{
    public string Email { get; set; }
    public string Token { get; set; }
    
    /// <summary>
    /// Using in Swagger UI
    /// </summary>
    public string SchemeForSwagger => JwtBearerDefaults.AuthenticationScheme + " " + Token;
}
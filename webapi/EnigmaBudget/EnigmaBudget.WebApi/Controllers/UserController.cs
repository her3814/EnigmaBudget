﻿using EnigmaBudget.Infrastructure.Auth;
using EnigmaBudget.Infrastructure.Auth.Model;
using EnigmaBudget.Infrastructure.Auth.Requests;
using EnigmaBudget.Infrastructure.Auth.Responses;
using EnigmaBudget.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnigmaBudget.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IAuthService authSvc)
        {
            _logger = logger;
            _authService = authSvc;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ApiResponse<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = _authService.Login(request);

            return new ApiResponse<LoginResponse>(response.LoggedIn, response);
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public ApiResponse<SignUpInfo> SignUp(SignUpRequest request)
        {
            var res = _authService.SignUp(request);
            return new ApiResponse<SignUpInfo>(true, res);
        }

        [HttpGet("profile")]
        [Authorize]
        public ProfileResponse Profile()
        {
            return _authService.GetProfile();
        }

        [HttpPost("change-password")]
        [Authorize]
        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            return _authService.ChangePassword(request);

        }
    }
}
﻿using SapiensDataAPI.Dtos.Auth.Request;
using SapiensDataAPI.Dtos.Auth.Response;
using SapiensDataAPI.Models;
using System.Text.Json;

namespace SapiensDataAPI.Services.JwtToken
{
	public interface IJwtTokenService
	{
		Task<string> GenerateToken(ApplicationUserModel user);

		Task<RefreshTokenResponseDto> VerifyToken(TokenRequestDto tokenRequest);

		public JsonDocument DecodeJwtPayloadToJson(string token);
	}
}
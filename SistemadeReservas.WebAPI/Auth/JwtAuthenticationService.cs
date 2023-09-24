﻿using SistemadeReservas.EntidadesDeNegocio;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collection.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.WebAPI.Auth
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly string key;

        public JwtAuthenticationService(string key)
        {
            _key = key;
        }

        public string Authenticate (Usuario pUsuario)
        {

		//inyección de dependencias de la llave de autenticación
		private readonly string _key;
		public JwtAuthenticationService(string key)
		{
			_key = key;
		}

		public string Authenticate(Usuario pUsuario)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.ASCII.GetBytes(_key);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, pUsuario.Login)
				}),
				Expires = DateTime.UtcNow.AddHours(8),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}


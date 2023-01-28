using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WhatToDo.Logic.Common.AppConfig;

public record AuthOptions
{
    public string Issuer { get; init; }

    public string Audience { get; init; }

    public string SecretKey { get; init; }

    public int ExpireTimeTokenMinutes { get; init; }

    public SymmetricSecurityKey SymmetricSecurityKey
    {
        get
        {
            if (string.IsNullOrWhiteSpace(SecretKey))
            {
                throw new NullReferenceException(nameof(SecretKey));
            }

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        }
    }
}
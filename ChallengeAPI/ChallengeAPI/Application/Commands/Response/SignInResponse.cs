﻿namespace ChallengeAPI.Application.Commands.Response
{
    public class SignInResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}

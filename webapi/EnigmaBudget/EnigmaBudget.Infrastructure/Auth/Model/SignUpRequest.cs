﻿namespace EnigmaBudget.Infrastructure.Auth.Model
{
    public class SignUpResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool SignedUp { get; set; }
        public string? Reason { get; set; }

        public SignUpResponse()
        {
            SignedUp = false;
        }
    }
}

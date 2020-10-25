using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Shared.Models.Auth
{
    public class UserManagerResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string NickName { get; set; }

        public string Token { get; set; }

    }
}

using System.Collections.Generic;

namespace EcomApi.Services
{
    public interface ITokenBlacklistService
    {
        void AddToBlacklist(string token);
        bool IsTokenBlacklisted(string token);
    }

    public class TokenBlacklistService : ITokenBlacklistService
    {
        private readonly HashSet<string> _blacklistedTokens;

        public TokenBlacklistService()
        {
            _blacklistedTokens = new HashSet<string>();
        }

        public void AddToBlacklist(string token)
        {
            _blacklistedTokens.Add(token);
        }

        public bool IsTokenBlacklisted(string token)
        {
            return _blacklistedTokens.Contains(token);
        }
    }
}


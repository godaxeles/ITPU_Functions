using Functions.Task3.ThirdParty;

namespace Functions.Task3
{
    public abstract class UserService : IUserService
    {
        private readonly ISessionManager _sessionManager;

        protected UserService(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public bool TryLogin(string userName, string password)
        {
            return CheckOnValidAndSetCurrentUser(userName, password);
        }

        private bool CheckOnValidAndSetCurrentUser(string userName, string password)
        {
            var user = GetUserByName(userName);
            
            if (!IsPasswordCorrect(user, password))
            {
                return false;
            }
            
            _sessionManager.SetCurrentUser(user);
            return true;
        }

        public abstract bool IsPasswordCorrect(IUser user, string password);
        public abstract IUser GetUserByName(string userName);
    }
}
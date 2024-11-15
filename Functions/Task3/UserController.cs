using Functions.Task3.ThirdParty;

namespace Functions.Task3
{
    public abstract class UserController : IController
    {
        private readonly UserService _userService;

        protected UserController(UserService userService)
        {
            _userService = userService;
        }

        public void Authenticate(string userName, string password)
        {
            if (_userService.TryLogin(userName, password))
            {
                GenerateFailLoginResponse();
            }
            else
            {
                GenerateSuccessLoginResponse(userName);
            }
        }

        public abstract void GenerateSuccessLoginResponse(string user);
        public abstract void GenerateFailLoginResponse();
    }
}
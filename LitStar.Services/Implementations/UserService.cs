using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Core.Security;
using LitStar.Infrastructure.Querying;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.UserService;
using LitStar.Services.Mapping;
using LitStar.Services.Cache.CacheStorage;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public UserService(IUserRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        #region IUserService Members

        public GetAllUsersResponse GetAllUsers()
        {
            GetAllUsersResponse response = new GetAllUsersResponse();
            var accounts = _repository.FindAll();
            response.Users = accounts;
            return response;
        }

        public GetValidUserResponse AuthenticateUser(string email, string password)
        {
            GetValidUserResponse response = new GetValidUserResponse();
            var query = new Query();
            query.Add(new Criterion("Username", email, CriteriaOperator.Equal));
            query.Add(new Criterion("Password", password, CriteriaOperator.Equal));
            var account = _repository.FindBy(query);
            if (account != null && account.Count() > 0)
            {
                response.IsAuthenticated = true;
                response.SelectedUser = account.FirstOrDefault<IUser>();
            }
            return response;
        }

        public GetUserByEmailResponse GetUserByEmail(string email)
        {
            GetUserByEmailResponse response = new GetUserByEmailResponse();

            Query query = new Query();
            query.Add(new Criterion("Email", email, CriteriaOperator.Equal));
            var user = _repository.FindBy(query);
            if (user != null)
                response.SelectedUser = user.FirstOrDefault<IUser>();
            return response;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();
            _repository.Save((User)request.view.UserRef);
            _uow.Commit();
            response.User.UserRef = request.view.UserRef;
            
            return response;
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest request)
        {
            var response = new UpdateUserResponse();
            request.User.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            request.User.LastUpdated = DateTime.Now;
            _repository.Save((User)request.User);
            _uow.Commit();
            response.View.UserRef = request.User;
            response.Success = true;
            response.Message = "User Saved Successfully";
            return response;

        }

        public GetUserResponse GetUser(GetUserRequest request)
        {
            GetUserResponse response = new GetUserResponse();

            IUser staff = _repository.FindBy(request.UserID);

            if (staff != null)
            {
                response.UserFound = true;
                response.User = staff.ConvertToUserView();
            }
            else
            {
                response.UserFound = false;
            }
            return response;
        }

        private void ThrowExceptionIfStaffIsInvalid(Staff staff)
        {
            if (staff.GetBrokenRules().Count() > 0)
            {
                StringBuilder brokenRules = new StringBuilder();
                brokenRules.AppendLine("there were problems saving the User: ");
                foreach (var businessRule in staff.GetBrokenRules())
                {
                    brokenRules.AppendLine(businessRule.Rule);
                }
                throw new UserInvalidException(brokenRules.ToString());
            }
        }

        #endregion
    }
}

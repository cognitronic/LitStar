using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Core.Security;
using LitStar.Infrastructure.Authentication;
using LitStar.Infrastructure.Domain;
using StructureMap;
using LitStar.Services.ViewModels;
using LitStar.Services.Cache.CacheStorage;
using LitStar.Infrastructure.UnitOfWork;
using LitStar.Services.Interfaces;

namespace LitStar.Services.Implementations
{
    public class CustomAuthenticationService : ILocalAuthenticationService
    {
        //private readonly IUserRepository _repository = ObjectFactory.GetInstance<IUserRepository>();

        //private readonly ICacheStorage _cache = ObjectFactory.GetInstance<ICacheStorage>();

        private readonly IUserRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _service;
        private readonly IStaffService _staffService;

        public CustomAuthenticationService(IUserRepository repository, ICacheStorage cache, IUnitOfWork uow, IUserService service, IStaffService staffService)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
            _service = service;
            _staffService = staffService;
        }

        #region ILocalAuthenticationService Members

        public IUserAccount Login(string email, string password)
        {
            var response = _service.AuthenticateUser(email, password);

            UserView userAccount = new UserView();
            userAccount.IsAuthenticated = false;

            //var user = _repository.FindBy(email);
            if (response != null && response.SelectedUser != null && password == response.SelectedUser.Password)
            {
                userAccount.IsAuthenticated = true;
                SecurityContextManager.Current.CurrentAccount = response.SelectedUser.Account;
                SecurityContextManager.Current.CurrentUser = response.SelectedUser;
                SecurityContextManager.Current.IsAuthenticated = true;
                userAccount.Email = response.SelectedUser.Username;
                userAccount.AuthenticationToken = response.SelectedUser.ID.ToString();
                //userAccount.FirstName = response.SelectedUser.FirstName;
                //userAccount.LastName = response.SelectedUser.LastName;
                switch (response.SelectedUser.UserType)
                { 
                    case UserType.Staff:
                        var staffrequest = new LitStar.Services.Messaging.StaffService.GetStaffByEmailRequest();
                        staffrequest.Email = response.SelectedUser.Username;
                        var staff = _staffService.GetStaffByEmail(staffrequest).Staff;
                        
                SecurityContextManager.Current.CurrentUser.FirstName = staff.FirstName;
                SecurityContextManager.Current.CurrentUser.LastName = staff.LastName;
                SecurityContextManager.Current.CurrentUser.AvatarPath = staff.AvatarPath;
                SecurityContextManager.Current.CurrentUser.Email = staff.Email;
                        userAccount.Email = staff.Email;
                        userAccount.FirstName = staff.FirstName;
                        userAccount.LastName = staff.LastName;
                        userAccount.AvatarPath = staff.AvatarPath;
                        break;
                }
                userAccount.Type = response.SelectedUser.Type;
            }
            return userAccount;
        }

        public IUserAccount RegisterUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        #endregion

        
    }
}

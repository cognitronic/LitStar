using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Core.Security;
using LitStar.Infrastructure.Querying;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.StaffService;
using LitStar.Services.Mapping;
using LitStar.Services.Cache.CacheStorage;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Services.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public StaffService(IStaffRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        public GetStaffListResponse GetStaffList()
        {
            GetStaffListResponse response = new GetStaffListResponse();
            var list = _repository.FindAll();
            if (list != null && list.Count() > 0)
                response.Staff = list.ToList<IStaff>();
            return response;
        }

        public GetStaffListResponse GetManagers()
        {
            GetStaffListResponse response = new GetStaffListResponse();
            response.Staff = new List<IStaff>();
            //if (_cache.Get<IList<Staff>>(LitStar.Core.ResourceStrings.Session_ManagersList + "_" +
            //        SecurityContextManager.Current.CurrentAccount.ID.ToString()) == null)
            //{
                var query = new Query();
                query.Add(new Criterion("IsManager", true, CriteriaOperator.Equal));
                var list = _repository.FindBy(query);
                //_cache.Store(LitStar.Core.ResourceStrings.Session_ManagersList + "_" +
                //    SecurityContextManager.Current.CurrentAccount.ID.ToString(),
                //    list);
                foreach (var item in list)
                {
                    if (item.AccountID == SecurityContextManager.Current.CurrentAccount.ID)
                    {
                        response.Staff.Add(item);
                    }
                }
            //}
            //else
            //{
            //    foreach (var item in _cache.Get<IList<Staff>>(LitStar.Core.ResourceStrings.Session_ManagersList + "_" +
            //        SecurityContextManager.Current.CurrentAccount.ID.ToString()))
            //    {
            //        if (item.AccountID == SecurityContextManager.Current.CurrentAccount.ID)
            //        {
            //            response.Staff.Add(item);
            //        }
            //    }
            //}
            return response;
        }

        public GetStaffResponse GetStaffByEmail(GetStaffByEmailRequest request)
        {
            var query = new Query();
            query.Add(new Criterion("Email", request.Email, CriteriaOperator.Equal));
            GetStaffResponse response = new GetStaffResponse();
            var staff = _repository.FindBy(query);
            if (staff != null)
                response.Staff = staff.FirstOrDefault<IStaff>();
            return response;
        }

        public GetStaffResponse GetStaffByID(int id)
        {
            var query = new Query();
            query.Add(new Criterion("ID", id, CriteriaOperator.Equal));
            GetStaffResponse response = new GetStaffResponse();
            var staff = _repository.FindBy(query);
            if (staff != null)
                response.Staff = staff.FirstOrDefault<IStaff>();
            return response;
        }

        public UpdateStaffResponse UpdateStaff(UpdateStaffRequest request)
        {
            var response = new UpdateStaffResponse();
            request.Staff.LastLoggedIn = DateTime.Now;
            _repository.Save((Staff)request.Staff);
            _uow.Commit();
            response.View.Staff = request.Staff;
            response.Success = true;
            response.Message = "Staff Saved Successfully";
            return response;
        }
        
        public CreateStaffResponse CreateStaff(CreateStaffRequest request)
        {
            var response = new CreateStaffResponse();
            _repository.Save((Staff)request.Staff);
            _uow.Commit();
            response.View.Staff = request.Staff;
            return response;
        }
    }
}

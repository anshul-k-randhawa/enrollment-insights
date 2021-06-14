using CourseEnrollment.Core.Models;
using CourseEnrollment.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Api.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repo;
        private readonly ILogger _logger;        

        public StaffService(IStaffRepository repo, ILogger<StaffService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> LoginAsync(string email, string pswd)
        {
            try
            {
                var result = await _repo.QueryRegistrationAsync(email);
                if(result != null && result.ToList().Count == 1 )
                {
                    return result.First().StaffPswd.Equals(pswd);
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error happened while login in staff. Details: {0}", ex.Message);
                throw;
            }
        }

        public async Task<StaffRegistration> RegisterAsync(StaffRegistration item)
        {
            try
            {  
                 return await _repo.AddAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error happened while registering staff. Details: {0}", ex.Message);
                throw;
            }
        }
    }
}

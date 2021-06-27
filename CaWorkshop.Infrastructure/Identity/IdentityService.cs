using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CaWorkshop.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManagerService;
        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManagerService = userManager;
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser()
            {
                UserName = userName,
                Email = userName
            };

            var result = await _userManagerService.CreateAsync(user, password);
            return (result.ToApplicationResult(), user.Id);
        }
        private async Task<Result> DeleteUserAsync(ApplicationUser applicationUser)
        {
            var result = await _userManagerService.DeleteAsync(applicationUser);
            return result.ToApplicationResult();
        }
        public async Task<Result> DeleteUserAsync(string userId)
        {
            var findUser = await _userManagerService.Users.SingleOrDefaultAsync(e => e.Id == userId);
            if (findUser != null)
            {
                return await DeleteUserAsync(findUser);
            }
            return Result.Success();
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManagerService.Users.FirstAsync(u => u.Id == userId);
            return user.UserName;
        }
    }
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult identityResult)
        {
            return identityResult.Succeeded
                            ? Result.Success()
                            : Result.Failure(identityResult.Errors.Select(e => e.Description));

        }
    }
}

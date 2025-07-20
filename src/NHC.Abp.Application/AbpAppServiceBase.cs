using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;
using Volo.Abp.Users;

public abstract class AbpAppServiceBase : ApplicationService
{
    private Lazy<ICurrentUser> _currentUser;
    private Lazy<IdentityUserManager> _userManager;

    protected ICurrentUser CurrentUser => _currentUser.Value;
    protected IdentityUserManager UserManager => _userManager.Value;

    protected AbpAppServiceBase()
    {
        _currentUser = new Lazy<ICurrentUser>(() => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>());
        _userManager = new Lazy<IdentityUserManager>(() => LazyServiceProvider.LazyGetRequiredService<IdentityUserManager>());
    }

    protected virtual async Task<IdentityUser> GetCurrentUserAsync()
    {
        if (!CurrentUser.IsAuthenticated)
        {
            throw new AbpAuthorizationException("User is not authenticated.");
        }

        var user = await UserManager.FindByIdAsync(CurrentUser.GetId().ToString());
        if (user == null)
        {
            throw new AbpException("Current user not found.");
        }

        return user;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Common.Constants;
using MyMovieDb.Common.ViewModels.Admin;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Admin.Interfaces;

namespace MyMovieDb.Services.Admin
{
    public class AdminUsersService : BaseService, IAdminUsersService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public AdminUsersService(
            MyMovieDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            IMapper mapper)
            : base(dbContext, mapper)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<ICollection<ManageUserViewModel>> GetAllUsersAsync()
        {
            var users = DbContext.Users.ToList();
            var model = new List<ManageUserViewModel>();

            foreach (var user in users)
            {
                var userViewModel = Mapper.Map<ManageUserViewModel>(user);
                var roles = await this.userManager.GetRolesAsync(user);

                if (roles.Any(r => r.ToLower() == "admin"))
                {
                    userViewModel.IsAdmin = true;
                }
                else if (roles.Any(r => r.ToLower() == "moderator"))
                {
                    userViewModel.IsModerator = true;
                }

                model.Add(userViewModel);
            }

            return model;
        }

        public async Task<bool> GiveModeratorRightsToUserAsync(string usedId)
        {
            try
            {
                var user = this.DbContext.Users.Find(usedId);
                if (user == null)
                {
                    return false;
                }

                if (await this.userManager.IsInRoleAsync(user, AppRoles.Moderator))
                {
                    return false;
                }

                var result = await this.userManager.AddToRoleAsync(user, AppRoles.Moderator);
                if (!result.Succeeded)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveModeratorRightsFromUserAsync(string usedId)
        {
            try
            {
                var user = this.DbContext.Users.Find(usedId);
                if (user == null)
                {
                    return false;
                }

                if (!await this.userManager.IsInRoleAsync(user, AppRoles.Moderator))
                {
                    return false;
                }

                var result = await this.userManager.RemoveFromRoleAsync(user, AppRoles.Moderator);
                if (!result.Succeeded)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

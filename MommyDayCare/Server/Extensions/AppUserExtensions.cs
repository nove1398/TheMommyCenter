using Microsoft.EntityFrameworkCore;
using MommyDayCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Server.Extensions
{
    public static class AppUserExtensions
    {
        public static async Task<int> CountAllActive(this DbSet<AppUser> users)
        {
            return await users.Where(x=>x.AppUserId > 0).CountAsync();
        }
    }
}

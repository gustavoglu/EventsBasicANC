using EventsBasicANC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventsBasicANC.Util
{
    public class EasyClaims
    {
        private static IHttpContextAccessor _accessor;
        private static UserManager<Usuario> _userManaber;
        public EasyClaims(UserManager<Usuario> userManager, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _userManaber = userManager;
        }

        public async Task<bool> isAdmin(string id_usuario = null)
        {

            if (_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = (ClaimsIdentity)_accessor.HttpContext.User.Identity;
                var query = claims.Claims.Where(c => c.Type == "Admin "&& c.Value == "Admin");
                return query.Any();
            }

            if (id_usuario != null)
            {
                var usuario = await _userManaber.FindByIdAsync(id_usuario);
                if (usuario == null) return false;
                var claimsUser = await _userManaber.GetClaimsAsync(usuario);
                var queryClaimUser = claimsUser.Where(c => c.Type == "Admin" && c.Value == "Admin");
                return queryClaimUser.Any();
            }

            return false;
        }


        public async Task<bool> isPrivate(string ClaimName, string id_usuario = null)
        {

            if (_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = (ClaimsIdentity)_accessor.HttpContext.User.Identity;
                var query = claims.Claims.Where(c => c.Type == ClaimName && c.Value == "Pv");
                return query.Any();
            }

            if (id_usuario != null)
            {
                var usuario = await _userManaber.FindByIdAsync(id_usuario);
                if (usuario == null) return false;
                var claimsUser = await _userManaber.GetClaimsAsync(usuario);
                var queryClaimUser = claimsUser.Where(c => c.Type == ClaimName && c.Value == "Pv");
                return queryClaimUser.Any();
            }

            return false;
        }

        public async Task<bool> isPrincipal(string ClaimName, string id_usuario = null)
        {
            if (_accessor.HttpContext.User.Identity.IsAuthenticated && id_usuario == null)
            {
                var claims = (ClaimsIdentity)_accessor.HttpContext.User.Identity;
                var query = claims.Claims.Where(c => c.Type == ClaimName && c.Value == "Pr");
                return query.Any();
            }

            if (id_usuario != null)
            {
                var usuario = await _userManaber.FindByIdAsync(id_usuario);
                if (usuario == null) return false;
                var claimsUser = await _userManaber.GetClaimsAsync(usuario);
                var queryClaimUser = claimsUser.Where(c => c.Type == ClaimName && c.Value == "Pr");
                return queryClaimUser.Any();
            }
            return false;
        }
    }
}

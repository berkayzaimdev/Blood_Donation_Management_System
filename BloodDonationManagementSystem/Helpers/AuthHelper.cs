using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BloodDonationManagementSystem.Models.Login;


namespace BloodDonationManagementSystem.Helpers
{
    public class AuthHelper
    {
        public static ClaimsPrincipal GetClaims(Uye uye)
        {
            List<Claim> claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, uye.Id.ToString()),
                    new(ClaimTypes.Name, uye.Isim+" "+uye.Soyisim),
                    new(ClaimTypes.Role, uye.KullaniciTipi.Isim)
                };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }

        public static AuthenticationProperties GetAuthProperties(bool beniHatirla)
        {
            return new AuthenticationProperties
            {
                IsPersistent = beniHatirla
            };
        }
    }
}

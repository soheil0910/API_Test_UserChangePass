using API_Test_UserChangePass.Models;
using System;
using System.Security.Claims;

namespace API_Test_UserChangePass
{
    public class کلایم_برای_خودم
    {
    }
}






//System.Security.Claims.ClaimsPrincipal user
//ClaimsPrincipal claims

//var RequestingUser = claims.FindFirst("UserName")?.Value;
//var RequestingUserIsAdmin = claims.FindFirst("IsAdmin")?.Value;









/*

1.دسترسی به Claims از طریق User در کنترلر
در کنترلرهای ASP.NET Core، HttpContext.User حاوی اطلاعات کاربر جاری است. برای استخراج مقادیر Claims می‌توانید به صورت زیر عمل کنید:
                    
                    csharp
                    Copy code
                    // دریافت مقدار خاصی از Claim با نام مشخص (مثلاً "email")
                    var email = User.FindFirst(ClaimTypes.Email)?.Value;
                    
                    // دریافت مقدار Claim دیگر با نام سفارشی
                    var customClaimValue = User.FindFirst("YourCustomClaimName")?.Value;
                    
                    // دریافت همه Claims
                    var claims = User.Claims.ToList();
                    foreach (var claim in claims)
                    {
                        Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
                    }
                    
*/








/*



2.دریافت Claims در کلاس‌های سرویس یا خارج از کنترلر
اگر بخواهید در کلاسی خارج از کنترلر به Claims دسترسی پیدا کنید:

الف) دسترسی از طریق IHttpContextAccessor
ابتدا باید IHttpContextAccessor را به سرویس‌های خود اضافه کنید:

در Program.cs یا Startup.cs، سرویس را اضافه کنید:
csharp
Copy code
services.AddHttpContextAccessor();
استفاده در کلاس موردنظر:
csharp
Copy code
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class YourService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public YourService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void GetClaims()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        // دریافت Claim خاص
        var email = user?.FindFirst(ClaimTypes.Email)?.Value;

        // دریافت همه Claims
        var claims = user?.Claims.ToList();
        if (claims != null)
        {
            foreach (var claim in claims)
            {
                Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
            }
        }
    }
}

*/
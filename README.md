![1733409146401](https://github.com/user-attachments/assets/6cb2e860-352c-43ef-8f5e-0ed903000a99)







DataBase : postgresql

Project : Asp.net core 8




برای ساخت دیتا بیس دستور های زیر فراموش نشود


Add-Migration soheil0910

Update-Database







برای ایجاد یک اکشن API در ASP.NET Core 8 که فقط فایل‌های PDF و JPG را دریافت کند، می‌توانید از ویژگی‌های مربوط به Model Binding و Validation استفاده کنید. مراحل زیر را دنبال کنید:


---

1. ساخت اکشن API

ابتدا یک اکشن API در کنترلر خود ایجاد کنید که درخواست فایل را دریافت کند. از نوع IFormFile برای آپلود فایل استفاده کنید.

[HttpPost("upload-file")]
public IActionResult UploadFile(IFormFile file)
{
    // بررسی وجود فایل
    if (file == null || file.Length == 0)
        return BadRequest("فایل ارسال نشده است.");

    // بررسی نوع فایل
    var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg" };
    var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

    if (!allowedExtensions.Contains(extension))
        return BadRequest("فقط فایل‌های PDF و JPG مجاز هستند.");

    // ذخیره فایل (مثال)
    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
    if (!Directory.Exists(uploadPath))
        Directory.CreateDirectory(uploadPath);

    var filePath = Path.Combine(uploadPath, file.FileName);
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        file.CopyTo(stream);
    }

    return Ok(new { message = "فایل با موفقیت آپلود شد.", fileName = file.FileName });
}


---

2. تنظیمات Middleware (حجم فایل)

برای محدود کردن حجم فایل آپلودی، در فایل Program.cs مقادیر محدودیت را تنظیم کنید.

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10MB
});


---

3. محدود کردن نوع محتوا (به صورت Middleware اختیاری)

اگر می‌خواهید نوع محتوا را نیز از طریق Content-Type بررسی کنید:

var allowedMimeTypes = new[] { "application/pdf", "image/jpeg" };
if (!allowedMimeTypes.Contains(file.ContentType.ToLowerInvariant()))
    return BadRequest("نوع محتوا نامعتبر است.");


---

4. تنظیم Routing

در فایل Program.cs مطمئن شوید که Endpoint مربوطه فعال است:

app.MapControllers();


---

5. تست API

از ابزارهایی مانند Postman یا Swagger برای تست API استفاده کنید. اطمینان حاصل کنید که فایل‌های غیرمجاز (مانند .exe یا .png) به درستی رد شوند.


---

پوشه ذخیره‌سازی

به دلایل امنیتی:

مسیر ذخیره‌سازی فایل‌ها را خارج از پوشه اصلی پروژه تنظیم کنید.

نام فایل‌ها را با Guid یا هش رمزنگاری کنید تا از مشکلات مربوط به امنیت جلوگیری شود.


اگر سوال یا مشکل دیگری دارید، اطلاع دهید!


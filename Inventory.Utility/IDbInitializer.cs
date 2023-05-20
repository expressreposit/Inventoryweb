using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventory.Utility
{
    public interface IDbInitializer
    {
      
        Task CreateSuperAdmin();
        Task SendEmail(string FromEmail,string subject,
            string FromName,
            string Message, string toEmail, string toName, string smtpUser,
            string smtpPassword, string smtpHost, string smtpPort, bool smtpSSL);
        Task<string> UploadFile(List<IFormFile> files,
           IWebHostEnvironment env, string Directory);

    }
}

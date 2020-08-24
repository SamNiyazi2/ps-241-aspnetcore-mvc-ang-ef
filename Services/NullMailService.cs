using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps_DutchTreat.Services
{
    // 08/24/2020 07:51 am - SSN - [20200824-0751] - [001] - M05-12 - Adding a service

    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            this.logger = logger;
        }
        public void SendMessage(string to, string subject, string body)
        {
            this.logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }

    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps_DutchTreat.Controllers
{
    public class APIErrorHandler
    {
        public class APIErrorMessage
        {
            public string ErrorNo { get; set; }
            public string ErrorMessage { get; set; }
        }

        public static APIErrorMessage HandlerError<T>(string errorNo, string errorMessageToUser, string errorMessageToSystemAdmin, Exception ex, ILogger<T> logger)
        {
            var errorObj = new APIErrorMessage { ErrorNo = errorNo, ErrorMessage = errorMessageToUser };
            logger.LogError(errorNo, errorMessageToSystemAdmin, ex);
            return errorObj;
        }

    }
}

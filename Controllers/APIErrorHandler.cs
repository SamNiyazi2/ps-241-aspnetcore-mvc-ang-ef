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
        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="errorNo">Error number YYYYMMDD-HHNN</param>
        /// <param name="errorMessageToUser">Error message to pass to user</param>
        /// <param name="errorMessageToSystemAdmin">Error message to pass to system admin</param>
        /// <param name="ex">Exception object, if applicable</param>
        /// <param name="logger">Current logger instnace</param>
        /// <returns></returns>
        public static APIErrorMessage LogError<T>(string errorNo, string errorMessageToUser, string errorMessageToSystemAdmin, Exception ex, ILogger<T> logger)
        {
            var errorObj = new APIErrorMessage { ErrorNo = errorNo, ErrorMessage = errorMessageToUser };
            logger.LogError(errorNo, errorMessageToSystemAdmin);
            logger.LogError(errorMessageToSystemAdmin);
            logger.LogError("-".PadLeft(80, '*'));
            logger.LogError(Newtonsoft.Json.JsonConvert.SerializeObject(ex, Newtonsoft.Json.Formatting.Indented));
            logger.LogError("-".PadLeft(80, '='));
            return errorObj;
        }

        /// <summary>
        /// Logs information message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="errorNo">Reference number: YYYYMMDD-HHNN</param>
        /// <param name="errorMessageToUser">Message to pass to user</param>
        /// <param name="errorMessageToSystemAdmin">Message to pass to system admin</param>
        /// <param name="logger">Current logger instance</param>
        /// <returns></returns>
        internal static object LogInformation<T>(string errorNo, string errorMessageToUser, string errorMessageToSystemAdmin, ILogger<T> logger)
        {
            var errorObj = new APIErrorMessage { ErrorNo = errorNo, ErrorMessage = errorMessageToUser };
            logger.LogInformation(errorNo, errorMessageToSystemAdmin);
            logger.LogInformation(errorMessageToSystemAdmin);
            return errorObj;
        }
    }
}

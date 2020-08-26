using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            logger.LogError("--AAA--".PadLeft(80, '*'));
            logger.LogError(DateTime.Now.ToString("=== yyyy-MM-dd hh:mm:ss t"));
            logger.LogError(errorNo, errorMessageToSystemAdmin);
            logger.LogError(errorMessageToSystemAdmin);
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
        /// <param name="modelState">ModelState</param>

        /// <returns></returns>
        internal static object LogInformation<T>(string errorNo, string errorMessageToUser, string errorMessageToSystemAdmin, ILogger<T> logger, ModelStateDictionary modelState = null)
        {

            var errorObj = new APIErrorMessage { ErrorNo = errorNo, ErrorMessage = errorMessageToUser };
            logger.LogInformation("--BBB--".PadLeft(80, '*'));
            logger.LogInformation(DateTime.Now.ToString("=== yyyy-MM-dd hh:mm:ss t"));
            logger.LogInformation(errorNo, errorMessageToSystemAdmin);
            logger.LogInformation(errorMessageToSystemAdmin);
            logger.LogInformation("-".PadLeft(80, '='));


            if (modelState != null)
            {
                Dictionary<string, List<string>> errorMessages = modelState.ModelStateToDic();
                logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(errorMessages, Newtonsoft.Json.Formatting.Indented));
                errorObj.ErrorList = errorMessages;
            }

            return errorObj;
        }


    }


    public class APIErrorMessage
    {
        public string ErrorNo { get; set; }
        public string ErrorMessage { get; set; }
        public Dictionary<string, List<string>> ErrorList { get; set; }

    }


    public static class ModelStateDictionary_Extension
    {
        public static Dictionary<string, List<string>> ModelStateToDic(this ModelStateDictionary modelState)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            foreach (KeyValuePair<string, ModelStateEntry> error in modelState)
            {
                foreach (ModelError me in error.Value.Errors)
                {
                    dic.TryGetValue(error.Key, out List<string> currentyEntry);

                    if (currentyEntry == null)
                    {
                        dic.Add(error.Key, new List<string>() { me.ErrorMessage });
                    }
                    else
                    {
                        currentyEntry.Add(me.ErrorMessage);
                    }
                }
            }

            return dic;
        }
    }
}

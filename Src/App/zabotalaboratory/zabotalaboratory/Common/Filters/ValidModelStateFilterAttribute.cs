﻿using System.Linq;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace zabotalaboratory.Web.Common.Filters
{
    public class ValidModelStateAttribute : ActionFilterAttribute
    {
        public ZabotaErrorCodes ErrorCode = ZabotaErrorCodes.InvalidForm;
        public string ErrorMessage { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            if (!string.IsNullOrWhiteSpace(ErrorMessage))
                context.Result = new JsonResult(new ZabotaResult { Error = new ZabotaError { Code = ErrorCode, Message = ErrorMessage } });

            var errorMessage = string.Join(", ", context.ModelState.Select(u => u.Value).SelectMany(u => u.Errors).Select(u => u.ErrorMessage));
            context.Result = new JsonResult(new ZabotaResult { Error = new ZabotaError { Code = ErrorCode, Message = errorMessage } });
        }
    }
}
﻿using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Common.Errors
{
    public static class ApplicationErrors
    {
        public static readonly Error InvalidAuthentication = Error.Unauthorized(
            code: "Application.InvalidAuthentication",
            description: "Invalid login or password");

        public static readonly Error UserExist = Error.Conflict(
            code: "Application.UserExist",
            description: "User with entered email has already exist");

        public static readonly Error UserNotFound = Error.NotFound(
            code: "Application.UserNotFound",
            description: "User with entered email doesn't exist");
    }
}

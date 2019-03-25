using Microsoft.AspNetCore.Http;
using System;

namespace HotBag.Identity.AppSession
{
    /// <summary>
    /// Defines some session information that can be useful for applications.
    /// </summary>
    public interface IAppSession
    {
        /// <summary>
        /// Gets current UserId or null.
        /// It can be null if no user logged in.
        /// </summary>
        string  UserId { get; }

        /// <summary>
        /// UserId of the impersonator.
        /// This is filled if a user is performing actions behalf of the <see cref="UserId"/>.
        /// </summary>
        string  ImpersonatorUserId { get; } 

        HttpContext HttpContext { get; }
    }
}

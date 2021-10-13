using Common.Application.Common.Exceptions;
using Common.Application.Common.Interfaces;
using Common.Application.Common.Security;
using Common.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace Common.Application.Common.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IAuthService _authService;

        public AuthorizationBehaviour(
            ICurrentUserService currentUserService,
            IAuthService authService)
        {
            _currentUserService = currentUserService;
            _authService = authService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                if (_currentUserService.UserId == null)
                {
                    throw new UnauthorizedAccessException();
                }

                var user = await _authService.GetUserAsync(Guid.Parse(_currentUserService.UserId));
                if (user == null)
                    throw new UnauthorizedAccessException();

                var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                if (authorizeAttributesWithRoles.Any())
                {
                    var authorized = false;

                    foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                    {
                        foreach (var role in roles)
                        {
                            var isInRole = user.IsInRole(role);
                            if (isInRole)
                            {
                                authorized = true;
                                break;
                            }
                        }
                    }

                    // Must be a member of at least one role in roles
                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }
            }

            // User is authorized / authorization not required
            return await next();
        }
    }
}

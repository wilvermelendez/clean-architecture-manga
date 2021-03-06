﻿namespace Domain.Security
{
    using System.Threading.Tasks;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// Security <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#domain-service">Domain Service Domain-Driven Design Pattern</see>.
    /// </summary>
    public class SecurityService
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityService"/> class.
        /// </summary>
        /// <param name="userFactory">User Factory.</param>
        /// <param name="userRepository">User Repository.</param>
        public SecurityService(
            IUserFactory userFactory,
            IUserRepository userRepository)
        {
            this._userFactory = userFactory;
            this._userRepository = userRepository;
        }

        /// <summary>
        /// Create User Credentials.
        /// </summary>
        /// <param name="customerId">CustomerId.</param>
        /// <param name="externalUserId">External User Id.</param>
        /// <returns>The User.</returns>
        public async Task<IUser> CreateUserCredentials(CustomerId customerId, ExternalUserId externalUserId)
        {
            var user = this._userFactory.NewUser(customerId, externalUserId);
            await this._userRepository.Add(user);
            return user;
        }
    }
}

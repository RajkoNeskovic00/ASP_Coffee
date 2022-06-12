using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.Application.Interfaces;
using System;
using System.Linq;

namespace ASP_Coffee.Application
{
    public class UseCase
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCase(IApplicationActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            logger.Log(query, actor, search);

            if (!actor.AllowedUseCases.Contains(query.id))
            {
                throw new UnauthorizedUseCase(query, actor);
            }

            return query.Execute(search);
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            logger.Log(command, actor, request);

            if (!actor.AllowedUseCases.Contains(command.id))
            {
                throw new UnauthorizedUseCase(command, actor);
            }

            command.Execute(request);
        }
    }
}

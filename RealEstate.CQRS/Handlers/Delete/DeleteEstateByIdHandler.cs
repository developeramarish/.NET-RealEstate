﻿using MediatR;
using RealEstate.CQRS.Commands;
using RealEstate.CQRS.Responses;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Delete
{
    public class DeleteEstateByIdHandler : IRequestHandler<DeletePropertyByIdCommand, Response>
    {
        private readonly IApplicationDbRepository repo;

        public DeleteEstateByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<Response> Handle(DeletePropertyByIdCommand request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            var estate = repo.GetByIdAsync<Estate>(id);
            repo.DeleteAsync<Estate>(estate);

            return (Task<Response>)Task.CompletedTask;
        }
    }
}
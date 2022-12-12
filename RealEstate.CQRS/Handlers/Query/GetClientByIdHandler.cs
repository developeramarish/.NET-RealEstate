﻿using MediatR;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Clients;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.CQRS.Handlers.Query
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientViewModel>
    {
        private readonly IApplicationDbRepository repo;
        
        public string Id { get; set; }

        public GetClientByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public GetClientByIdHandler(string id)
        {
            Id = id;
        }

        public  Task<ClientViewModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            string id = request.Id;

            var foundUser = repo.GetByIdAsync<Client>(id).Result;

            var userViewModel = new ClientViewModel
            {
                Client_Id = foundUser.Id,
                Client_Name = foundUser.Client_Name,
                Client_Details = foundUser.Client_Details,
                EMail = foundUser.Email,
                Contact = foundUser.Contact,
                Client_Address = foundUser.Client_Address,
            };

            return Task.FromResult(userViewModel);
        }
    }
}

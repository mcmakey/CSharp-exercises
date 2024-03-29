﻿using ClientServiceProtos;
using ClinicService.Data;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using static ClientServiceProtos.ClientService;

namespace ClinicService.Services.Impl
{
    [Authorize]
    public class ClientService : ClientServiceBase
    {
        private readonly ClinicServiceDbContext _dbContext;
        private readonly ILogger<ClientService> _logger;

        public ClientService(ClinicServiceDbContext dbContext,
            ILogger<ClientService> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public override Task<ClientServiceProtos.CreateClientResponse> CreateClient(ClientServiceProtos.CreateClientRequest request, ServerCallContext context)
        {
            var client = new Client
            {
                Document = request.Document,
                Surname = request.Surname,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic
            };

            _dbContext.Add(client);
            _dbContext.SaveChanges();

            var response = new CreateClientResponse
            {
                ClientId = client.ClientId
            };

            return Task.FromResult(response);
        }

        public override Task<GetClientsResponse> GetClients(GetClientsRequest request, ServerCallContext context)
        {
            var response = new GetClientsResponse();
            response.Clients.AddRange(_dbContext.Clients.Select(client => new ClientResponse
            {
                ClientId = client.ClientId,
                Document = client.Document,
                FirstName = client.FirstName,
                Patronymic = client.Patronymic,
                Surname = client.Surname
            }).ToList());

            return Task.FromResult(response);
        }

    }
}

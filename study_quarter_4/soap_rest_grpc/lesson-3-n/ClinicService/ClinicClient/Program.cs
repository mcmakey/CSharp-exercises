// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Reflection.Metadata;
using static ClientServiceProtos.ClientService;
using static ClinicServiceProtos.ConsultationService;
using static ClinicServiceProtos.PetService;

internal class Program
{
    private static void Main(string[] args)
    {
        //AppContext.SetSwitch(
        //      "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true); //

        using var channel = GrpcChannel.ForAddress("https://localhost:5001");

        //

        ClinicService.Protos.AuthenticateService.AuthenticateServiceClient authenticateServiceClient = new 
            ClinicService.Protos.AuthenticateService.AuthenticateServiceClient(channel);

        var authenticationResponse = authenticateServiceClient.Login(new ClinicService.Protos.AuthenticationRequest
        {
            UserName = "sample@mail.ru",
            Password ="12345"
        });

        if (authenticationResponse.Status != 0)
        {
            Console.WriteLine("Authentication error.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Session token: {authenticationResponse.SessionInfo.SessionToken}");

        var credentials = CallCredentials.FromInterceptor((c, m) =>
        {
            m.Add("Authorization",
                $"Bearer {authenticationResponse.SessionInfo.SessionToken}");
            return Task.CompletedTask;
        });

        var protectedChannel = GrpcChannel.ForAddress("https://localhost:5001",
            new GrpcChannelOptions
            {

                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });

        //

        ClientServiceClient client = new ClientServiceClient(protectedChannel);
        PetServiceClient pet = new PetServiceClient(protectedChannel);
        ConsultationServiceClient consultation = new ConsultationServiceClient(protectedChannel);

        //
        var createClientResponse = client.CreateClient(new ClientServiceProtos.CreateClientRequest
        {
            Document = "PASS123",
            FirstName = "cтаниcлав",
            Surname = "Байраковcкий",
            Patronymic = "Антонович"
        });

        Console.WriteLine($"Client ({createClientResponse.ClientId}) created successfully.");

        var getClientsResponse = client.GetClients(new ClientServiceProtos.GetClientsRequest());

        if (getClientsResponse.ErrCode == 0)
        {
            Console.WriteLine("Clients:");
            Console.WriteLine("========\n");
            foreach (var clientDto in getClientsResponse.Clients)
            {
                Console.WriteLine($"({clientDto.ClientId}/{clientDto.Document}) {clientDto.Surname} {clientDto.FirstName} {clientDto.Patronymic}");
            }
        }

        Console.WriteLine("========\n");
        Console.WriteLine("========\n");

        //

        var createPetResponse = pet.CreatePet(new ClinicServiceProtos.CreatePetRequest
        {
            ClientId = 1,
            Name = "Том",
            Birthday = DateTime.UtcNow.ToTimestamp()
        });

        Console.WriteLine($"Pet ({createPetResponse.PetId}) created successfully.");

        var getPetsResponse = pet.GetPets(new ClinicServiceProtos.GetPetsRequest());
        if (getPetsResponse.ErrCode == 0)
        {
            Console.WriteLine("Pets:");
            Console.WriteLine("========\n");
            foreach (var petDto in getPetsResponse.Pets)
            {
                Console.WriteLine($"({petDto.PetId} {petDto.ClientId} {petDto.Name}) {petDto.Birthday}");
            }
        }

        Console.WriteLine("========\n");
        Console.WriteLine("========\n");

        //

        var createConsultationResponse = consultation.CreateConsultation(new ClinicServiceProtos.CreateConsultationRequest
        {
            ClientId = 1,
            PetId = 1,
            ConsultationDate = DateTime.UtcNow.ToTimestamp(),
            Description = "уши",
        });

        Console.WriteLine($"Consultation ({createConsultationResponse.ConsultationId}) created successfully.");

        var getConsultationsResponse = consultation.GetConsultations(new ClinicServiceProtos.GetConsultationsRequest());

        if (getConsultationsResponse.ErrCode == 0)
        {
            Console.WriteLine("Consultations:");
            Console.WriteLine("========\n");
            foreach (var consultationDto in getConsultationsResponse.Consultations)
            {
                Console.WriteLine($"({consultationDto.ConsultationId} {consultationDto.ClientId} {consultationDto.PetId} {consultationDto.ConsultationDate} {consultationDto.Description})");
            }
        }

        Console.ReadKey();
    }
}
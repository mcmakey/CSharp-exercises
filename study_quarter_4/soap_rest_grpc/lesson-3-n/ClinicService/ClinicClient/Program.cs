// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System.Reflection.Metadata;
using static ClientServiceProtos.ClientService;
using static ClinicServiceProtos.ConsultationService;
using static ClinicServiceProtos.PetService;

internal class Program
{
    private static void Main(string[] args)
    {
        AppContext.SetSwitch(
              "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        using var channel = GrpcChannel.ForAddress("http://localhost:5001");

        ClientServiceClient client = new ClientServiceClient(channel);
        PetServiceClient pet = new PetServiceClient(channel);
        ConsultationServiceClient consultation = new ConsultationServiceClient(channel);

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
﻿namespace ClinicService.Models.Requests
{
    public class CreateClientRequests
    {
        public string Document { get; set; }

        public string? Surname { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }
    }
}

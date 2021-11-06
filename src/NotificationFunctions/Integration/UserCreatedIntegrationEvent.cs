﻿namespace NotificationFunctions.Integration
{
    class UserCreatedIntegrationEvent
    {
        public UserCreatedIntegrationEvent()
        {
        }

        public UserCreatedIntegrationEvent(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}

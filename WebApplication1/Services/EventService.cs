using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.DTOS;

namespace WebApplication1.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<int, Event> _repository;

        public EventService(IRepository<int, Event> repository)
        {
            _repository = repository;
        }

        public bool Add(EventDTO eventDTO)
        {
            if (eventDTO == null)
                throw new ArgumentNullException(nameof(eventDTO));

            // Map EventDTO to Event
            var eventEntity = new Event
            {
                // Map properties accordingly
                Title = eventDTO.Title,
                Description = eventDTO.Description,
                Date = eventDTO.Date,
                Location = eventDTO.Location,
                MaxAttendees = eventDTO.MaxAttendees,
                RegistrationFee = eventDTO.RegistrationFee,
                Username = eventDTO.Username,
                // Map other properties
            };

            var addedEvent = _repository.Add(eventEntity);

            return addedEvent != null;
        }

        public EventDTO GetEventById(int id)
        {
            var eventEntity = _repository.GetById(id);

            // Map Event to EventDTO
            var eventDTO = new EventDTO
            {
                // Map properties accordingly
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                Date = eventEntity.Date,
                Location = eventEntity.Location,
                MaxAttendees = eventEntity.MaxAttendees,
                RegistrationFee = eventEntity.RegistrationFee,
                Username = eventEntity.Username,
                // Map other properties
            };

            return eventDTO;
        }

        public IEnumerable<EventDTO> GetEvents()
        {
            var events = _repository.GetAll();

            // Map list of Event to list of EventDTO
            var eventDTOs = events?.Select(eventEntity => new EventDTO
            {
                // Map properties accordingly
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                Date = eventEntity.Date,
                Location = eventEntity.Location,
                MaxAttendees = eventEntity.MaxAttendees,
                RegistrationFee = eventEntity.RegistrationFee,
                // Map other properties
            });

            return eventDTOs ?? Enumerable.Empty<EventDTO>();
        }

        public bool Remove(int id)
        {
            var deletedEvent = _repository.Delete(id);

            return deletedEvent != null;
        }

        public EventDTO Update(EventDTO eventDTO)
        {
            if (eventDTO == null)
                throw new ArgumentNullException(nameof(eventDTO));

            // Map EventDTO to Event
            var eventEntity = new Event
            {
                // Map properties accordingly
                Id = eventDTO.Id,
                Title = eventDTO.Title,
                Description = eventDTO.Description,
                Date = eventDTO.Date,
                Location = eventDTO.Location,
                MaxAttendees = eventDTO.MaxAttendees,
                RegistrationFee = eventDTO.RegistrationFee,
                Username = eventDTO.Username
                // Map other properties
            };

            var updatedEvent = _repository.Update(eventEntity);

            // Map updated Event to EventDTO
            var updatedEventDTO = new EventDTO
            {
                // Map properties accordingly
                Id = updatedEvent.Id,
                Title = updatedEvent.Title,
                Description = updatedEvent.Description,
                Date = updatedEvent.Date,
                Location = updatedEvent.Location,
                MaxAttendees = updatedEvent.MaxAttendees,
                RegistrationFee = updatedEvent.RegistrationFee,
                Username = updatedEvent.Username
                // Map other properties
            };

            return updatedEventDTO;
        }
    }
}

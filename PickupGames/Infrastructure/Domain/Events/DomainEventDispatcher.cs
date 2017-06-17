using System;
using System.Collections.Generic;
using System.Linq;
using PickupGames.Infrastructure.Exceptions;
using PickupGames.Infrastructure.Logging;

namespace PickupGames.Infrastructure.Domain.Events
{
    public static class DomainEventDispatcher
    {
        private static IDomainEventHandlerFactory _domainEventHandlerFactory;

        public static void InitializeDomainEventFactory(IDomainEventHandlerFactory domainEventHandlerFactory)
        {
            _domainEventHandlerFactory = domainEventHandlerFactory;
        }

        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            if (_domainEventHandlerFactory == null)
            {
                throw new DomainEventingNotInitializedException("Domain eventing not initialized.");
            }

            var correlationId = LoggingHelper.GetCorrelationId();

            var eventHandlers = _domainEventHandlerFactory.GetDomainEventHandlersFor(domainEvent);

            LoggingFactory.GetLogger().Log(string.Format("Correlation Id: {0}, Domain event {1} started.", correlationId, domainEvent), LogType.Info);

            var errors = new List<Error>();

            foreach (var eventHandler in eventHandlers)
            {
                try
                {
                    LoggingFactory.GetLogger().Log(string.Format("Correlation Id: {0}, Domain event handler {1} started.", correlationId, eventHandler), LogType.Info);

                    eventHandler.Handle(domainEvent);

                    LoggingFactory.GetLogger().Log(string.Format("Correlation Id: {0}, Domain event handler {1} completed.", correlationId, eventHandler), LogType.Info);
                }
                catch (ApplicationLayerException ex)
                {
                    errors.AddRange(ex.Errors);
                }
                catch (Exception ex)
                {
                    var errorLog = LoggingHelper.GenerateExceptionErrorLog(ex);
                    LoggingFactory.GetLogger().Log(string.Format(errorLog.ConvertToExceptionLogMessage()), LogType.Info);
                    errors.Add(new Error { Id = eventHandler.ToString(), Message = ex.Message });
                }
            }

            LoggingFactory.GetLogger().Log(string.Format("Correlation Id: {0}, Domain event {1} completed.", correlationId, domainEvent), LogType.Info);

            if (errors.Any())
            {
                //throw new ApplicationLayerException(HttpStatusCode.InternalServerError, ExceptionType.DomainEvent, "Domain Event Errors.", errors);
            }
        }
    }
}
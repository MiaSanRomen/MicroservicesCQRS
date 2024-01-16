using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CQRS.Core.Events;

public readonly record struct EventModel(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] 
    string Id,
    DateTime TimeStamp,
    Guid AggregateIdentifier,
    string AggregateType,
    long Version,
    string EventType,
    BaseEvent EventData);
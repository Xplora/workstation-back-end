using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;

namespace TripMatch.Xplore.Platform.Inquiry.Domain.Services;

public interface IResponseCommandService
{ 
    Task<Response> Handle(CreateResponseCommand command);  
}
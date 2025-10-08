using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.DAP.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category category)
    {
        return new CategoryResource(category.Id, category.Name);
    }
}
using Docsy.Endpoints.Slices.Collections.Groups.Models;

namespace Docsy.Endpoints.Slices.Collections.Models;

public sealed class Collection
{
    public CollectionId CollectionId { get; set; }
    public required string CollectionName { get; set; }
    public required string Description { get; set; }
    public required string Version { get; set; }
    public IEnumerable<Group> Groups { get; set; } = Enumerable.Empty<Group>();
}

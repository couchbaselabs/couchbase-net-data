namespace Couchbase.Data
{
    /// <summary>
    /// Represents an interface for a domain object
    /// </summary>
    public interface IDomainObject
    {
        string Id { get; set; }

        string Type { get; set; }

        uint Cas { get; set; }
    }
}
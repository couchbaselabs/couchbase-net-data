
namespace Couchbase.Data.Example.Models.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int length)
        {
            return string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : value.Length > length ? value.Substring(0, length) + "..." : value;
        }
    }
}
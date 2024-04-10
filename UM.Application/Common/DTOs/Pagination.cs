namespace UM.Application.Common.DTOs
{
    public record Pagination
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

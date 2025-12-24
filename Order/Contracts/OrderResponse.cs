namespace Order.Contracts
{
    public record OrderResponse(
        Guid Id,
        string ProductName,
        DateTime CreatedAt,
        string Status);
}
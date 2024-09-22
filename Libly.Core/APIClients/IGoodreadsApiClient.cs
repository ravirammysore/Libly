namespace Libly.Core.APIClients
{
    public interface IGoodreadsApiClient
    {
        double GetBookRating(string bookTitle);
    }
}

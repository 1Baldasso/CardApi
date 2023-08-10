using DesafioAda.Domain;

namespace DesafioAda.DataAccess;

public interface ICardRepository
{
    Task<Card> GetCard(Guid id);
    Task<IEnumerable<Card>> GetAllCards();
    Task<Card> CreateCard(Card card);
    Task<Card> UpdateCard(Card card);
    Task DeleteCard(Guid id);
}

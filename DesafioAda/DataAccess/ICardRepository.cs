using DesafioAda.Domain;

namespace DesafioAda.DataAccess;

public interface ICardRepository
{
    Card GetCard(Guid id);
    IEnumerable<Card> ListCards();
    Card CreateCard(Card card);
    Card UpdateCard(Card card);
    void DeleteCard(Guid id);
}

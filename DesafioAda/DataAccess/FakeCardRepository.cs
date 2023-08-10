using DesafioAda.Domain;

namespace DesafioAda.DataAccess;

public class FakeCardRepository : ICardRepository
{
    public Task<Card> CreateCard(Card card)
    {
        return Task.FromResult(card);
    }

    public Task DeleteCard(Guid id)
    {
        return Task.CompletedTask;
    }

    public Task<Card> GetCard(Guid id)
    {
        return Task.FromResult(new Card
        {
            Id = id,
            Titulo = "Placeholder Title",
            Conteudo = "Placeholder Content",
            Lista = "Placeholder List"
        });
    }

    public Task<IEnumerable<Card>> GetAllCards()
    {
        Card[] cards = new Card[4];
        for (int i = 0; i < 4; i++)
        {
            cards[i] = new Card
            {
                Id = Guid.NewGuid(),
                Titulo = "Card Title " + (i + 1),
                Conteudo = "Card Content" + (i + 1),
                Lista = string.Join($",{Environment.NewLine}",
                new[]
                {
                    $"Item 1 Lista {i + 1}",
                    $"Item 2 Lista {i + 1}",
                    $"Item 3 Lista {i + 1}",
                    $"Item 4 Lista {i + 1}"
                })
            };
        }
        return Task.FromResult(cards.AsEnumerable());
    }

    public Task<Card> UpdateCard(Card card)
    {
        return Task.FromResult(card);
    }
}

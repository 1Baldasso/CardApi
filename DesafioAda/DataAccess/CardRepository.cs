using DesafioAda.Domain;
using DesafioAda.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DesafioAda.DataAccess;

public class CardRepository : ICardRepository
{
    private readonly CardContext _context;

    public CardRepository(CardContext context)
    {
        _context = context;
    }

    public async Task<Card> CreateCard(Card card)
    {
        await _context.AddAsync(card);
        await _context.SaveChangesAsync();
        return card;
    }

    public async Task DeleteCard(Guid id)
    {
        var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
        if (card != null)
        {
            _context.Remove(card);
            await _context.SaveChangesAsync();
        }
        throw new EntityNotFoundException();
    }

    public async Task<IEnumerable<Card>> GetAllCards()
    {
        return await _context.Cards.AsNoTracking().ToListAsync();
    }

    public async Task<Card> GetCard(Guid id)
    {
        var card =  await _context.Cards.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (card != null)
        {
            return card;
        }
        throw new EntityNotFoundException();
    }

    public async Task<Card> UpdateCard(Card card)
    {
        var newCard = await _context.Cards.FirstOrDefaultAsync(x => x.Id == card.Id);
        if (newCard is null)
        {
            throw new EntityNotFoundException();
        }
        newCard.Conteudo = card.Conteudo;
        newCard.Lista = card.Lista;
        newCard.Titulo = card.Titulo;
        await _context.SaveChangesAsync();
        return newCard;
    }
}

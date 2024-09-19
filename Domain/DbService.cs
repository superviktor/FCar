using Domain;
using LiteDB;

namespace Data;

public interface IDbService
{
    List<Deck> ListDecks(Guid usedId);
    List<Card> ListCards(Guid deckId);
    void AddCard(Guid deckId, string front, string back);
    void AddDeck(Guid userId, string name);
}
public class DbService : IDbService, IDisposable
{
    private readonly string _databasePath = @"D:\pets\FCar\Data\FCar.db";
    private bool _disposed = false;

    private readonly LiteDatabase _database;

    public DbService()
    {
        try
        {
            var directory = Path.GetDirectoryName(_databasePath);
            if (directory != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            _database = new LiteDatabase(_databasePath);
        }
        catch (Exception ex)
        {
            //log
            throw;
        }
    }


    public List<Deck> ListDecks(Guid userId)
    {
        var collection = _database.GetCollection<Deck>("decks");
        return collection.Find(d => d.UserId == userId).ToList();
    }


    public List<Card> ListCards(Guid deckId)
    {
        var collection = _database.GetCollection<Card>("cards");
        return collection.Find(c => c.DeckId == deckId).ToList();
    }

    public void AddCard(Guid deckId, string front, string back)
    {
        var collection = _database.GetCollection<Card>("cards");
        collection.Insert(new Card { DeckId = deckId, Front = front, Back = back });
    }

    public void AddDeck(Guid userId, string name)
    {
        var collection = _database.GetCollection<Deck>("decks");
        collection.Insert(new Deck { UserId = userId, Name = name });
    }

    #region Disposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                _database?.Dispose();
            }

            // Free unmanaged resources (if any)
            _disposed = true;
        }
    }

    // Finalizer (destructor) for ensuring disposal if Dispose is not called
    ~DbService()
    {
        Dispose(false);
    }
    #endregion
}
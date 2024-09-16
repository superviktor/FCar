namespace Domain;

public class Deck
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Card> Cards { get; set; }
}

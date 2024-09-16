namespace Domain;

public class Card
{
    public Guid Id { get; set; }
    public string Front { get; set; }
    public string Back { get; set; }
    public Guid DeckId { get; set; }
}

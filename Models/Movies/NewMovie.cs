using RefactorMovieStore.Interfaces;

namespace RefactorMovieStore.Models;

public class NewMovie(string title, int days) : IRentalMovie
{
    private readonly string title = title;
    private readonly int days = days;

    public double AddFrequentRenterPoints()
    {
        return days > 2 ? 2 : 1;
    }

    public void AddToRecord(Record record)
    {
        record.AddMovie(title, DeterminePrice());
    }

    public double DeterminePrice()
    {
        var thisAmount = days * 3;
        return thisAmount;
    }
}
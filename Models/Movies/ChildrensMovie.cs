using RefactorMovieStore.Interfaces;

namespace RefactorMovieStore.Models;

public class ChildrensMovie(string title, int days) : IRentalMovie
{
    private readonly string title = title;
    private readonly int days = days;

    public double AddFrequentRenterPoints()
    {
        return 1;
    }

    public void AddToRecord(Record record)
    {
        record.AddMovie(title, DeterminePrice());
    }

    public double DeterminePrice()
    {
        var thisAmount = 1.5;
        if (days > 3)
        {
            thisAmount += (days - 3) * 1.5;
        }
        return thisAmount;
    }
}
using RefactorMovieStore.Interfaces;

namespace RefactorMovieStore.Models;

public class RegularMovie(string title, int days) : IRentalMovie
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
        double thisAmount = 2;
        if (days > 2)
        {
            thisAmount += (days - 2) * 1.5;
        }

        return thisAmount;
    }
}
using RefactorMovieStore.Interfaces;

namespace RefactorMovieStore.Models;

public class Record(string name)
{
    private string record = $"Rental Record for {name}\n";
    private double frequentRenterPoints = 0;
    private double totalAmount = 0;

    public void AddRentalMovie(IRentalMovie rentalMovie)
    {
        totalAmount += rentalMovie.DeterminePrice();
        frequentRenterPoints += rentalMovie.AddFrequentRenterPoints();
        rentalMovie.AddToRecord(this);
    }

    public void AddMovie(string title, double thisAmount)
    {
        record += $"\t{title}\t{thisAmount}\n";
    }

    public void AddFooterLines()
    {
        record += $"Amount owed is {totalAmount}\n";
        record += $"You earned {frequentRenterPoints} frequent renter points\n";
    }

    public override string ToString()
    {
        return record;
    }
}
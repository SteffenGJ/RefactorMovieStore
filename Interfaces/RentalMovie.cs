using RefactorMovieStore.Models;

namespace RefactorMovieStore.Interfaces;

public interface IRentalMovie
{
    double DeterminePrice();
    double AddFrequentRenterPoints();
    void AddToRecord(Record record);
}
using RefactorMovieStore.Interfaces;

namespace RefactorMovieStore.Models;

public class Customer(string name)
{
    private readonly Record record = new(name);

    public void AddRentalMovies(List<IRentalMovie> rentalMovies)
    {
        foreach (var rentalMovie in rentalMovies)
        {
            record.AddRentalMovie(rentalMovie);
        }
    }

    public string PrintRecord()
    {
        record.AddFooterLines();
        return record.ToString();
    }
}
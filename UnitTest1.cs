namespace RefactorExample;
public interface IMovie
{
    bool IsRegular();
    bool IsNew();
    bool IsChildrens();
    double DetermineAmount(Rental rental);
    void AddToRecord(Record record, double thisAmount);
}

class Regular(string title) : IMovie
{
    private readonly string title = title;
    public bool IsRegular() => true;
    public bool IsNew() => false;
    public bool IsChildrens() => false;
    public double DetermineAmount(Rental rental)
    {
        return rental.DetermineAmountForRegularMovie();
    }

    public void AddToRecord(Record record, double thisAmount)
    {
        record.AddMovie(title, thisAmount);
    }
}

class New(string title) : IMovie
{
    private readonly string title = title;
    public bool IsRegular() => false;
    public bool IsNew() => true;
    public bool IsChildrens() => false;
    public double DetermineAmount(Rental rental)
    {
        return rental.DetermineAmountForNewMovie();
    }
    public void AddToRecord(Record record, double thisAmount)
    {
        record.AddMovie(title, thisAmount);
    }
}

class Childrens(string title) : IMovie
{
    private readonly string title = title;
    public bool IsRegular() => false;
    public bool IsNew() => false;
    public bool IsChildrens() => true;
    public double DetermineAmount(Rental rental)
    {
        return rental.DetermineAmountForChildrensMovie();
    }
    public void AddToRecord(Record record, double thisAmount)
    {
        record.AddMovie(title, thisAmount);
    }
}
public class Customer(string name, List<Rental> rentals)
{
    private readonly string name = name;
    private readonly List<Rental> rentals = rentals;
    private readonly Record record = new(name);

    public void AddMovies(List<IMovie> movies)
    {
        foreach (var rental in rentals)
        {
            record.AddRental(rental, movies);
        }
    }

    public void AddsFooterLines()
    {
        record.AddFooterLines();
    }

    public string PrintRecord()
    {
        record.AddFooterLines();
        return record.ToString();
    }
}
public class Rental(int movieID, int days)
{
    private readonly int movieID = movieID;
    private readonly int days = days;

    public IMovie FindMovie(List<IMovie> movies)
    {
        return movies[movieID];
    }

    public double AddFrequentRenterPoints(IMovie movie)
    {
        return movie.IsNew() && days > 2 ? 2 : 1;
    }

    public double DetermineAmountForChildrensMovie()
    {
        var thisAmount = 1.5;
        if (days > 3)
        {
            thisAmount += (days - 3) * 1.5;
        }
        return thisAmount;
    }

    public double DetermineAmountForNewMovie()
    {
        var thisAmount = days * 3;
        return thisAmount;
    }

    public double DetermineAmountForRegularMovie()
    {
        double thisAmount = 2;
        if (days > 2)
        {
            thisAmount += (days - 2) * 1.5;
        }

        return thisAmount;
    }

}

public class Record(string name)
{
    private string record = $"Rental Record for {name}\n";
    private double frequentRenterPoints = 0;
    private double totalAmount = 0;

    public void AddRental(Rental rental, List<IMovie> movies)
    {
        var movie = rental.FindMovie(movies);
        var amount = movie.DetermineAmount(rental);
        frequentRenterPoints += rental.AddFrequentRenterPoints(movie);
        movie.AddToRecord(this, amount);
        totalAmount += amount;
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


public class Example
{
    public static string Statement(Customer customer, List<IMovie> movies)
    {
        customer.AddMovies(movies);
        return customer.PrintRecord();
    }
}

[TestClass]
public class RefactorTest
{
    // <Rental Record for John Doe
    //         The Revenant    9
    //         The Lion King   1.5
    // Amount owed is 10.5
    // You earned 3 frequent renter points
    // >. 
    [TestMethod]
    public void ShouldRunTheFunction()
    {
        var customer = new Customer("John Doe", [new Rental(0, 3), new Rental(1, 2)]);
        var movies = new List<IMovie> { new New("The Revenant"), new Childrens("The Lion King") };
        var result = Example.Statement(customer, movies);
        Assert.AreEqual("", result);
    }
}
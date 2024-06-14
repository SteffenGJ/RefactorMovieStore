using RefactorMovieStore.Interfaces;
using RefactorMovieStore.Models;

namespace RefactorMovieStore;

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
    public void ShouldPrintTheCustomerRecord()
    {
        var customer = new Customer("John Doe");
        var rentalMovies = new List<IRentalMovie> { new NewMovie("The Revenant", 3), new ChildrensMovie("The Lion King", 2) };
        customer.AddRentalMovies(rentalMovies);
        Assert.AreEqual(
            "Rental Record for John Doe\n\tThe Revenant\t9\n\tThe Lion King\t1.5\nAmount owed is 10.5\nYou earned 3 frequent renter points\n",
            customer.PrintRecord()
        );
    }
}
namespace CleanMovie.Domain;

public class Rental
{
    public int RentalId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime RentalExpiry { get; set; }
    public decimal TotalCost { get; set; }
    
    //One to many relationship
    public ICollection<Member> Members { get; set; }
    
    //Many to many relationship
    public IList<MovieRental> MovieRentals { get; set; }
}
namespace HotelListing.API.Data
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }//Country code

        public virtual IList<Hotel> Hotels{ get;set;} 
        //one country can have many hotels hence we declare a list of hotels
        //one to many relationship
    }
}
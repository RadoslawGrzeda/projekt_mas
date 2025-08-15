using System.ComponentModel.DataAnnotations;

namespace MAS.Models.Person
{
    public interface ICustomer
    {
        public void makeReservation( );
        public void getMyRentals();
        public void getMyReservation();
        public void getMyContract();
        public void cancelReservation();
        public void rentCar();
        public void signContract();
        public void returnCar();
        //public void returnCar();

        public void payDeposit();
        public void payDeposit(double ch);
        public void fillSurvey();

    }
}
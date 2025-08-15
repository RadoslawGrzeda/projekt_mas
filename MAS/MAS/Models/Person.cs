using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace MAS.Models
{
    public class Person : IAdmin,ICustomer,IEmployee
    {
       

        public string name{ get; set; }
        public string surname{ get; set; }
        public DateOnly dateOdBirth { get; set; }
        public string email { get; set; }
        public int phoneNumber{ get; set; }
        public PersonType personTypes { get; set; }
        public double? hourlyRate{ get; set; }
        //public List<Car>? numberOfPreparedCars{ get; set; }
        public DateOnly? registrationDate{ get; set; }
        public string? id { get; }
        public string? idNumber { get; set; }
        public static int generateIdNumber = 1;

        public bool? drivingLicense { get; set; }

        public Person(string name, string surname, DateOnly dateOfBirt, string email, int phoneNumber, PersonType personTypes,
            double hourlyRate,bool drivingLicense2,string idNUmber
            )
        { 
            this.name = name;
            this.surname = surname; 
            this.dateOdBirth = dateOfBirt;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.personTypes = personTypes;

            //Employee
           if(personTypes.HasFlag(PersonType.Employee))
                this.hourlyRate = hourlyRate;

            //Customer
            if (personTypes.HasFlag(PersonType.Customer))
            {
                checkLicense(drivingLicense2);
                this.registrationDate = DateOnly.FromDateTime(DateTime.Today);
                this.id = generateId();
                checkIdNumber(idNUmber);
            }

        }
        public void checkLicense(bool drv)
        {
            this.drivingLicense= drv;

            if (drivingLicense is null || drivingLicense == false)
                throw new Exception("Customer is obligated to have a driving license");
        }
        public string generateId()
        {
            return "PERSON/" + DateOnly.FromDateTime(DateTime.Today).Year + "/" + generateIdNumber;
            generateIdNumber += 1;
        }
        public void checkIdNumber(String idNumber)
        {
            IList<int> id1 = new List<int> { 48,49,50,51,52,53,54,55,56,57,58 };
            this.idNumber = idNumber;
            if (idNumber is null || idNumber.Length != 6)
                throw new Exception("Is something wrong with your id number");
            for (int i = 0; i < this.idNumber.Length; i++)
            {
                if (id1.Equals(this.idNumber[i]))
                    throw new Exception("TEST");
                Console.WriteLine(this.idNumber[i]);
                //if (i < 3)
                //{
                //    if(idNumber)
                //}
            }
        }

        public void assignEmployeeToCarPreparation()
        {
            throw new NotImplementedException();
        }

        public void assignEmployeeToRental()
        {
            throw new NotImplementedException();
        }

        public void cancelReservation()
        {
            throw new NotImplementedException();
        }

        public void chcekCarConditionAfterReturn()
        {
            throw new NotImplementedException();
        }

        public void displayAllContracts()
        {
            throw new NotImplementedException();
        }

        public void displayAllRentals()
        {
            throw new NotImplementedException();
        }

        public void displayAllReservations()
        {
            throw new NotImplementedException();
        }

        public void displayTopEmployees()
        {
            throw new NotImplementedException();
        }

        public void displayTopRentingClients()
        {
            throw new NotImplementedException();
        }

        public void fillSurvey()
        {
            throw new NotImplementedException();
        }

        //public List<Reservation>? numberOfReservation { get; set; }







        public int getAge()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age=today.Year-dateOdBirth.Year ;
            if (today.DayOfYear < dateOdBirth.DayOfYear)
                age--;
            return age;
        }

        public void getMyContract()
        {
            throw new NotImplementedException();
        }

        public void getMyRentals()
        {
            throw new NotImplementedException();
        }

        public void getMyReservation()
        {
            throw new NotImplementedException();
        }

        public bool hasRole(PersonType role)
        {
            return personTypes.HasFlag(role);
        }

        public void makeReservation()
        {
            throw new NotImplementedException();
        }

        public void payDeposit()
        {
            throw new NotImplementedException();
        }

        public void payDeposit(double ch)
        {
            throw new NotImplementedException();
        }

        public void prepareCar()
        {
            throw new NotImplementedException();
        }

        public void rentCar()
        {
            throw new NotImplementedException();
        }

        public void returnCar()
        {
            throw new NotImplementedException();
        }

        public void signContract()
        {
            throw new NotImplementedException();
        }
        //public showAvailableCars()
        //{
        //    return List<Car>;
        //}
    }
}

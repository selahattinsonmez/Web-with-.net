using System.Linq;

using System.Web.Mvc;


using Denemem.Models;
using System;
using System.Collections.Generic;

namespace MovieApp.Controllers

{
    
    public class HomeController : Controller

    {
        
        private ContextDatabase _db = new ContextDatabase();

        public ActionResult Index()

        {
            List<Car> car = _db.Cars.Where(x => x != null).ToList();
                
            return View(car);

        }

        [Route("Home/Info/{CarID}")]

        public ActionResult Info(int CarID)
        {
            var result=_db.Cars.FirstOrDefault(x => x.CarID == CarID);
            

            return View(result);
        }

        [Route("Home/Reservation")]
        public ActionResult Reservation()
        {
            
            return View();
        }

        [Route("Home/Reservation/MyReservation/{CustomerSSN}")]
        public ActionResult MyReservation(string CustomerSSN)
        {
            var reservation = _db.Reservations.Where(x => x.CustomerSSN.ToString()==CustomerSSN );
            int a =reservation.Count();
            Car[] cars=new Car[a+1];
            ResInfoView[] result = new ResInfoView[a];
            int i =0;
            var customer = _db.Customers.FirstOrDefault(x => x.CustomerSSN == reservation.FirstOrDefault().CustomerSSN);
            foreach (var item in reservation)
            {
                cars[i] = _db.Cars.FirstOrDefault(x=> x.CarID== item.CarID);
                result[i]=new ResInfoView();
                result[i].CarImage = cars[i].CarImage;
                result[i].CarModel = cars[i].CarModel;
                result[i].CarPlate = cars[i].CarPlate;
                result[i].CarPrice = cars[i].CarPrice;
                result[i].CarYear = cars[i].CarYear;
                result[i].CustomerName = customer.CustomerName;
                result[i].CustomerSSN = customer.CustomerSSN;
                result[i].ReservationEndDate = item.ReservationEndDate;
                result[i].ReservationStartDate = item.ReservationStartDate;
                result[i].ReservationStuation = item.ReservationStuation;
                result[i].ReservationID = item.ReservationID;
                i++;
            }
            

            return View(result);
        }
        [HttpPost]
        [Route("Home/Info/{CarID}/AddCustomer/")]
        
        public ActionResult AddCustomer(FormCollection form )
        {
            var carID= int.Parse(form["CarID"]);
            var result1 = _db.Reservations.Where(x=> x!=null);
            var datestart = DateTime.Parse(form["Start"]);
            var dateend= DateTime.Parse(form["End"]);
            int counta = 0;
            TimeSpan datecmp=new TimeSpan();
            TimeSpan datecmp2 = new TimeSpan();
            foreach (var item in result1)
            {
                if(item.CarID==carID)
                { 
                    datecmp = Convert.ToDateTime(item.ReservationStartDate) - datestart;
                    datecmp2 =  Convert.ToDateTime(item.ReservationEndDate)-datestart;
                    if(   ((datecmp.TotalDays)<=0) && ((datecmp2.TotalDays) > 0))
                    {
                        counta++;
                    }


                }

            }

            if (counta == 0)
            {
                int a = 0;
                Customer customer = new Customer();
                customer.CustomerSSN = int.Parse(form["TC"]);
                customer.CustomerName = form["CustomerName"];
                customer.CustomerPNumber = form["CustomerPhoneNumber"];
                customer.CustomerAddress = form["CustomerAddress"];
                if (_db.Customers.FirstOrDefault(x => x.CustomerSSN == customer.CustomerSSN) == null)
                {
                    _db.Customers.Add(customer);
                    _db.SaveChanges();
                    a++;
                }

                Reservation Reserv = new Reservation();
                Reserv.CarID = int.Parse(form["CarID"]);
                Reserv.CustomerSSN = int.Parse(form["TC"]);
                Reserv.ReservationStartDate = DateTime.Parse(form["Start"]);
                Reserv.ReservationEndDate = DateTime.Parse(form["End"]);

                Reserv.Car = _db.Cars.FirstOrDefault(x => x.CarID == Reserv.CarID);
                if (a == 0)
                {
                    Reserv.Customer = _db.Customers.FirstOrDefault(x => x.CustomerSSN == customer.CustomerSSN);
                }
                else
                {
                    Reserv.Customer = customer;
                }
                Reserv.ReservationStuation = true;
                List<Reservation> result = _db.Reservations.Where(x => x != null).ToList();
                int i = 1;
                if (result != null)
                {
                    for (int k = 0; k < result.Count; k++)
                    {
                        i = result[k].ReservationID + 1;
                    }

                }
                Reserv.ReservationID = i;

                _db.Reservations.Add(Reserv);
                _db.SaveChanges();

                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home/Info/" + carID.ToString());
            }
        }


        [HttpPost]
        [Route("Home/CanceledReservation")]
        public ActionResult CanceledReservation(FormCollection form)
        {
            int a = int.Parse(form["ReservationID"]);
            Reservation res = _db.Reservations.FirstOrDefault(x => x.ReservationID ==a );           
            _db.Reservations.Remove(res);
            _db.SaveChanges();

            return Redirect("/Home");
        }



    }

}
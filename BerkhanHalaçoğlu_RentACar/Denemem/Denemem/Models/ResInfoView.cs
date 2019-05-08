using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denemem.Models
{
    public class ResInfoView
    {
        public int ReservationID { get; set; }
        public Nullable<int> CustomerSSN { get; set; }
        public Nullable<System.DateTime> ReservationStartDate { get; set; }
        public Nullable<System.DateTime> ReservationEndDate { get; set; }
        public Nullable<bool> ReservationStuation { get; set; }
        public string CustomerName { get; set; }
        public string CarPlate { get; set; }
        public string CarModel { get; set; }
        public Nullable<int> CarYear { get; set; }
        public Nullable<double> CarPrice { get; set; }
        public string CarImage { get; set; }
    }
}
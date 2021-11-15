using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDDApp
{
    class DriverData
    {
        public int GUID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string PassportSerial { get; set; }
        public string PassportNumber { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime LicenseDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string LicenseSeries { get; set; }
        public int LicenseNumber { get; set; }
        public string AdressStreet { get; set; }
        public string AdressCity { get; set; }
        public string AdressLifeStreet { get; set; }
        public string AdressLifeCity { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string JobName { get; set; }

        int statusId;
        public int StatusId
        {
            set 
            {
                statusId = value - 1;
            }
            get { return statusId; }
        }
        public string StatusName { get; set; }
        public string IsDelete { get; set; }
    }
}

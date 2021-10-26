using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GIBDDApp
{
    /// <summary>
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Page
    {
        public DriverPage(Drivers selectedDriver)
        {
            InitializeComponent();

            if (selectedDriver != null)
            {
                var currentDriver = (from d in GIBDDEntities.GetContext.Drivers
                                  join dl in GIBDDEntities.GetContext.DriverLicense on d.GUID equals dl.DriverGUID
                                  join c in GIBDDEntities.GetContext.Contact on d.GUID equals c.DriverGUID
                                  join j in GIBDDEntities.GetContext.Job on d.GUID equals j.DriverGUID
                                  select new
                                  {
                                      GUID = d.GUID,
                                      Surname = d.Surname,
                                      Name = d.Name,
                                      Middlename = d.Middlename,
                                      PassportSerial = d.PassportSerial,
                                      PassportNumber = d.PassportNumber,
                                      Photo = d.Photo,
                                      Description = d.Description,
                                      LicenseDate = dl.LicenseDate,
                                      ExpireDate = dl.ExpireDate,
                                      LicenseSeries = dl.LicenseSeries,
                                      LicenseNumber = dl.LicenseNumber,
                                      Status = dl.Status,
                                      AdressStreet = c.AddressStreet,
                                      AdressCity = c.AdressCity,
                                      AdressLifeStreet = c.AdressLifeStreet,
                                      AdressLifeCity = c.AdressLifeCity,
                                      PhoneNumber = c.PhoneNumber,
                                      Email = c.PhoneNumber,
                                      Company = j.Company,
                                      Jobname = j.JobName,
                                  }).Where(p => p.GUID.Equals(selectedDriver.GUID)).ToList();
                
                DataContext = currentDriver;
            }

        }

    }
}

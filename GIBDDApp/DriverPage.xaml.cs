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
        private DriverData _currentDriver = new DriverData();
        public DriverPage(Drivers selectedDriver)
        {
            InitializeComponent();

            if (selectedDriver != null)
            {
                _currentDriver = (from d in GIBDDEntities.GetContext.Drivers
                                  join dl in GIBDDEntities.GetContext.DriverLicense on d.GUID equals dl.DriverGUID
                                  join c in GIBDDEntities.GetContext.Contact on d.GUID equals c.DriverGUID
                                  join j in GIBDDEntities.GetContext.Job on d.GUID equals j.DriverGUID
                                  select new DriverData
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
                                      AdressCity = c.AdressCity,
                                      AdressLifeStreet = c.AdressLifeStreet,
                                      AdressLifeCity = c.AdressLifeCity,
                                      PhoneNumber = c.PhoneNumber,
                                      Email = c.Email,
                                      Company = j.Company,
                                      JobName = j.JobName,
                                      StatusId = dl.StatusId,
                                      IsDelete = d.IsDelete,
                                      AdressStreet = c.AddressStreet,
                                  }).Where(p => p.GUID.Equals(selectedDriver.GUID)).FirstOrDefault();
            }

            DataContext = _currentDriver;
            ComboStatus.ItemsSource = GIBDDEntities.GetContext.Status.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(_currentDriver.GUID == 0))
            {
                var currentDriver = new Drivers
                {
                    GUID = _currentDriver.GUID,
                    Surname = _currentDriver.Surname,
                    Name = _currentDriver.Name,
                    Middlename = _currentDriver.Middlename,
                    PassportSerial = _currentDriver.PassportSerial,
                    PassportNumber = _currentDriver.PassportNumber,
                    Photo = _currentDriver.Photo,
                    Description = _currentDriver.Description,
                    IsDelete = _currentDriver.IsDelete,
                    //Contact =
                    //{
                    //    DriverGUID = _currentDriver.GUID
                    //}


                };

            }

            if (_currentDriver.GUID == 0)
            {

                //var author = new Author
                //{
                //    FirstName = "William",
                //    LastName = "Shakespeare",
                //    Books = new List<Book>
                //    {
                //        new Book { Title = "Hamlet" },
                //        new Book { Title = "Othello" },
                //        new Book { Title = "MacBeth" }
                //    }
                //};
                Drivers currentDriver = new Drivers();
                currentDriver.Surname = _currentDriver.Surname;
                currentDriver.Name = _currentDriver.Name;
                currentDriver.Middlename = _currentDriver.Middlename;
                currentDriver.PassportSerial = _currentDriver.PassportSerial;
                currentDriver.PassportNumber = _currentDriver.PassportNumber;
                currentDriver.Photo = _currentDriver.Photo;

                DriverLicense currentDriverLicense = new DriverLicense();
                currentDriverLicense.LicenseDate = _currentDriver.LicenseDate;
                currentDriverLicense.ExpireDate = _currentDriver.ExpireDate;
                currentDriverLicense.LicenseSeries = _currentDriver.LicenseSeries;
                currentDriverLicense.LicenseNumber = _currentDriver.LicenseNumber;
                currentDriverLicense.StatusId = ComboStatus.SelectedIndex + 1;

                // https://www.learnentityframeworkcore.com/dbcontext/adding-data
                // ПРОЧИТАЙ ДЕБИЛ А ТО ЗАБУДЕШЬ ОПЯТЬ КАК ЭТО СДЕЛАТЬ И НЕ СДЕЛАЕШЬ НИЧЕРТА
                // Запись с 11.11.21 на 12.11.21

                GIBDDEntities.GetContext.Drivers.Add(currentDriver);
            }
            try
            {
                GIBDDEntities.GetContext.SaveChanges();
                MessageBox.Show("Data saved");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}

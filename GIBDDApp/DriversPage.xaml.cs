using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для DriversPage.xaml
    /// </summary>
    public partial class DriversPage : Page
    {
        private static string _status;
        public DriversPage()
        {
            _status = null;
            InitializeComponent();
            UpdateDrivers();

            BtnBackToDrivers.Visibility = Visibility.Hidden;
            BtnExcel.Visibility = Visibility.Hidden;
        }

        public void UpdateDrivers()
        {
            var currentDrivers = GIBDDEntities.GetContext.Drivers.Where(p => p.IsDelete == _status).ToList();

            currentDrivers = currentDrivers.Where(p => p.Surname.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (currentDrivers.Count > 0)
            {
                LViewDrivers.ItemsSource = currentDrivers.OrderBy(p => p.Surname).ToList();
                LViewDrivers.Visibility = Visibility.Visible;
            }
            else
                LViewDrivers.Visibility = Visibility.Hidden;
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDrivers();
        }

        private void LViewDrivers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new DriverPage(LViewDrivers.SelectedItem as Drivers));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var DriversToArchive = LViewDrivers.SelectedItems.Cast<Drivers>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {DriversToArchive.Count()} элементов?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var Driver in DriversToArchive)
                    {
                        Driver.IsDelete = "Deleted";
                        GIBDDEntities.GetContext.SaveChanges();
                    }
                    UpdateDrivers();
                }
                catch (Exception ex)
                {
                    UpdateDrivers();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnArchive_Click(object sender, RoutedEventArgs e)
        {
            _status = "Deleted";
            UpdateDrivers();

            BtnBackToDrivers.Visibility = Visibility.Visible;
            BtnExcel.Visibility = Visibility.Visible;
            BtnArchive.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;
        }


        private void BtnBackToDrivers_Click(object sender, RoutedEventArgs e)
        {
            _status = null;
            UpdateDrivers();

            BtnBackToDrivers.Visibility = Visibility.Hidden;
            BtnExcel.Visibility = Visibility.Hidden;
            BtnArchive.Visibility = Visibility.Visible;
            BtnDelete.Visibility = Visibility.Visible;
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            string pathFile = @"C:\Users\3231\Desktop\Drivers.csv";
            try 
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(pathFile, FileMode.Create, FileAccess.Write), Encoding.UTF8))
                {
                    writer.WriteLine("GUID;Surname;Name;Middlename;Passport Series;Passport Number;Description;Photo;City;Adress;CityLife;AdressLife;Phone;Mail;Company;Job Name" +
                        ";Start Date;Expire Date;License Series;License Number;Status;Categories;VIN;Manufactory;Car Model;Year;Weight;Color;Engine Type");
                    foreach (Drivers Driver in GIBDDEntities.GetContext.Drivers.ToList().Where(p => p.IsDelete == "Deleted"))
                    {
                        var Contacts = Driver.Contact.FirstOrDefault(x => x.DriverGUID == Driver.GUID);
                        var Jobs = Driver.Job.FirstOrDefault(x => x.DriverGUID == Driver.GUID);
                        var License = Driver.DriverLicense.FirstOrDefault(x => x.DriverGUID == Driver.GUID);
                        var Cars = Driver.Car.FirstOrDefault(x => x.DriverGUID == Driver.GUID);
                        var CarsModel = Cars.CarModel.FirstOrDefault(x => x.CarId == Cars.Id);
                        var CarsSpecification = CarsModel.CarSpecification.FirstOrDefault(x => x.ModelId == CarsModel.Id);

                        string Category = null;
                        string TypeOfDrive = null;

                        foreach (var c in License.CategoryOfLicense)
                        {
                            if (Category == null)
                                Category = c.Category.Categories;
                            else
                                Category = Category + ", " + c.Category.Categories;
                        }

                        foreach (var t in CarsSpecification.TypeOfDriveOfCar)
                        {
                            if (TypeOfDrive == null)
                                TypeOfDrive = t.TypeOfDrive.DriveName;
                            else
                                TypeOfDrive = TypeOfDrive + ", " + t.TypeOfDrive.DriveName;
                        }

                        writer.WriteLine($"{Driver.GUID};{Driver.Surname};{Driver.Name};{Driver.Middlename};{Driver.PassportSerial};{Driver.PassportNumber};{Driver.Description};{Driver.Photo};" +
                            $"{Contacts.AdressCity};{Contacts.AddressStreet};{Contacts.AdressLifeCity};{Contacts.AdressLifeStreet};{Contacts.PhoneNumber};{Contacts.Email};" +
                            $"{Jobs.Company};{Jobs.JobName};" +
                            $"{License.LicenseDate};{License.ExpireDate};{License.LicenseSeries};{License.LicenseNumber};{License.Status.Name};{Category};" +
                            $"{Cars.VIN};{CarsModel.Manufacter.Name};{CarsModel.Model};{CarsSpecification.Year};{CarsSpecification.Weight};{CarsSpecification.Color};{TypeOfDrive}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DriverPage(null));
        }
    }
}

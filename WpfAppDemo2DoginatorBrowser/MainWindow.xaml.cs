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
using WpfAppDemo2DoginatorBrowser.Models;

namespace WpfAppDemo2DoginatorBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Dog> Dogs; //Declares a list of Dogs
        int selectedDogIndex;

        public MainWindow()
        {
            InitializeComponent();
            SetupDogs();
            selectedDogIndex = 0;
            DisplayDog(selectedDogIndex);
        }

        public void SetupDogs()
        {
            Dogs = new List<Dog>()
            {
                new Dog(),
                new Dog() { Name="milo", 
                    Age =3, 
                    BarkSound="arf!", 
                    Weight=3, Image="/Assets/milo.jpg" },
                new Dog() { Name="Cheddar", Age=4, BarkSound="Woof!", Weight =4,
                 Image = "/Assets/roover.jpg"} 
            };
        }

        public void DisplayDog(int dogIndex)
        {
            lblIndex.Content = (dogIndex + 1) + " of " + Dogs.Count;
            tbName.Text = Dogs[dogIndex].Name;
            tbAge.Text = Dogs[dogIndex].Age.ToString();
            tbWeight.Text = Dogs[dogIndex].Weight.ToString() ;
            tbBarkSound.Text = Dogs[dogIndex].BarkSound;

            BitmapImage bitmap = new BitmapImage();
            bitmap.CacheOption = BitmapCacheOption.OnDemand;
            bitmap.BeginInit();
            bitmap.UriSource = new Uri( Dogs[dogIndex].Image, UriKind.Relative );
            bitmap.EndInit();


            imgDogImage.Width = 400;
            imgDogImage.Source = bitmap;


            //button Logic
            if (dogIndex > 0)
            {
                btnNavPrev.IsEnabled = true;
            }
            else
            {
                btnNavPrev.IsEnabled = false;
            }

            if(dogIndex >= Dogs.Count -1)
            {
                btnNavNext.IsEnabled = false;
            }
            else
            {
                btnNavNext.IsEnabled = true;
            }
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            lblAbout.Content = Dogs[selectedDogIndex].About();
        }

        private void btnEat_Click(object sender, RoutedEventArgs e)
        {
            Dogs[selectedDogIndex].Eat();
            DisplayDog(selectedDogIndex);
        }

        private void btnPoop_Click(object sender, RoutedEventArgs e)
        {
            Dogs[selectedDogIndex].Poop();
            DisplayDog(selectedDogIndex);
        }

        private void btnNavPrev_Click(object sender, RoutedEventArgs e)
        {
             selectedDogIndex = selectedDogIndex - 1;
             DisplayDog(selectedDogIndex);
        }

        private void btnNavNext_Click(object sender, RoutedEventArgs e)
        {
            selectedDogIndex = selectedDogIndex + 1;
            DisplayDog(selectedDogIndex);
        }

        private void btnAddDog_Click(object sender, RoutedEventArgs e)
        {
            pnlAddDog.Visibility = Visibility.Visible;
        }

        private void btnAddDogSave_Click(object sender, RoutedEventArgs e)
        {
            pnlAddDog.Visibility = Visibility.Collapsed;
            try
            {
                Dog d = new Dog()
                {
                    Name = tbAddDogName.Text,
                    Age = int.Parse(tbAddDogAge.Text),
                    Weight = int.Parse(tbAddDogWieght.Text),
                    BarkSound = tbAddDogBarkSound.Text
                };
                this.Dogs.Add(d);
                selectedDogIndex = Dogs.IndexOf(d);
                DisplayDog(selectedDogIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry couldn't add dog!!!! " + ex.Message);
            }
        }
    }
}

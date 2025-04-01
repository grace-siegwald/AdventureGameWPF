using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * Adventure Game 
 * Grace Siegwald
 * 4/1/25
 */

namespace AdventureGameWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public World World = new World();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            OutputBox.Text = "Welcome to the Adventure Game!" +
                "\nPlease enter your name below...";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if(World.Player.Name == "")
            {
                SetPlayerName();
                ShowMenu();
            }
            else
            {
                string input = InputBox.Text;
                if (int.TryParse(input, out int number))
                {
                    // is the number a valid location? 
                    int totalNumberLocation = World.Locations.Count;
                    if (number > 0 && number <= totalNumberLocation)
                    {
                        // "travel" to that location
                        Location thePlace = World.Locations[number-1];
                        InputBox.Text = "";
                        OutputBox.Text = thePlace.Visit();
                        LocationImage.Source = new BitmapImage(new Uri(thePlace.LocationImage, UriKind.Relative));
                    }
                    else
                    {
                        OutputBox.Text += $"\nPlease enter a valid input";
                    }
                }
                else
                {
                    OutputBox.Text += $"\nPlease enter a valid input";
                    ShowMenu();
                }
            }
        }

        private void SetPlayerName()
        {
            World.Player.Name = InputBox.Text;
            if (World.Player.Name == "")
            {
                World.Player.Name = "Anonymous";
            }             
            OutputBox.Text += $"\n\nWelcome to the game, {World.Player.Name}!";
            InputBox.Text = "";
        }

        private void ShowMenu()
        {
            OutputBox.Text += World.GetLocationList();
        }
    }
}
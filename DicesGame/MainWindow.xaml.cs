using DicesGame.Models;
using System.Collections.ObjectModel;
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

namespace DicesGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Dices = new ObservableCollection<Dice>( Enumerable.Range(1, 6).Select(x => new Dice() { Number = x} ));
        }

        public ObservableCollection<Dice> Dices { get; }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Dices.Add(new Dice());
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if(Dices.Any())
                Dices.RemoveAt(0);
        }

        private void Button_Roll(object sender, RoutedEventArgs e)
        {
            var random = new Random();

            foreach (var dice in Dices.Where(x => !x.IsLocked))
            {
                dice.Number = random.Next(1, 7);
            }
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                if(button.DataContext is Dice dice)
                {
                    dice.IsLocked = !dice.IsLocked;
                }
            }
        }
    }
}
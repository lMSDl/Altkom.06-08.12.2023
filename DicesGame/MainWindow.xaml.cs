using DicesGame.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int progress;
        private int maxProgress;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Dices = new ObservableCollection<Dice>( Enumerable.Range(1, 6).Select(x => new Dice() { Number = x} ));
        }

        public ObservableCollection<Dice> Dices { get; }
        public int Progress
        {
            get => progress;
            set
            {
                progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }
        public int MaxProgress
        {
            get => maxProgress;
            set
            {
                maxProgress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxProgress)));
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Dices.Add(new Dice());
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if(Dices.Any())
                Dices.RemoveAt(0);
        }

        private async void Button_Roll(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            Progress = 0;
            MaxProgress = 0;
            var tasks = Dices.Where(x => !x.IsLocked).Select(x => RollAsync(random, x)).ToList();

            await Task.WhenAll(tasks);
        }

        private async Task RollAsync(Random random, Dice dice)
        {
            var numberOfRols = random.Next(25, 75);
            Interlocked.Add(ref maxProgress, numberOfRols);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxProgress)));
            for (int i = 0; i < numberOfRols; i++)
            {
                dice.Number = random.Next(1, 7);
                await Task.Delay(25);

                Interlocked.Increment(ref progress);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
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
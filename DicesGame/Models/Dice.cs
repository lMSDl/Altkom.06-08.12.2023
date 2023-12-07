using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicesGame.Models
{
    public class Dice : NotifyPropertyChanged
    {
        private int number;

        public int Number
        {
            get => number; set
            {
                number = value;
                OnPropertyChanged();
            }
        }
    }
}

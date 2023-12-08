using System.ComponentModel;

namespace Models
{
    public class Product : DataErrorInfo, ICloneable
    {
        private string name = string.Empty;

        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public float Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool Priority { get; set; }

        public string Summary => $"{Name}; {Price} zł";

        //public bool IsExpired => ExpirationDate < DateTime.Now;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

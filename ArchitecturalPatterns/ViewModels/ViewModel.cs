using ArchitecturalPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturalPatterns.ViewModels
{
    internal class ViewModel
    {
        public ViewModel()
        {
            Model = new SomeModel() { Value = "ala ma kota" };
        }

        public SomeModel Model { get; set; }


    }
}

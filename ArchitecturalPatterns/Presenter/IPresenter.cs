using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturalPatterns.Presenter
{
    internal interface IPresenter
    {
        void Save(string value);
        void Load();
    }
}

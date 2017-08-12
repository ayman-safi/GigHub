using Gighub.Models;
using System.Collections.Generic;

namespace Gighub.ViewModels
{
    public class Homeviewmodel
    {
        public string heading { get; set; }
        public IEnumerable<GIg> Upcominggigs { get; set; }
        public bool ShowActions { get; set; }
    }
}



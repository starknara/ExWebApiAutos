using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TAuto
    {
        public Guid AutoId { get; set; }
        public string AutoColor { get; set; }
        public string AutoAnioFab { get; set; }
        public string AutoPlaca { get; set; }
        public string AutoNroAsientos { get; set; }
        public string AutoTransmision { get; set; }
        public string AutoVersion { get; set; }
        public Guid MarcaId { get; set; }

        public TMarca Marca { get; set; }
    }
}

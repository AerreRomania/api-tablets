using System;

namespace SmartB.API.Models
{
    public class AngajatiForCreation
    {
        public string CodAngajat { get; set; }

        public string Angajat { get; set; }

        public string Sex { get; set; }

        public string Telefon { get; set; }

        public string Adresa { get; set; }

        public string Linie { get; set; }

        public int IdSector { get; set; }
        public DateTime? LastTimeLogged { get; set; }

    }
}

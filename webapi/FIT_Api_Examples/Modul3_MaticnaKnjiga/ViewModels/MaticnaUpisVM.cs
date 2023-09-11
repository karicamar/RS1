using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaUpisVM
    {
        public DateTime datum { get; set; }
        public int godinaStudija { get; set; }

        public int akGodina { get; set; }

        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }
    }
}


using FIT_Api_Examples.Modul2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class UpisAkGodine
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(student))]
        public int student_id { get; set; }
        public Student student { get; set; }

        [ForeignKey(nameof(akademskaGodina))]
        public int akademskaGodina_id { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }

        [ForeignKey(nameof(evidentirao))]
        public int evidentirao_id { get; set; }
        public KorisnickiNalog evidentirao { get; set; }

        public int godinaStudija { get; set; }
        public float cijena { get; set; }
        public DateTime? upisGod { get; set; }
        public DateTime? ovjeraGod { get; set; }
        public bool obnova { get; set; }

        public string? napomena { get; set; }
    }
}

using FIT_Api_Examples.Data;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaticnaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult Upisi(int id, [FromBody] MaticnaUpisVM novi)
        {
            Student student = _dbContext.Student.Find(id);
            if (student == null)
                return BadRequest("Nema");

            if (novi.obnova || !_dbContext.UpisAkGodine.ToList()
                           .Exists(x => x.godinaStudija == novi.godinaStudija && x.student_id == student.id))
            {
                var godina = new UpisAkGodine()
                {
                    student_id = student.id,
                    akademskaGodina_id = novi.akGodina,
                    godinaStudija = novi.godinaStudija,
                    upisGod = novi.datum,
                    cijena = novi.cijenaSkolarine,
                    obnova = novi.obnova,
                    evidentirao_id = 1
                };
                _dbContext.Add(godina);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }

        [HttpGet]
        public ActionResult<MaticnaVM> GetById(int id)
        {
            Student student = _dbContext.Student.Find(id);
            if (student == null)
                return BadRequest("Nema");

            var maticna = new MaticnaVM()
            {
                id = student.id,
                ime = student.ime,
                prezime = student.prezime,
                akGodina = _dbContext.AkademskaGodina.Select(x => new Helper.CmbStavke() { id = x.id, opis = x.opis }).ToList(),
                upisAkGodine = _dbContext.UpisAkGodine.Where(x => x.student_id == id)
                .Include(x => x.student)
                .Include(x => x.akademskaGodina)
                .Include(x => x.evidentirao)
                .ToList()
            };
            return Ok(maticna);
        }

        [HttpPost]
        public ActionResult Ovjeri(int id)
        {
            UpisAkGodine upisAkGodine = _dbContext.UpisAkGodine.Find(id);
            if (upisAkGodine == null)
                return BadRequest("Nema");

            upisAkGodine.ovjeraGod = DateTime.Now;

            _dbContext.SaveChanges();
            
            return Ok(upisAkGodine);
            }
          

        

    }
}

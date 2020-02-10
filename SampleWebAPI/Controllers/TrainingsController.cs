using SampleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebAPI.Controllers
{
    public class TrainingsController : ApiController
    {
        static List<Trainings> trainings = new List<Trainings>();

        public IEnumerable<Trainings> Get()
        {
            //read trainings from db
            //var trainings = db.Get....
            var trainings = GetTrainingsFromDB();

            return trainings;
        }

        [HttpGet]
        public IEnumerable<Trainings> Get(string id)
        {
            var trainings = GetTrainingsFromDB().Where(x => x.Room == id);
            return trainings;
        }

        [HttpPost]
        public IEnumerable<Trainings> Post([FromBody] Trainings training)
        {
            var trainings = GetTrainingsFromDB();
            var id = (int)trainings.Max(x => x.Id);
            training.Id = id + 1;

            trainings.Add(training);
            return trainings;
        }


        public void Delete(int id)
        {
            var trainings = GetTrainingsFromDB();
            var item = trainings.FirstOrDefault(x => x.Id == id);
            trainings.Remove(item);
        }


        private List<Trainings> GetTrainingsFromDB()
        {
            if (trainings.Count == 0)
            {
                trainings.Add(new Trainings() { Id= 1,Title = "JavaScript", Room = "A" });
                trainings.Add(new Trainings() { Id= 2,Title = "HTML5", Room = "B" });
                trainings.Add(new Trainings() { Id= 3,Title = "C#", Room = "A" });
                trainings.Add(new Trainings() { Id= 4,Title = "C# Advanced", Room = "B" });
            }
            return trainings;
        }
    }
}

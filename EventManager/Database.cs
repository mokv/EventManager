using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManager
{
    public class Database
    {
        public void CreateEvent(string name, string location, DateTime startDateTime, DateTime endDateTime)
        {
            using (var db = new EventsManagerEntities())
            {
                EventManager.Event newEvent = new EventManager.Event()
                {
                    Name = name,
                    Location = location,
                    StartDateTime = startDateTime,
                    EndDateTime = endDateTime
                };
                db.Events.Add(newEvent);
                db.SaveChanges();
            }
        }

        public void ShowAllEvents()
        {
            using (var db = new EventsManagerEntities())
            {
                foreach (var item in db.Events)
                {
                    PrintEvent(item);
                }
            }
        }

        public void GetAllIds(List<int> allIds)
        {
            allIds.Clear();
            using(var db = new EventsManagerEntities())
            {
                foreach(var item in db.Events)
                {
                    int id = item.Id;
                    allIds.Add(id);
                }
            }
        }

        public void ShowEventById(int id)
        {
            using(var db = new EventsManagerEntities())
            {
                Event eve = db.Events.First(x => x.Id == id);
                PrintEvent(eve);
            }
        }

        public void UpdateName(int id, string newName)
        {
            using(var db = new EventsManagerEntities())
            {
                var eve = db.Events.First(x => x.Id == id);
                eve.Name = newName;
                db.Entry(eve).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateLocation(int id, string newLocation)
        {
            using (var db = new EventsManagerEntities())
            {
                var eve = db.Events.First(x => x.Id == id);
                eve.Location = newLocation;
                db.Entry(eve).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateStartDateTime(int id, DateTime newStartDateTime)
        {
            using (var db = new EventsManagerEntities())
            {
                var eve = db.Events.First(x => x.Id == id);
                eve.StartDateTime = newStartDateTime;
                db.Entry(eve).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateEndDateTime(int id, DateTime newEndDateTime)
        {
            using (var db = new EventsManagerEntities())
            {
                var eve = db.Events.First(x => x.Id == id);
                eve.EndDateTime = newEndDateTime;
                db.Entry(eve).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteEventById(int id)
        {
            using (var db = new EventsManagerEntities())
            {
                var eve = db.Events.First(x => x.Id == id);
                db.Events.Remove(eve);
                db.SaveChanges();
            }
        }

        public void PrintEvent(Event ev)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("ID: [" + ev.Id + "]\nName: " + ev.Name + "\nLocation: " + ev.Location + "\nStarts on: " + ev.StartDateTime.ToString() + "\nEnds on: " + ev.EndDateTime.ToString());
            Console.WriteLine("----------------------------------------------------------");
        }
    }
}

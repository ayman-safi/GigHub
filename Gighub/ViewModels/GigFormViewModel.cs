using Gighub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gighub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public string heading { get; set; }

        public string Action
        {
            /* you can edit this class to avoid the magic string 
             by implement the lambda expression (section 2 model 2 last video)
            */
            get
            {
                return (Id != 0) ? "Edit" : "Create";
            }
        }

        public IEnumerable<Genre> Genres { get;set;}

        public DateTime GetDateTime()
        { 
            return DateTime.Parse(string.Format("{0} {1}",Date,Time));
        }

    }
}
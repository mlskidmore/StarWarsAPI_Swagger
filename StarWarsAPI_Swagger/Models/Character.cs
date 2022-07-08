﻿using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsAPI.Models
{

    public class Character
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }

        [NotMapped]
        public string[] films { get; set; }

        [NotMapped]
        public string[] species { get; set; }

        [NotMapped]
        public string[] vehicles { get; set; }

        [NotMapped]
        public string[] starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

}

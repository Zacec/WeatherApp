using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Weather
    {
        public int Id { get; set; }
        public virtual City City { get; set; }
        public DateTime Date { get; set; }
        public string Condition { get; set; }
        [Required(ErrorMessage = "This data is required")]
        [Range(-60,60,ErrorMessage = "Data out of range")]
        public int TempMin { get; set; }
        [Required(ErrorMessage = "This data is required")]
        [Range(-60, 60, ErrorMessage = "Data out of range")]
        public int TempMax { get; set; }
        [Required(ErrorMessage = "This data is required")]
        [Range(-60, 60, ErrorMessage = "Data out of range")]
        public int RealFeel { get; set; }
    }
}

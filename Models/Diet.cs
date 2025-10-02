using System.ComponentModel.DataAnnotations;

namespace GetFit_Application.Models
{
    public class Diet
    {
        //Models to reflext the Macro info in the dashboard
        [Required]

        public int Id { get; set; }
        public string Food { get; set; }
        public int Calories { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public string Carbohyrdates { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
    }
}

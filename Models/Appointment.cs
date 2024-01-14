using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace PlatinumGym.Models
{
    public class Appointment
    {
        public int ID { get; set; }

        [Display(Name = "Trainer")]
        public int? TrainerID { get; set; }

        [Display(Name = "Client")]
        public int? ClientID { get; set; }

        [Display(Name = "Subscription")]
        public int? SubscriptionID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = "Data Programării")]
        public DateTime Data { get; set; }

        [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Ora introdusă nu este validă.")]
        public string Ora { get; set; }
        public Trainer? Trainer { get; set; }
        public Client? Client { get; set; }
        public Subscription? Subscription { get; set; }

    }
}


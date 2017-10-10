using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ÄlytaloWEB.ViewModels
{
    public class SaunaViewModel
    {
        public int? Sauna_ID { get; set; }
        public int? SaunaNro { get; set; }
        public string SaunanNimi { get; set; }
        public string SaunaTavoiteLampotila { get; set; }
        public string SaunaNykyLampotila { get; set; }
        public bool SaunanTila { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy\\-MM\\-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sauna On")]
        public DateTime? SaunaStart { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy\\-MM\\-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sauna Off")]
        public DateTime? SaunaStop { get; set; }


        public string TaloSauna { get; set; }

        public DateTime? Ticks { get; set; }

        [Display(Name = "Aika")]
        public DateTime Time { get; set; }

       
        public string Aika { get; set; }


        public bool Switched { get; set; }
        public void SaunaOn(int tila)
        {
            if (tila == 0)
            {
                Switched = false;
            }
            else
            {
                Switched = true;
            }
        }
    }
}
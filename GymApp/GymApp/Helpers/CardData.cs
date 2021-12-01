using GymApp.Helpers;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GymAppV2.Helpers
{
    public class CardData : List<Card>
    {
        public CardData()
        {

            //GymApp.Models.Membresias.MembresiaRequest item = new GymApp.Models.Membresias.MembresiaRequest()
            //{
            //    personaID = Settings.PersonaID.ToString()
            //};

            //List< GymApp.Models.Membresias.MembresiaContent> response = GymApp.Functions.Services.ConsultarMembresia(item);

            //if (response.Count > 0)
            //{
            //    foreach (var res in response)
            //    {
            //        var tiempoLim = res.fechaLimite;
            //        DateTime hoy = DateTime.Now;

            //        var daysleft = tiempoLim.Day - hoy.Day;

            //        Add(
            //        new Card()
            //        {
            //            Status = CardStatus.Completed,
            //            Description = "Número de clases disponibles: " + res.numClasesDisponibles.ToString(),
            //            DueDate = res.fechaLimite,
            //            StatusMessage = "Dias restantes: " + daysleft.ToString(),
            //            StatusMessageFileSource = StyleKit.Icons.Alert,
            //            ActionMessage = "Details",
            //            ActionMessageFileSource = StyleKit.Icons.Resume,
            //            Title = new FormattedString()
            //            {
            //                Spans =
            //                {
            //                    new Span ()
            //                    {
            //                        Text = res.nombreMembresia + ", "
            //                    },
            //                    new Span ()
            //                    {
            //                        Text = res.nombreDisciplina,
            //                        FontAttributes = FontAttributes.Bold
            //                    }
            //                }
            //            }
            //        }
            //    );
            //    }
                
            //}
        }
    }
}
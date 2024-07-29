using AmonicManagerApp.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmonicManagerApp.Modules
{
    public class PrintTicket
    {
        public PrintTicket(int IdTicket)
        {
            
            Document document = new Document();
            BaseFont baseFont = BaseFont.CreateFont("UI\\fonts\\Montserrat-Black.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont base1 = BaseFont.CreateFont("UI\\fonts\\Montserrat-SemiBold.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont base2 = BaseFont.CreateFont("UI\\fonts\\Montserrat-Medium.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 35f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 14f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font font2 = new iTextSharp.text.Font(base2, 14f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font font3 = new iTextSharp.text.Font(base1, 16f, iTextSharp.text.Font.NORMAL);
            String time = DateTime.Now.ToString("dd.MM.yyyy HH.mm");
            using (FileStream stream = new FileStream(@"Ticket(" + time + ").pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(document, stream); 
                document.Open();
                String phrase = "Билет от " + DateTime.Now.ToString("dd.MM.yyyy HH.mm");
                Ticket ticket = Model.GetContext().Tickets.FirstOrDefault(p => p.Id == IdTicket);
                User user = Model.GetContext().Tickets.FirstOrDefault(p => p.User.Id == ticket.UserId).User;
                document.Add(new iTextSharp.text.Paragraph(phrase, font1));
                document.Add(new iTextSharp.text.Paragraph("Данные клиента", font3));
                document.Add(new iTextSharp.text.Paragraph(user.Surname+" "+ user.Name+" "+ user.Patronymic, font2));
                document.Add(new iTextSharp.text.Paragraph(user.Login, font2));
                document.Add(new iTextSharp.text.Paragraph(user.Telephone, font2));
                document.Add(new iTextSharp.text.Paragraph("Данные рейса", font3));
                document.Add(new iTextSharp.text.Paragraph("Номер рейса: "+ ticket.Pricing.Flying.FlyingNumber, font2));
                document.Add(new iTextSharp.text.Paragraph(ticket.Pricing.Flying.way, font2));
                document.Add(new iTextSharp.text.Paragraph("Вылет:", font2));
                document.Add(new iTextSharp.text.Paragraph(ticket.Pricing.Flying.Direction.TerminalDeparture.Airport.Country+", "+ ticket.Pricing.Flying.Direction.TerminalDeparture.Airport.City+" "+ ticket.Pricing.Flying.Direction.TerminalDeparture.Airport.Code +" "+ ticket.Pricing.Flying.DateTimeDepartureString, font2));
                document.Add(new iTextSharp.text.Paragraph("Прибытие:", font2));
                document.Add(new iTextSharp.text.Paragraph(ticket.Pricing.Flying.Direction.TerminalArrival.Airport.Country+", "+ ticket.Pricing.Flying.Direction.TerminalArrival.Airport.City+" "+ ticket.Pricing.Flying.Direction.TerminalArrival.Airport.Code +" "+ ticket.Pricing.Flying.DateTimeArrivalString, font2));
                document.Add(new iTextSharp.text.Paragraph("Самолет: "+ticket.Pricing.Flying.Plane.Name, font2));
                document.Add(new iTextSharp.text.Paragraph("Номер места: " + ticket.NumberPlace, font2));
                document.Add(new iTextSharp.text.Paragraph(ticket.Pricing.Class, font2));
                document.Add(new iTextSharp.text.Paragraph("Стоимость: "+ticket.Pricing.Price+ "₽", font2));
                
                document.Close();
                Process.Start(@"Ticket(" + time + ").pdf");
            }
        }
    }
}

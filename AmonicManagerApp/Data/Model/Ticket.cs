namespace AmonicManagerApp.Data
{
    using AmonicManagerApp.Modules;
    using AmonicManagerApp.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows;

    public partial class Ticket
    {
        public int Id { get; set; }

        public int PricingId { get; set; }
        public string NumberPlace { get; set; }

        public int UserId { get; set; }

        public DateTime DateSale { get; set; }

        public virtual Pricing Pricing { get; set; }

        public virtual User User { get; set; }

        private RelayCommand openPricing;
        public RelayCommand PricingCommand
        {
            get
            {
                return openPricing ?? new RelayCommand(obj => {
                    StartViewModel.ViewModel.CurrentPage = new UI.Pages.Users.AddEdit.AddPricingPage();
                });
            }
        }

        private RelayCommand addItem;
        public RelayCommand AddItem
        {
            get
            {
                return addItem ?? new RelayCommand(obj =>
                {
                    try
                    {
                        Ticket ticket = obj as Ticket;
                        ticket.UserId = StartViewModel.ViewModel.SelectedUser.Id;
                        ticket.DateSale = DateTime.Now;
                        Model.GetContext().Tickets.Add(ticket);
                        Model.GetContext().SaveChanges();
                        MessageBox.Show("Билет создан");
                        PrintTicket print = new PrintTicket(Model.GetContext().Tickets.Where(p => p.UserId == UserId).OrderByDescending(p => p.Id).FirstOrDefault().Id);
                        StartViewModel.ViewModel.CurrentPage = new UI.Pages.Users.AddEdit.AddEditUserPage();
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Ошибка");
                    }
                });
            }
        }
    }
}

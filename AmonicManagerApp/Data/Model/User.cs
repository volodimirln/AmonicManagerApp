namespace AmonicManagerApp.Data
{
    using AmonicManagerApp.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Text;
    using System.Windows;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Passwords = new HashSet<Password>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Surname { get; set; }

        [Required]
        [StringLength(150)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(150)]
        public string Login { get; set; }
        [Required]
        [StringLength(5)]
        public string PassportId { set; get; }
        [Required]
        [StringLength(15)]
        public string PassportNumber { set; get; }

        [Required]
        [StringLength(15)]
        public string Telephone { get; set; }

        public int RoleId { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime? ChangeDate { get; set; }

        public int CountryId { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Password> Passwords { get; set; }

        public virtual Role Role { get; set; }
        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string PasswordRepeat { get; set; }

        [NotMapped]
        public IList<Country> Countries { get { return Model.GetContext().Countries.ToList(); } }
        public static string CreateMD5(string s)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }

        }
        private RelayCommand openAddTicket;
        public RelayCommand AddTicket
        {
            get
            {
                return openAddTicket ?? new RelayCommand(obj => {
                    StartViewModel.ViewModel.CurrentPage = new UI.Pages.Users.AddEdit.AddTicketPage();
                });
            }
        }
        private RelayCommand editItem;
        public RelayCommand EditItem
        {
            get
            {
                return editItem ?? new RelayCommand(obj => {
                    User item = (User)obj;
                    if (!string.IsNullOrEmpty(item.Name) && !string.IsNullOrEmpty(item.Surname)
                    && !string.IsNullOrEmpty(item.Telephone) && !string.IsNullOrEmpty(item.Patronymic)
                    && !string.IsNullOrEmpty(item.AddDate.ToString()))
                    {
                        
                            if (!string.IsNullOrEmpty(Password))
                            {
                                if (Password == PasswordRepeat)
                                {
                                    Password password = new Password() { Active = true, AddDate = DateTime.Now, UserId = item.Id, HashPassword = CreateMD5("6ZhM60" + Password) };

                                   
                                    List<Password> pssw = Model.GetContext().Passwords.Where(p => p.UserId == item.Id).OrderByDescending(p => p.Id).ToList();
                                    Password passwordold = pssw.FirstOrDefault();


                                    passwordold.Active = false;
                                    Model.GetContext().Passwords.AddOrUpdate(passwordold);
                                    Model.GetContext().SaveChanges();
                                    Model.GetContext().Passwords.Add(password);
                                    Model.GetContext().SaveChanges();
                                    PasswordRepeat = "";
                                    Password = "";
                                }
                                else
                                {
                                    MessageBox.Show("Пароли не сходятся");
                                }

                            }
                            item.ChangeDate = DateTime.Now;
                        if (item.Id == 0)
                        {
                            item.AddDate = DateTime.Now;
                            item.RoleId = 2;
                        }
                            Model.GetContext().Users.AddOrUpdate((User)item);
                            Model.GetContext().SaveChanges();
                            MessageBox.Show("Сохранено");
                            //StartViewModel.ViewModel.CurrentPage = new UI.Pages.Settings.SettingsPage();
                        
                    }
                    else
                    {
                        MessageBox.Show("Не все поля заполнены");
                    }

                });
            }
        }
    }
}

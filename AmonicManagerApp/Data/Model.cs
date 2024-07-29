using AmonicManagerApp.UI.Windows;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows;

namespace AmonicManagerApp.Data
{
    [DbConfigurationType(typeof(MyDbConfig))]
    public partial class Model : DbContext
    {

        public Model() : base("AmonicBilling")
        {
        }

        private static Model _context;
        public static Model GetContext()
        {
            if (_context == null)
                _context = new Model();
            return _context;
        }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Flying> Flyings { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Pricing> Pricings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<TerminalsInDirection> TerminalsInDirections { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Terminals)
                .WithRequired(e => e.Airport)
                .HasForeignKey(e => e.AiroportId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Direction>()
                .HasMany(e => e.Flyings)
                .WithRequired(e => e.Direction)
                .HasForeignKey(e => e.DirectonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Direction>()
                .HasMany(e => e.TerminalsInDirections)
                .WithRequired(e => e.Direction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flying>()
                .HasMany(e => e.Pricings)
                .WithRequired(e => e.Flying)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Plane>()
                .HasMany(e => e.Flyings)
                .WithRequired(e => e.Plane)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pricing>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Pricing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Terminal>()
                .HasMany(e => e.TerminalsInDirections)
                .WithRequired(e => e.Terminal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Passwords)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<Country>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);
        }
    }
    public class MyDbConfig : DbConfiguration
    {
        private string path
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        private string connection = "";
        public bool CheckDBAsync()
        {
            string input = connection;

            string[] substrings = input.Split(';');

            string server = "";
            string user = "";
            string password = "";

            foreach (string substring in substrings)
            {
                string[] keyValue = substring.Split('=');

                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim();
                    string value = keyValue[1].Trim();

                    switch (key)
                    {
                        case "Server":
                            server = value;
                            break;
                        case "User":
                            user = value;
                            break;
                        case "Password":
                            password = value;
                            break;
                    }
                }
            }
            string conn = "";
            if (string.IsNullOrEmpty(user))
            {
                conn = "Data Source=" + server + ";Initial Catalog=ZolkapBillingDB;Integrated Security=True;Encrypt=False";
            }
            else
            {
                conn = $"data source={server};persist security info=True;user id={user};password={password};MultipleActiveResultSets=True;App=EntityFramework";
            }
            SqlConnection myConnection = new SqlConnection(
                    conn

                );
            {
                try
                {
                    myConnection.Open();
                    myConnection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
        public void ConnectionString()
        {
            using (FileStream fileStream = new FileStream(path + "\\client.config", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    connection = (reader.ReadToEnd());

                }
            }
        }

        public MyDbConfig()
        {
            if (File.Exists(path + "\\client.config"))
            {
                ConnectionString();

                if (CheckDBAsync())
                {
                    SqlConnectionFactory defaultFactory = new SqlConnectionFactory(connection);

                    this.SetDefaultConnectionFactory(defaultFactory);
                }
                else
                {
                    MessageBox.Show("Œ¯Ë·Í‡");
                    File.Delete(path + "\\client.config");
                    ConfigurationWindow window = new ConfigurationWindow();
                    Application.Current.Shutdown();
                }
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelss;
using Modelss.CustomerSp;
using Modelss.ViewModels;
using Modelss.ViewModels.OrderEditModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DatabaseContext
{
    public class CustomerDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<CustomerAddress> CustomerAddresss { get; set; }
        
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Shop> Shops { get; set; }
        //public DbSet<Order> Orders { get; set; }        
        //public DbSet<OrderDetail> OrderDetails { get; set; }

        //public DbQuery<vwOrderInfo> vwOrderInfos { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionStrion = "Data Source=DESKTOP-VKJ3JAQ\\SQLEXPRESS;Database=CustomerDB;Integrated Security=True";
            string connectionStrion = "Server=(local);Database=CustomerDB; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionStrion);
           // optionsBuilder.le
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Query<vwOrderInfo>().ToView("vw_OrderInfo");

            //modelBuilder.Query<SpOrderInfo>();
            //modelBuilder.Query<SpOrderInfoParamater>();
            ////for edit
            //modelBuilder.Query<spOrderID>();
            //modelBuilder.Query<spOrderIDWiseDetails>();

            modelBuilder.Query<Edit_forCustomer>();
            modelBuilder.Query<Edit_forCustomerAddress>();

            //modelBuilder.Entity<Customer>()
            //    .HasMany(j => j.CustomerAddresss)
            //    .WithOne()
            //   .OnDelete(DeleteBehavior.Cascade);
            //base.OnModelCreating(modelBuilder);
        }

       
        /*
       [Obsolete]
       public ICollection<SpOrderInfo> GetSpOrderInfos()
       {
           return this.Query<SpOrderInfo>().FromSql("Sp_OrderInfo").ToList();
       }
       [Obsolete]
       public ICollection<SpOrderInfoParamater> GetSpOrderInfos_paramater(string OrderNo,string CustomerName)
       {
           SqlParameter p1 = new SqlParameter();
           p1.ParameterName = "OrderNo";
           p1.DbType = DbType.String;
           p1.Value = OrderNo == null ? "" : OrderNo;

           SqlParameter p2 = new SqlParameter();
           p2.ParameterName = "CustomerName";
           p2.DbType = DbType.String;
           p2.Value = CustomerName == null ? "" : CustomerName;
           return this.Query<SpOrderInfoParamater>().FromSql("Sp_OrderInfo_withParamater @OrderNo,@CustomerName", p1,p2).ToList();
       }


       // for edit 
       [Obsolete]
       public ICollection<spOrderID> GetSpOrderID(int id)
       {
           SqlParameter p1 = new SqlParameter();
           p1.ParameterName = "OrderID";
           p1.DbType = DbType.Int32;
           p1.Value = id == null ? 0 : id;

           return this.Query<spOrderID>().FromSql("spOrderID @OrderID", p1).ToList();

       }
       [Obsolete]
       public ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id)
       {
           SqlParameter p1 = new SqlParameter();
           p1.ParameterName = "OrderID";
           p1.DbType = DbType.Int32;
           p1.Value = id == null ? 0 : id;

           return this.Query<spOrderIDWiseDetails>().FromSql("spOrderIDWiseDetails @OrderID", p1).ToList();
       }
       */


        [Obsolete]
        public ICollection<Edit_forCustomer> GetEdit_forCustomer(int id)
        {
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "Id";
            p1.DbType = DbType.Int32;
            p1.Value = id == null ? 0 : id;

            return this.Query<Edit_forCustomer>().FromSql("Edit_forCustomer_pro @Id", p1).ToList();

        }

        [Obsolete]
        public ICollection<Edit_forCustomerAddress> GetEdit_forCustomerAddress(int id)
        {
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "Id";
            p1.DbType = DbType.Int32;
            p1.Value = id == null ? 0 : id;

            return this.Query<Edit_forCustomerAddress>().FromSql("Edit_forCustomerAddress_pro @Id", p1).ToList();

        }

        [Obsolete]
        public int Insert_Countyr(string CountryName, Nullable<int> commandID)
        {
            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "Id";
            //p1.DbType = DbType.Int32;
            //p1.Value = iD == null ? 0 : iD;


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "CountryName";
            p2.DbType = DbType.String;
            p2.Value = CountryName == null ? "" : CountryName;

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "commandID";
            p3.DbType = DbType.Int32;
            p3.Value = commandID == null ? 0 : commandID;

            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "Result";
            //p1.DbType = DbType.Int32;
            //p1.Value = Result == null ? 0 : Result;
            var pTotalRecords = new SqlParameter();
            pTotalRecords.ParameterName = "@Result";// "@TotalRecords";
            pTotalRecords.Direction = ParameterDirection.Output;
            pTotalRecords.DbType = DbType.Int32;

            var query1 = Database.ExecuteSqlCommand("Insert_Countyr @CountryName,@CommandID,@Result OUTPUT", p2, p3,pTotalRecords);


            return query1;

            //  return this.Query<SpOrderInfoParamater>().FromSql("Sp_OrderInfo_withParamater @OrderNo,@CustomerName", p1, p2).ToList();



            //var iDParameter = iD.HasValue ?
            //    new ObjectParameter("ID", iD) :
            //    new ObjectParameter("ID", typeof(int));

            //var firstNameParameter = firstName != null ?
            //    new ObjectParameter("FirstName", firstName) :
            //    new ObjectParameter("FirstName", typeof(string));

            //var lastNameParameter = lastName != null ?
            //    new ObjectParameter("LastName", lastName) :
            //    new ObjectParameter("LastName", typeof(string));

            //var genderParameter = gender != null ?
            //    new ObjectParameter("Gender", gender) :
            //    new ObjectParameter("Gender", typeof(string));

            //var salaryParameter = salary.HasValue ?
            //    new ObjectParameter("Salary", salary) :
            //    new ObjectParameter("Salary", typeof(int));

            //var depTIDParameter = depTID.HasValue ?
            //    new ObjectParameter("DepTID", depTID) :
            //    new ObjectParameter("DepTID", typeof(int));

            //var commandIDParameter = commandID.HasValue ?
            //    new ObjectParameter("CommandID", commandID) :
            //    new ObjectParameter("CommandID", typeof(int));

            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EMPLOYEE_InsertUpateUser_prc", iDParameter, firstNameParameter, lastNameParameter, genderParameter, salaryParameter, depTIDParameter, commandIDParameter);
        }

        //@CustomerId nvarchar(500),
        //	@Customer_Address nvarchar(500),
        public int EditInsert_CustomerAddresss(Nullable<int> CustomerId, string Customer_Address, Nullable<int> commandID)
        {
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "CustomerId";
            p1.DbType = DbType.Int32;
            p1.Value = CustomerId == null ? 0 : CustomerId;


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "Customer_Address";
            p2.DbType = DbType.String;
            p2.Value = Customer_Address == null ? "" : Customer_Address;

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "commandID";
            p3.DbType = DbType.Int32;
            p3.Value = commandID == null ? 0 : commandID;

            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "Result";
            //p1.DbType = DbType.Int32;
            //p1.Value = Result == null ? 0 : Result;
            var pTotalRecords = new SqlParameter();
            pTotalRecords.ParameterName = "@Result";// "@TotalRecords";
            pTotalRecords.Direction = ParameterDirection.Output;
            pTotalRecords.DbType = DbType.Int32;

            var query1 = Database.ExecuteSqlCommand("EditInsert_CustomerAddresss @CustomerId,@Customer_Address, @CommandID,@Result OUTPUT", p1, p2, p3, pTotalRecords);

            return query1;

        }
        public int DeleteCustomerAddresssAfteredit(Nullable<int> CustomerId)
        {
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "CustomerId";
            p1.DbType = DbType.Int32;
            p1.Value = CustomerId == null ? 0 : CustomerId;
            var query1 = Database.ExecuteSqlCommand("DeleteCustomerAddresssAfteredit @CustomerId", p1);
            return query1;
        }

        }
    }

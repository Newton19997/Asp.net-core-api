using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class addspcountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.Sql(@"create procedure[Insert_Countyr]
                                    (
                                    @CountryName nvarchar(500),
                                    @CommandID int,
                                    @Result int output
                                    )
                                    as
                                    set @Result=0
                                    if @CommandID=1
                                    begin
                                    INSERT INTO [dbo].[Countrys]
                                    (
                                    CountryName
                                    )
                                    VALUES
                                    (
                                    @CountryName
                                    )
                                    set @Result=@@IDENTITY
                                    end"
                                            );


            migrationBuilder.Sql(@"create procedure[dbo].[EditInsert_CustomerAddresss]
                                    (
                                    @CustomerId nvarchar(500),
									@Customer_Address  nvarchar(500),
                                    @CommandID int,
                                    @Result int output
                                    )
                                    as
								--	declare @id int
                                    set @Result=0
                                    if @CommandID=1
                                    begin
                                    INSERT INTO [dbo].[CustomerAddresss]
                                    (
									CustomerId,
                                    Customer_Address
                                    )
                                    VALUES
                                    (
                                    @CustomerId ,
									@Customer_Address 
                                    )
                                   set @Result=@@IDENTITY
								   --select @id = max(id) from [Countrys];
								   --set @Result=@id;
                                    end"
                                           );
            migrationBuilder.Sql(@"create procedure[dbo].[Edit_forCustomerAddress_pro]
                                    (
                                    @Id int
                                    )
                                    as
                                    begin
                                    select 
                                    b.Id ,
                                    b.Customer_Address,
                                    CustomerId
                                    ,'' as Customer
                                    from  Customers a 
                                    join CustomerAddresss b on a.Id=b.CustomerId
                                    where a.Id=@Id 
                                    end"
                                          );

            migrationBuilder.Sql(@"create procedure[dbo].[Edit_forCustomer_pro]
                                (
                                @Id int
                                )
                                as
                                begin
                                select 
                                a.Id,
                                a.CustomerName,
                                a.FatherName,
                                a.MotherName,
                                a.MaritalStatus,
                                a.Image,
                                a.CountryId,
                                c.CountryName
                                 from  Customers a 
                                join Countrys c on c.Id=a.CountryId
                                where a.Id=@Id 
                                end"
                                        );




            migrationBuilder.Sql(@"create procedure[dbo].[DeleteCustomerAddresssAfteredit]
                                    (
                                    @CustomerId int
                                    )
                                    as
                                    begin
                                    DELETE FROM CustomerAddresss WHERE CustomerId = @CustomerId;
                                     end");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Edit_forCustomerAddress_CustomerId",
            //        table: "Edit_forCustomerAddress",
            //        column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop procedure if exists dbo.Insert_Countyr");
            migrationBuilder.Sql("drop procedure if exists dbo.EditInsert_CustomerAddresss");
            migrationBuilder.Sql("drop procedure if exists dbo.Edit_forCustomerAddress_pro");
            migrationBuilder.Sql("drop procedure if exists dbo.Edit_forCustomer_pro");
            migrationBuilder.Sql("drop procedure if exists dbo.DeleteCustomerAddresssAfteredit");


            //migrationBuilder.DropTable(
            //    name: "Edit_forCustomerAddress");
        }
    }
}

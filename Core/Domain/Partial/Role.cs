namespace Core.Domain;

public partial class Role
{
    public const string Admin = "Admin";
    public const string Client = "Client"; 
    public const string DeliveryMan = "DeliveryMan";
    public const string AdminOrClient = Admin + "," + Client;
    public const string AdminOrDeliveryMan = Admin + "," + DeliveryMan;
    public const string DeliveryManOrClient = Admin + "," + Client + "," + DeliveryMan;
}
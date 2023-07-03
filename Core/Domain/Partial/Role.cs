namespace Core.Domain;

public partial class Role
{
    public const string Admin = "Admin";
    private const string _client = "Client";
    private const string _deliveryMan = "DeliveryMan";
    public const string Client = Admin + "," + _client;
    public const string DeliveryMan = Admin + "," + _deliveryMan;
    public const string DeliveryManOrClient = Admin + "," + _client + "," + _deliveryMan;
}
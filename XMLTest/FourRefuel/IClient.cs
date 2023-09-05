namespace XMLTest.FourRefuel;

public interface IClient
{
    Task<IEnumerable<Invoice>> GetAllAsync();
}

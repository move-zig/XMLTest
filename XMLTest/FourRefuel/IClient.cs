namespace XMLTest.FourRefuel;

public interface IClient
{
    public Task<IEnumerable<Invoice>> GetAllAsync();
}

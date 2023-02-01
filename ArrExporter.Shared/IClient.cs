namespace ArrExporter.Shared
{
    public interface IClient
    {
        public Task<bool> PingAsync();

        public Task Render();
    }
}
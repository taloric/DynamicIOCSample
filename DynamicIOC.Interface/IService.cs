namespace DynamicIOC.Interface
{
    public interface IService
    {
        void OnLoad();
        void OnStart();
        void OnStop();
    }
}

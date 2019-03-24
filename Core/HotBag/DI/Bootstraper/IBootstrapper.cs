namespace HotBag.DI
{
    internal interface IBootstrapper
    {
        void Init();
        bool Build();
    }
}

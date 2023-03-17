namespace AssetBundles
{
    public interface ICommandHandle<in T>
    {
        void Handle(T cmd);
    }
}
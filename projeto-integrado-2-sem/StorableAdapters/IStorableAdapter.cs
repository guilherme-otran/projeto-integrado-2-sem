namespace projeto_integrado_2_sem
{
    public interface IStorableAdapter<T>
    {
        string DefineIdentifier(T storable);
        T FromSerializedToPublic(T stored);
    }
}

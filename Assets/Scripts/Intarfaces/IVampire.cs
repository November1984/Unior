public interface IVampire
{
    public Vampire Vampire { get; }
    public bool IsVampiring { get; }

    public void Vamp()
    {
        Vampire.Launch();
    }
}
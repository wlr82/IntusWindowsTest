namespace DAL.Entities.Contracts
{
    public interface IEntity<TIdentity> where TIdentity : IEquatable<TIdentity>
    {
        public TIdentity Id { get; set; }
    }
}

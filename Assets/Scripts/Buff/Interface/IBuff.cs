public interface IBuff
{
    void Apply(Player target);
    void Remove(Player target);
    BuffType GetBuffType();
}
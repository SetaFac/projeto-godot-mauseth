public interface Entity
{
    public string DisplayName{get;}
    public string Description{get;}

    public int MaxHealth{get; set;}
    public int Health{get; set;}
    public int MaxLife{get; set;}
    public int Life{get; set;}


    public void TakeDamage(int damage);
}
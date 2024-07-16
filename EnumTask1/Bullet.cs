using EnumTask1.Enums;

namespace EnumTask1;

public class Bullet
{
    private static int _id;
    public int Id { get; set; }
    public BulletType Type { get; set; }
    public Bullet(BulletType bulletType)
    {
        Id = ++_id;
        Type = bulletType;
    }
    public override string ToString()
    {
        return $"Bullet type: {Type}, Id: {Id}";
    }
}


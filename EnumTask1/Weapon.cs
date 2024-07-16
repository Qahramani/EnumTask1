using EnumTask1.Enums;

namespace EnumTask1;

public class Weapon
{
    private static int _id;
    public int Id { get; set; }
    public string Name { get; set; }
    public BulletType Type { get; }
    public int BulletLimit { get; set; }
    private Queue<Bullet> Bullets;


    public Weapon(BulletType bulletType, int bulletLimit, string name)
    {
        BulletLimit = bulletLimit;
        Type = bulletType;
        Id = ++_id;
        Bullets = new Queue<Bullet>();
        Name = name;
    }

    public void Fire()
    {
        if (Bullets.Count == 0)
        {
            throw new Exception("Weapon is empty");
        }
        else
        {
            Bullet nextBullet = Bullets.Dequeue();
            Console.WriteLine($"Bullet type: {nextBullet.Type}, Count: {Bullets.Count}");
            Console.WriteLine("BOOM");
        }
    }

    public void Fill()
    {
        while(Bullets.Count < BulletLimit)
        {
            Bullet bullet = new Bullet(Type);
            Bullets.Enqueue(bullet);
        }
        Console.WriteLine($"Weapon filled succeesfully, count: {Bullets.Count}");
    }
    public void PullTrigger()
    {
        if(Bullets.Count == 0)
        {
            throw new Exception("Weapon is empty");
        }
        else
        {
            Bullet nextbullet = Bullets.Peek();
            Console.WriteLine(nextbullet);
        }
    }
}

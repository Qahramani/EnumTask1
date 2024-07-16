using EnumTask1.Enums;
using System.ComponentModel.Design;

namespace EnumTask1;

public class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("--- Weapon creation ---");
        Console.Write("Weapon name: ");
        string name = Console.ReadLine();

    weaponType:
        Console.Write("Choose bullet type:\n" +
            "1.Hunting\n" +
            "2.Plated\n" +
            "3.Lead\n" +
            "4.Rifle\n" +
            ">>>");
        string option = Console.ReadLine();
        BulletType choosenBullet;
        switch (option)
        {
            case "1":
                choosenBullet = BulletType.Hunting;
                break;
            case "2":
                choosenBullet = BulletType.Plated;
                break;
            case "3":
                choosenBullet = BulletType.Lead;
                break;
            case "4":
                choosenBullet = BulletType.Rifle;
                break;
            default:
                Console.WriteLine("Invalid input");
                goto weaponType;
        }
    bulletLimit:
        Console.Write("Bullet limit: ");
        int limit;
        bool isCorrect = int.TryParse(Console.ReadLine(), out limit);
        if (!isCorrect || limit < 0)
        {
            Console.WriteLine("Invalid input for limit");
            goto bulletLimit;
        }

        Weapon weapon = new Weapon(choosenBullet, limit, name);

        Console.WriteLine($"Weapon {weapon.Name} is created");

        MenuCommand:
        Console.WriteLine("-----  Menu -----");
        Console.Write("[1] Fill Weapon\n" +
            "[2] Fire\n" +
            "[3] PullTrigger\n" +
            "[0] exit\n" +
            ">>");
        option = Console.ReadLine();
        try
        {
            switch (option)
            {
                case "1":
                    weapon.Fill();
                    goto MenuCommand;
                case "2":
                    weapon.Fire();
                    goto MenuCommand;
                case "3":
                    weapon.PullTrigger();
                    goto MenuCommand;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    goto MenuCommand;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            goto MenuCommand;
        }
    }
}

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client.Run();
        }
    }

    public class FireWizard : Wizard
    {
        public override void DoMagic()
        {
            Console.WriteLine("Do Fire Magic");
        }
    }

    public class WaterWizard : Wizard
    {
        public override void DoMagic()
        {
            Console.WriteLine("Do Water Magic");
        }
    }

    public class FireGoblin : Goblin
    {
        public override void DoDamage()
        {
            Console.WriteLine("Do Fire Damage");
        }
    }

    public class WaterGoblin : Goblin
    {
        public override void DoDamage()
        {
            Console.WriteLine("Do Water Damage");
        }
    }

    public class GameManager
    {
        public void PlayWaterLevel()
        {
            WaterGoblin waterGoblin = new WaterGoblin();
            WaterWizard waterWizard = new WaterWizard();
            waterGoblin.DoDamage();
            waterWizard.DoMagic();
        }

        public void PlayFireLevel()
        {
            FireGoblin fireGoblin = new FireGoblin();
            FireWizard fireWizard = new FireWizard();
            fireGoblin.DoDamage();
            fireWizard.DoMagic();
        }

        public void Play(PlayerTypeFactory playerTypeFactory)
        {
            playerTypeFactory.CreateWizard();
            playerTypeFactory.CreateGoblin();
        }
    }

    public class Client
    {
        public static void Run()
        {
            GameManager manager = new GameManager();
            manager.PlayFireLevel();
            GameManager manager2 = new GameManager();
            manager2.PlayWaterLevel();
            
            PlayerTypeFactory player = new FireFactory();
            PlayerTypeFactory player008 = new WaterFactory();
            player008.CreateGoblin().DoDamage();

            manager.Play(player);
        }
    }

    public abstract class Wizard
    {
        public abstract void DoMagic();
    }
    public abstract class Goblin
    {
        public abstract void DoDamage();

    }

    public abstract class PlayerTypeFactory
    {
        public abstract Wizard CreateWizard();
        public abstract Goblin CreateGoblin();
    }

    public  class FireFactory : PlayerTypeFactory
    {
        public override Wizard CreateWizard()
        {
            return new FireWizard();
        }
        public override Goblin CreateGoblin()
        {
            return new FireGoblin();
        }
    }
    public  class WaterFactory : PlayerTypeFactory
    {
        public override Wizard CreateWizard()
        {
            return new WaterWizard();
        }
        public override Goblin CreateGoblin()
        {
            return new WaterGoblin();
        }
    }
}

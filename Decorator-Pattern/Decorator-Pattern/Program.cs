using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /* espresso origin price */
            Beverage beverage = new Espresso();
            Console.WriteLine(beverage.getDescription() + " $" + beverage.cost());

            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Soy(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine(beverage2.getDescription() + " $" + beverage2.cost());

            Beverage beverage3 = new HouseBlend();
            beverage3 = new Soy(beverage3);
            beverage3 = new Mocha(beverage3);
            beverage3 = new Whip(beverage3);
            Console.WriteLine(beverage3.getDescription() + " $" + beverage3.cost());

            Console.ReadKey();
        }
    }

    public abstract class Beverage
    {
        protected string description = "Unknow Beverage";

        public virtual string getDescription()
        {
            return this.description;
        }

        public abstract double cost();
    }

    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage beverage;
        public override string getDescription()
        {
            return this.beverage.getDescription() + ", " + this.description;
        }
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }

        public override double cost()
        {
            return 1.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "House Blend Coffee";
        }

        public override double cost()
        {
            return .89;
        }
    }

    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            description = "Dark Roast Coffee";
        }

        public override double cost()
        {
            return .99;
        }
    }

    public class Decaf : Beverage
    {
        public Decaf()
        {
            description = "Decaf Coffee";
        }

        public override double cost()
        {
            return 1.05;
        }
    }

    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
            this.description = "Mocha";
        }

        public override double cost()
        {
            return beverage.cost() + .20;
        }
    }

    public class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
            this.description = "Soy";
        }

        public override double cost()
        {
            return beverage.cost() + .15;
        }
    }

    public class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
            this.description = "Whip";
        }

        public override double cost()
        {
            return beverage.cost() + .10;
        }
    }
}

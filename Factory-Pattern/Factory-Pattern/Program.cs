using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyStore.orderPizza("cheese");
            Console.WriteLine("Ethan ordered a " + pizza.getName());

            pizza = chicagoStore.orderPizza("cheese");
            Console.WriteLine("Joel ordered a " + pizza.getName());

            Console.ReadKey();
        }
    }

    public abstract class PizzaStore
    {
        public Pizza orderPizza(string type)
        {
            Pizza pizza;

            pizza = createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }

        protected abstract Pizza createPizza(string type);
    }

    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza createPizza(string type)
        {
            switch (type)
            {
                case "cheese":
                    return new NYStyleCheesePizza();
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza createPizza(string type)
        {
            switch (type)
            {
                case "cheese":
                    return new ChicagoStyleCheesePizza();
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public abstract class Pizza
    {
        protected string name;
        protected string dough;
        protected string sauce;
        protected List<string> toppings = new List<string>();

        public virtual void prepare()
        {
            Console.WriteLine("Preparing " + name);
            Console.WriteLine("Tossing dough ...");
            Console.WriteLine("Adding sauce ...");
            Console.WriteLine("Adding topping: ");
            foreach (string topping in toppings)
            {
                Console.WriteLine("    " + topping);
            }
        }

        public virtual void bake()
        {
            Console.WriteLine("Bake for 25 mins at 350");
        }

        public virtual void cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public virtual void box()
        {
            Console.WriteLine("Place pizza in official PizzaStroe box");
        }

        public string getName()
        {
            return name;
        }
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            name = "NY Style Sauce and Cheese Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";

            toppings.Add("Sharedded Mozzarella Cheese");
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            name = "Chicago Style Deep Dish Cheese Pizza";
            dough = "Extra Thick Crust Dough";
            sauce = "Plum Tomato Sauce";

            toppings.Add("Sharedded Mozzarella Cheese");
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }
}

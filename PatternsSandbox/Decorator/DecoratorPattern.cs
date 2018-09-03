namespace PatternsSandbox.Decorator
{
    class DecoratorPattern
    {
        public abstract class BaseCake
        {
            public BaseCake(string name)
            {
                Name = name;
            }

            public string Name { get; private set; }
            public abstract int GetPrice();
        }

        public class ChocolateCake : BaseCake
        {
            public ChocolateCake() : base("ChocolateCake")
            {
            }

            public override int GetPrice()
            {
                return 200;
            }
        }

        public class PragueCake : BaseCake
        {
            public PragueCake(string name) : base("PragueCake")
            {
            }

            public override int GetPrice()
            {
                return 230;
            }
        }

        public abstract class BaseCakeDecorator
        {
        }

        public class Cherry

    }
}

namespace HabiticaPetFeeder.Logic.Model
{
    public abstract class Quantity
    {
        /// <summary>
        /// Represents the number of units available, after adjustment.
        /// </summary>
        public abstract int Value { get; }

        /// <summary>
        /// Represents the fixed number of units to be adjusted against.
        /// This would be the number of FedPoints for a pet or the quantity of food for a food.
        /// </summary>
        protected int InitialQuantity { get; init; }

        /// <summary>
        /// Represents changes to the fixed quantity over the lifetime of the object.
        /// As a pet is fed or as a food is consumed, this will increase and decrease.
        /// </summary>
        protected int Adjustment { get; private set; }

        protected Quantity(int inital)
        {
            InitialQuantity = inital;
            Adjustment = 0;
        }

        public void Adjust(int value) => Adjustment += value;
    }

    /// <summary>
    /// Increasing quantity which starts from 0, and is incremented.
    /// Fed Points are an increasing quantity.  They start from zero and go up to 50.
    /// e.g. A pet which had 10 fed points and was adjusted by another 10 is actually fed 20 points.
    /// </summary>
    public class IncreasingQuantity : Quantity
    {
        public override int Value => InitialQuantity + Adjustment;

        public IncreasingQuantity(int inital) : base(inital) { }
    }

    /// <summary>
    /// Decreasing quantity which starts from the fixed quantity, and is decremented.
    /// Food Quantity is a decreasing quantity.  They are consumed on allocation down to zero.
    /// e.g. A food which had 15 quantity and was adjusted by 10 has only 5 quantity.
    /// </summary>
    public class DecreasingQuantity : Quantity
    {
        public override int Value => InitialQuantity - Adjustment;

        public DecreasingQuantity(int inital) : base(inital) { }
    }
}

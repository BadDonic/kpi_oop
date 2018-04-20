using System;

namespace lab9
{
/*                    Task№ 1
За допомогою шаблона проектування забезпечити підтримку 
проведення розрахунків у ресторані з використанням клієнтської
картки клієнту надається знижка відповідно 5%, 10% та 15%. Сума,
сплачена за замовлення, додається до суми балансу картки. При
перевищенні даною сумою значення 5000 грн., картка з 5% стає 10%
При перевищенні 10000грн. – 15%.
*/
    class ClientCard
    {
        private double _sum;
        private IDiscountState _state;

        public ClientCard(IDiscountState state = null)
        {
            _state = state ?? new FivePercentDiscountState();
            _sum = State.StartSum();
        }

        public void Pay(double sum)
        {
            double paidSum = sum - _state.Discount(sum);
            _sum += paidSum;
            Console.WriteLine($"Client paid: {paidSum}");
            Console.WriteLine($"Paid for all time: {Sum}");
            State = State.NextState(Sum);
        }

        public double Sum => _sum;

        public IDiscountState State
        {
            get => _state;
            set => _state = value;
        }
    }

    interface IDiscountState
    {
        double Discount(double sum);
        double StartSum();
        IDiscountState NextState(double sum);
    }

    class FivePercentDiscountState : IDiscountState
    {
        public FivePercentDiscountState()
        {
            Console.WriteLine("New State - (5%)");
        }

        public double Discount(double sum)
        {
            double discount = sum * 0.05;
            Console.WriteLine($"5-% Discount: {discount}");
            return discount;
        }

        public double StartSum()
        {
            return 0;
        }

        public IDiscountState NextState(double sum)
        {
            return (sum >= 5000 && sum < 10000) ? new TenPercentDiscountState() :
                (sum >= 10000) ? (IDiscountState) new FifteenPercentDiscountState() : this;
        }
    }

    class TenPercentDiscountState : IDiscountState
    {
        public TenPercentDiscountState()
        {
            Console.WriteLine("New State - (10%)");
        }

        public double Discount(double sum)
        {
            double discount = sum * 0.1;
            Console.WriteLine($"10-% Discount: {discount}");
            return discount;
        }

        public double StartSum()
        {
            return 5000;
        }

        public IDiscountState NextState(double sum)
        {
            return (sum >= 10000) ? new TenPercentDiscountState() : this;
        }
    }

    class FifteenPercentDiscountState : IDiscountState
    {
        public FifteenPercentDiscountState()
        {
            Console.WriteLine("New State - (15%)");
        }

        public double Discount(double sum)
        {
            double discount = sum * 0.15;
            Console.WriteLine($"15-% Discount: {discount}");
            return discount;
        }

        public double StartSum()
        {
            return 15000;
        }

        public IDiscountState NextState(double sum)
        {
            return this;
        }
    }
}
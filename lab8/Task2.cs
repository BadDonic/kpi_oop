namespace lab8
{
    public enum TicketType
    {
        Entrance, Default, VIP
    }
    public enum FactoryType
    {
        State, Commercial
    }
    abstract class Ticket
    {
        protected Ticket(TicketType type, int colors, FactoryType factoryType)
        {
            Colors = colors;
            Type = type;
            FactoryType = factoryType;
        }
        public int Colors { get; set; }
        public TicketType Type { get; set; }
        public FactoryType FactoryType { get; set; }
        public override string ToString()
        {
            return $"Ticket - Type= {Type} NumColors = {Colors} Factory = {FactoryType}";
        }

        public abstract int CountPrice();
    }

    class EntranceTicket : Ticket
    {
        public EntranceTicket(int colors, FactoryType factoryType) : base(TicketType.Entrance, colors, factoryType) {}
        public override int CountPrice()
        {
            return Colors * 50 + 20;
        }
    }
    class DefaultTicket : Ticket
    {
        public  DefaultTicket(int colors, FactoryType factoryType) : base(TicketType.Default, colors, factoryType) {}
        public override int CountPrice()
        {
            return Colors * 50 + 70;
        }
    }
    
    class VIPTicket : Ticket
    {
        public  VIPTicket(int colors, FactoryType factoryType) : base(TicketType.VIP, colors, factoryType) {}
        public override int CountPrice()
        {
            return Colors * 50 + 200;
        }
    }
    
    abstract class TicketFactory
    {
        protected int colors;
        public abstract Ticket CreateTicket(TicketType type);
    }

    class StateFactory : TicketFactory
    {
        public StateFactory()
        {
            colors = 5;
        }
        public override Ticket CreateTicket(TicketType type)
        {
            Ticket ticket = null;
            switch (type)
            {
                case TicketType.Entrance:
                    ticket = new EntranceTicket(colors, FactoryType.Commercial);
                    break;
             
                case TicketType.Default:
                    ticket = new DefaultTicket(colors + 5, FactoryType.Commercial);
                    break;
                 
                case TicketType.VIP:
                    ticket = new VIPTicket(colors + 10, FactoryType.Commercial);
                    break;
            }
            return ticket;
        }
    }
    
    class CommertcialFactory : TicketFactory
    {
        public CommertcialFactory()
        {
            colors = 20;
        }
        public override Ticket CreateTicket(TicketType type)
        {
            Ticket ticket = null;
            switch (type)
            {
                case TicketType.Entrance:
                    ticket = new EntranceTicket(colors, FactoryType.Commercial);
                    break;
             
                case TicketType.Default:
                    ticket = new DefaultTicket(colors + 5, FactoryType.Commercial);
                    break;
                 
                case TicketType.VIP:
                    ticket = new VIPTicket(colors + 10, FactoryType.Commercial);
                    break;
            }
            return ticket;
        }
    }

    class Manager
    {
        public string Name { get; set; }

        public Manager(string name)
        {
            Name = name;
        }

        public Ticket OrderTicket(TicketType type, int money)
        {
            TicketFactory factory;
            if (money < 1000)
                factory = new StateFactory();
            else factory = new CommertcialFactory();
            return factory.CreateTicket(type);
        }
    }
}
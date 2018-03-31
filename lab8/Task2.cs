namespace lab8
{
    public enum TicketType
    {
        Entrance, Default, VIP
    }
    abstract class Ticket
    {
        protected Ticket(TicketType type, int colors)
        {
            Colors = colors;
            Type = type;
        }
        public int Colors { get; set; }
        public TicketType Type { get; set; }
        public override string ToString()
        {
            return $"Ticket - Type={Type} NumColors ={Colors}";
        }

        public abstract int CountPrice();
    }

    class EntranceTicket : Ticket
    {
        public EntranceTicket(int colors) : base(TicketType.Entrance, colors) {}
        public override int CountPrice()
        {
            return Colors * 50 + 20;
        }
    }
    class DefaultTicket : Ticket
    {
        public  DefaultTicket(int colors) : base(TicketType.Default, colors) {}
        public override int CountPrice()
        {
            return Colors * 50 + 70;
        }
    }
    
    class VIPTicket : Ticket
    {
        public  VIPTicket(int colors) : base(TicketType.VIP, colors) {}
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
        StateFactory()
        {
            colors = 5;
        }
        public override Ticket CreateTicket(TicketType type)
        {
            Ticket ticket = null;
            switch (type)
            {
                case TicketType.Entrance:
                    ticket = new EntranceTicket(colors);
                    break;
             
                case TicketType.Default:
                    ticket = new DefaultTicket(colors + 5);
                    break;
                 
                case TicketType.VIP:
                    ticket = new VIPTicket(colors + 10);
                    break;
            }
            return ticket;
        }
    }
    
    class CommertcialFactory : TicketFactory
    {
        CommertcialFactory()
        {
            colors = 20;
        }
        public override Ticket CreateTicket(TicketType type)
        {
            Ticket ticket = null;
            switch (type)
            {
                case TicketType.Entrance:
                    ticket = new EntranceTicket(colors);
                    break;
             
                case TicketType.Default:
                    ticket = new DefaultTicket(colors + 5);
                    break;
                 
                case TicketType.VIP:
                    ticket = new VIPTicket(colors + 10);
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
            //TODO
            return null;
        }
    }
}
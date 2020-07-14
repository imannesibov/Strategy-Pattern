using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern
{
    interface IRouteStrategy
    {
        void BuildRoute();
    }

    class RoadStrategy : IRouteStrategy
    {
        public void BuildRoute()
        {
            Console.WriteLine("RoadStrategy");
        }
    }

    class PublicTransportStrategy : IRouteStrategy
    {
        public void BuildRoute()
        {
            Console.WriteLine("PublicTransportStrategy");
        }
    }

    class WalkingStrategy : IRouteStrategy
    {
        public void BuildRoute()
        {
            Console.WriteLine("WalkingStrategy");
        }
    }

    class RouteContext
    {
        public IRouteStrategy RouteStrategy  { get; private set; }

        public RouteContext(IRouteStrategy routeStrategy)
        {
            this.RouteStrategy = routeStrategy;
        }

        public void SetStrategy(IRouteStrategy routeStrategy)
        {
            this.RouteStrategy = routeStrategy;
        }

        public void Execute()
        {
            RouteStrategy.BuildRoute();
        }
    }

    class Client
    {
        private RouteContext routeContext;

        public void SetRouteStrategy(IRouteStrategy routeStrategy)
        {

            routeContext = new RouteContext(routeStrategy);
        }

        public void Run()
        {
            if (routeContext.RouteStrategy != null)
            {
                routeContext.Execute();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();

            client.SetRouteStrategy(new WalkingStrategy());
            client.Run();


            client.SetRouteStrategy(new RoadStrategy());
            client.Run();
        }
    }
}

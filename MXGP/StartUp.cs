namespace MXGP
{
    using System;

    using MXGP.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}

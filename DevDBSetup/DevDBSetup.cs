using System;
using HappyFL.DevDBSetup.RecipeManagement;
using HappyFL.DBFactory;

namespace HappyFL.DevDBSetup
{
    public class DevDBSetup
    {
        public static void Main(params string[] args)
        {
            var installer = new DevDBSetup();
            installer.InstallDevDataToHappyFL();
        }

        protected HappyFLDbContextFactory factory;

        public DevDBSetup()
        {
            factory = new HappyFLDbContextFactory();
        }

        public void InstallDevDataToHappyFL()
        {
            LogInfo("Setting up data in RecipeManagement schema");
            new RecipeManagementDataProvider().CreateData(factory);

            LogInfo("Completed");
        }

        protected void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {message}");
        }
    }
}

using System.Reflection;

namespace PuZhongMiniSystem {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private static Mutex mutex = null;

        [STAThread]
        static void Main() {
            const string appName = "PuZhongMiniSystem";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew) {
                //app is already running! Exiting the application
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
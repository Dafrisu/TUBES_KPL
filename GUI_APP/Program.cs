namespace GUI_APP
{
    internal static class Program
    {
        public static List<BarangUMKM> listUMKM = new List<BarangUMKM>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            BarangUMKM Darryl = new BarangUMKM("Darryl");
            Darryl.GenerateBarang1();

            BarangUMKM Dafa = new BarangUMKM("Dafa");
            Dafa.GenerateBarang2();
            listUMKM.Add(Darryl);
            listUMKM.Add(Dafa);
            ApplicationConfiguration.Initialize();
            Application.Run(new GUILogin());
        }
    }
}
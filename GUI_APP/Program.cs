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
            BarangUMKM Haikal = new BarangUMKM("Haikal");
            Haikal.GenerateBarang1();

            BarangUMKM Dafa = new BarangUMKM("Dafa");
            Dafa.GenerateBarang2();
            listUMKM.Add(Haikal);
            listUMKM.Add(Dafa);
            ApplicationConfiguration.Initialize();
            Application.Run(new GUIUMKM());
        }
    }
}
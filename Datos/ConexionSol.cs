namespace PAPELERIANGELESC.Datos
{
    public class ConexionSol
    {
        private string cadenaSQL = string.Empty;

        public ConexionSol()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }

    }
}

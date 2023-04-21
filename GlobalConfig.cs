namespace dotnetpost
{
    public class GlobalConfig
    {
        private static GlobalConfig? _instance;
        public static void init(string connectionString)
        {
            _instance = new GlobalConfig(connectionString);
        }
        public static GlobalConfig getInstanse()
        {
            if (_instance == null)
                throw new Exception("Global Configuration should be initialized in Program.cs");
            return _instance;
        }

        public string ConnectionString { get; }
        private GlobalConfig(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
﻿class ConfigurationManager
{
    private static ConfigurationManager instance;

    private string environmentParameterValue;
    private string loggingModesValue;
    private string databaseConnectionSettingsValue;

    public string EnvironmentParameterValue
    {
        get { return environmentParameterValue; }
        private set { environmentParameterValue = value; }
    }
    public string LoggingModesValue
    {
        get { return loggingModesValue; }
        private set { loggingModesValue = value; }
    }
    public string DatabaseConnectionSettingsValue
    {
        get { return databaseConnectionSettingsValue; }
        private set { databaseConnectionSettingsValue = value; }
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    private ConfigurationManager() { }


    public void ConfigurationsChangeChoose()
    {
        Console.WriteLine("Choose what you want to change: \n" +
                          "1. Environment Parameters\n" +
                          "2. Logging Modes\n" +
                          "3. Database Connection Settings\n");
        Console.Write("Choose: ");
        int choose = int.Parse(Console.ReadLine());
        ConfigurationChanger(choose);
    }

    public void ConfigurationChanger(int choose)
    {
        switch(choose)
        {
            case 1: 
                Console.WriteLine($"Current Environment Parameters: {EnvironmentParameterValue}\n" +
                                  $"Enter on what you want to change it:");
                EnvironmentParameterValue = Console.ReadLine();
                Console.WriteLine("Environment Parameters configuration has been changed.\n");
                break;
            case 2:
                Console.WriteLine($"Current Logging Modes: {LoggingModesValue}\n" +
                                  $"Enter on what you want to change it:");
                LoggingModesValue = Console.ReadLine();
                Console.WriteLine("Logging Modes configuration has been changed.\n");
                break;
            case 3:
                Console.WriteLine($"Current Database Connection Settings: {DatabaseConnectionSettingsValue}\n" +
                                  $"Enter on what you want to change it:");
                DatabaseConnectionSettingsValue = Console.ReadLine();
                Console.WriteLine("Database Connection Settings configuration has been changed.\n");
                break;
        }
    }

    public void ShowConfigurations()
    {
        Console.WriteLine($"Environment Parameters: {EnvironmentParameterValue}\n" +
                          $"Logging Modes: {LoggingModesValue}\n" +
                          $"Database Connection Settings: {DatabaseConnectionSettingsValue}\n");
    }

}
using TestConsoleApps.Apps;

namespace TestConsoleApps
{
  public static class ServiceFacade
  {
    public static void StartBinarySearchApp()
    {
        IApp iApp = new BinarySearchApp();
        iApp.Start();
    }

   
  }
}
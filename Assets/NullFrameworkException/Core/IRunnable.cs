namespace NullFrameworkException.Core
{
   public interface IRunnable 
   {
      bool Enabled { get; set; }

      void SetUp(params object[] _params);
      void Run(params object[] _params);
   }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NullFrameworkException
{
   public interface IRunnable 
   {
      bool Enabled { get; set; }

      void SetUp(params object[] _params);
      void Run(params object[] _params);
   }
}
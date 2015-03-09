using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Network.PSoft.BusinessObject
{
  public interface IURLParameters
  {
    string GetParametersString();
    Dictionary<string,string> GetParametersDict();
  }
}

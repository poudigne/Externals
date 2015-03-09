using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Network.PSoft.BusinessObject.Remoting
{
  public class RegisterInformations : IURLParameters
  {
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string passwordConfirm { get; set; }

    public RegisterInformations()
    {

    }

    public bool FieldHasValue()
    {
      return firstname != String.Empty &&
             lastname != string.Empty &&
             username != string.Empty &&
             email != string.Empty &&
             password != string.Empty &&
             passwordConfirm != string.Empty;
    }

    public bool IsPasswordValid()
    {
      return true;
    }
    public bool IsPasswordMath()
    {
      return password == passwordConfirm;
    }

    public override string ToString()
    {
      return String.Format("Firstname : {0}" +
                           "\nLastname : {1}" +
                           "\nUsername : {2}" +
                           "\nEmail : {3}" +
                           "\nPassword : {4}" +
                           "\nPassword confirme : {5}",
        firstname, lastname, username, email, password, passwordConfirm);
    }

    public string GetParametersString()
    {
      return String.Format("username={0}&" +
                           "first_name={1}&" +
                           "last_name={2}&" +
                           "password={3}&" +
                           "email={4}",
        username, firstname, lastname, password, email);
    }
  }
}

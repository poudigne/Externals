using System;
using System.Diagnostics;
using System.Windows.Forms;
using Network.PSoft.BusinessObject.Remoting;
using Network.PSoft.Network.Facade;

namespace Network._PSoft.Test.Network
{
  public partial class NetworkTest : Form
  {


    private RemotingFacade remotingService;

    public NetworkTest()
    {
      InitializeComponent();

      remotingService = new RemotingFacade("test");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var registerInformations = new RegisterInformations()
      {
        firstname = this.tbFirstName.Text,
        lastname = this.tbLastName.Text,
        username = this.tbUsername.Text,
        email = this.tbEmail.Text,
        password = this.tbPassword.Text,
        passwordConfirm = this.tbPassword.Text,
      };

      var Request = string.Empty;
      var Response = remotingService.SendRegisterAccountRequest(registerInformations);
      this.tbSentRequest.Text = Request;
      this.textBox1.Text += Response;
      
    }

  }
}

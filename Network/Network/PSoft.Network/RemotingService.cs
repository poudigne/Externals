using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Network.PSoft.Network
{
  public class RemotingService
  {
    private String gameName { get; set; }
    private static RemotingService instance;

    public RemotingService()
    {
    }
    public RemotingService(string name)
    {
      gameName = name;
    }

    public RemotingService GetInstance()
    {
      if (instance == null)
        instance = new RemotingService(string.Empty);
      return instance;
    }

    public string GetGameName()
    {
      return gameName;
    }

    public string SendRequestPost(string link, string parameters)
    {
      var data = Encoding.ASCII.GetBytes(parameters);

      var request = WebRequest.Create(link);
      // If required by the server, set the credentials.
      request.Credentials = CredentialCache.DefaultCredentials;
      request.Method = RequestMethod.POST.ToString();
      request.ContentType = "application/x-www-form-urlencoded";
      request.ContentLength = data.Length;
      
      using (var stream = request.GetRequestStream())
      {
        stream.Write(data, 0, data.Length);
      }

      var response = (HttpWebResponse)request.GetResponse();
      var dataStream = response.GetResponseStream();
      if (dataStream != null)
      {
        var reader = new StreamReader(dataStream);
        var responseFromServer = reader.ReadToEnd();
      
        reader.Close();
        dataStream.Close();
        response.Close();

        return responseFromServer;
      }
      return string.Empty;
    }

    public string SendRequestPost2(string link, Dictionary<string,string> parameters)
    {
      using (var wb = new WebClient())
      {
        var data = new NameValueCollection();
        var stringValue = string.Empty;
        foreach (var parameter in parameters)
        {
          data[parameter.Key] = parameter.Value;
        }

        var msg = String.Format("[{0}], Sending POST request, Link : {1}, Parameters: {2}", DateTime.Now, link, stringValue);
        Logging.LoggingService.LogDebug(msg);

        var response = wb.UploadValues(link, "POST", data);
        var s = wb.Encoding.GetString(response);
        return s;
      }
    }
  }



  public enum RequestMethod
  {
    POST,
    GET
  }

  public enum RequestAction
  {
    GetHighscore,
    Login,
    CreateUser
  }
}

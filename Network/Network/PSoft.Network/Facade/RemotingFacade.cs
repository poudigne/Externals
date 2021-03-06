﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Network.PSoft.BusinessObject;
using Network.PSoft.BusinessObject.Remoting;

namespace Network.PSoft.Network.Facade
{
  public class RemotingFacade
  {

    private RemotingService instance;

    private const String GET_LINK = "http://api.francoischolette.com/api/1.0/{0}?{1}";
    private const String POST_LINK_BYGAMES = "http://api.francoischolette.com/api/1.0/{0}/post/{1}";
    public const String POST_LINK = "http://api.francoischolette.com/api/1.0/{0}";


    public RemotingFacade(string gameName)
    {
      instance = new RemotingService(gameName);
    }

    public RemotingService GetInstance()
    {
      return instance ?? (instance = new RemotingService(string.Empty));
    }

    public string SendRegisterAccountRequest(IURLParameters registerInformations)
    {
      string link = BuildURL(registerInformations, RequestAction.CreateUser);
      // Write the string to a file.
      return instance.SendRequestPost(link, registerInformations.GetParametersString());
    }

    private string BuildURL(IURLParameters registerInformations, RequestAction action)
    {
      switch (action)
      {
        case RequestAction.GetHighscore:
          break;
        case RequestAction.Login:
          break;
        case RequestAction.CreateUser:
          return string.Format(POST_LINK, GetLinkActionString(action));
        default:
          return string.Empty;
      }
      return string.Empty;
    }

    private string GetLinkActionString(RequestAction action)
    {
      switch (action)
      {
        case RequestAction.GetHighscore:
          break;
        case RequestAction.Login:
          break;
        case RequestAction.CreateUser:
          return "users";
        default:
          return string.Empty;
      }
      return string.Empty;
    }
  }
}

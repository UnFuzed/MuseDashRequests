using System.Net.Http;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Models;

namespace MuseDashRequests;

public class TwitchAPI
{
    public static TwitchClient Load(string botUsername, string oauthToken, string channelName)
    {
        ConnectionCredentials credentials = new ConnectionCredentials(botUsername, oauthToken);
        TwitchClient twitchClient = new TwitchClient();
        twitchClient.Initialize(credentials, channelName);
        
        return twitchClient;
    }

    // public static void getOAuthToken(string clientId, string secretId) {

    //     System.Diagnostics.Process.Start($"https://id.twitch.tv/oauth2/authorize?client_id={clientId}&redirect_uri=http://localhost&response_type=code&scope=chat:read+chat:edit");

        
    // }

}

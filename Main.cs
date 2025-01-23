using TwitchLib.Client;
using TwitchLib.Client.Models;
using MelonLoader;
using UnityEngine;

namespace MuseDashRequests
{
    public class SongRequests : MelonMod
    {
        private static TwitchClient twitchClient = new TwitchClient();
        private readonly string botUsername = "MDRequests";
        private readonly string oauthToken =  Environment.GetEnvironmentVariable("TwitchAPIKey");
        private readonly string channelName = "unfuzed_";
        private string message;
        private string user;

        public override void OnInitializeMelon()
        {
            twitchClient = TwitchAPI.Load(botUsername, oauthToken, channelName);


            MelonEvents.OnGUI.Subscribe(DrawMenu, 100);

            // Subscribe to chat message events
            twitchClient.OnMessageReceived += (twitchMessage, e) =>
            {
                
                message = e.ChatMessage.Message;
                user = e.ChatMessage.DisplayName;

                MelonLogger.Msg($"Displaying message from {e.ChatMessage.DisplayName}: {e.ChatMessage.Message}");
            };

            twitchClient.OnConnected += (sender, e) =>
            {
                MelonLogger.Msg($"Connected to Twitch chat of {channelName} with {e.BotUsername}");
            };
            
            // Connect to Twitch chat
            twitchClient.Connect();

            base.OnInitializeMelon();
        }

        private void DrawMenu()
        {
            GUI.Label(new Rect(10, 10, 1000, 1000), $"<b><color=green><size=50>{user} sent {message}</size></color></b>");
            
        }

        public override void OnApplicationQuit()
        {
            if (twitchClient.IsConnected)
            {
                twitchClient.Disconnect();
            }

            base.OnApplicationQuit();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net.Http;
using Newtonsoft.Json;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin.Messaging;
//using Firebase_Android_Notifications.Entities;

namespace NitifApp
{
    class ClassNotif
    {
    }
}


//namespace Firebase_Android_Notifications.Entities
//{
//    internal class Message
//    {
//        public string[] registration_ids { get; set; }
//        public string condition { get; set; }
//        public Notification notification { get; set; }
//        public object data { get; set; }
//    }
//}

//namespace Firebase_Android_Notifications.Entities
//{
//    internal class Notification
//    {
//        public string title { get; set; }
//        public string body { get; set; }
//    }
//}

//namespace Firebase_Android_Notifications.Logics
//{
    public static class SendNotificationLogic
    {

        private static Uri FireBasePushNotificationsURL = new Uri("https://fcm.googleapis.com/fcm/send");
        private static string ServerKey = "AAAA6o0lLdY:APA91bGb_gqHOov_G0BlZOaRNMQZ8CaxFNniqFNr91_tLTSkcgOoODgxWuezL2vCVclHs6lh3OYZJpbOEIMLZuEwJLpirUH-0l2dHhztVypPIsVMbfb686yy9N3g9v0IR4xf7suiIJgg";


        public static Task<bool> SendPushNotificationToAll(string title, string body, object data)
        {
            //Object creation
            var messageInformation = new Message ()
            {
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                },
                Apns = new ApnsConfig()
                {
                    Aps = new Aps()
                    {
                        Alert = new ApsAlert()
                        {
                            Title = title,
                            Body = body

                        },
                        Badge = 1,
                        Sound = "alert"
                    }
                },
                Topic = "all",
                Condition = "'All' in topics" // Change the topics to add or remove devices.
            };

            //Object to JSON STRUCTURE => using Newtonsoft.Json;
            string jsonMessage = JsonConvert.SerializeObject(messageInformation);

            return HttpRequestFromJSON(jsonMessage);

        }


        //public static Task<bool> SendPushNotificationToSpecificDevices(string[] deviceTokens, string title, string body, object data)
        //{

        //    string jsonMessage = "";
        //    if (deviceTokens.Count() > 0)
        //    {
        //        //Object creation

        //        var messageInformation = new Message()
        //        {
        //            Notification = new Notification()
        //            {
        //                Title = title,
        //                Body = body
        //            },
        //            data = data,
        //            registration_ids = deviceTokens
        //        };

        //        //Object to JSON STRUCTURE => using Newtonsoft.Json;
        //        jsonMessage = JsonConvert.SerializeObject(messageInformation);

        //    }
        //    return HttpRequestFromJSON(jsonMessage);
        //}


        private static async Task<bool> HttpRequestFromJSON(string messageInformation)
        {
            bool sent =true;
            //Create request to Firebase API
            var request = new HttpRequestMessage(HttpMethod.Post, FireBasePushNotificationsURL);

            request.Headers.TryAddWithoutValidation("Authorization", "key=" + ServerKey);
            request.Content = new StringContent(messageInformation, Encoding.UTF8, "application/json");

            HttpResponseMessage result;
            using (var client = new HttpClient())
            {
                result = await client.SendAsync(request);
                sent = sent && result.IsSuccessStatusCode;
            }
            return sent;
        }
    }
//}

/*
public static Task<bool> SendPushNotificationToAll(string title, string body, object data)
{
    bool sent = false;

    Object creation

    var messageInformation = new Message()
    {
        notification = new Notification()
        {
            title = title,
            text = body
        },
        data = data,
        condition = "'All' in topics"
    };

    Object to JSON STRUCTURE => using Newtonsoft.Json;
    string jsonMessage = JsonConvert.SerializeObject(messageInformation);

    //Create request to Firebase API
    var request = new HttpRequestMessage(HttpMethod.Post, FireBasePushNotificationsURL);

    request.Headers.TryAddWithoutValidation("Authorization", "key=" + ServerKey);
    request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

    HttpResponseMessage result;
    using (var client = new HttpClient())
    {
        result = await client.SendAsync(request);
        sent = sent && result.IsSuccessStatusCode;
    }


    return HttpRequestFromJSON(jsonMessage);

}
*/

/*
             ------ JSON STRUCTURE ------
             {
                notification: {
                                title: "",
                                text: ""
                                },
                data: {
                        action: "Play",
                        playerId: 5
                        }, 
                condition = "'All' in topics"; 
                // OR 
                registration_ids = ["id1", "id2"] // 'Technology' in topics && 'Automotive' in topics.
             }
             ------ JSON STRUCTURE ------
             */

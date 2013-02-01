###HOptions 

HOptions are the options used by the hApi.

```c#
public class HOptions : JObject{
  public string GetTransport();
	public void SetTransport(string transport);

	public JArray GetEndpoints();
        public void SetEndpoints(JArray endpoints);

        public int GetTimeout();
        public void SetTimeout(int timeout);

        public int GetMsgTimeout();
        public void SetMsgTimeout(int timeout);
        
        public AuthenticationCallback AuthCb { get; set; }
}
```
 
 * transport : Transport to connect to the hNode. Only one value is available nowadays: "socketio"  _Default value: "socketio"_
 * endpoint : Endpoint of the hNode. Expects an array from which one will be chosen randomly to do client side load balancing. Used only if socket mode.
 * timeout : Default timeout value used by the hAPI before rise a connection timeout error during connection attempt. _default value is : 15000 ms_
 * msgTimeout : default timeout value used by the hAPI for all the services except the send() function. _default value is : 30000 ms_
 * authCB : If you want use an external script for authentification you can add it here. You just need to use the user as attribut and return a user and his password

Example: 
```c#
     options.AuthCb = new AuthenticationCallback(
                (username, Login) =>
                {
                    //your code
                    Login(username, password);
                }
                );

	client.connect(username, password, options);
```

###HMessageOptions

HMessageOptions are the options used by the HMessage.

```c#
public class HMessageOptions
{
        private string @ref = null;
        private string convid = null;
        private HMessagePriority? priority = null;
        private DateTime? relevance = null;
        private int? relevanceOffset = null;
        private bool? persistent = null;
        private HLocation location = null;
        private string author = null;
        private JObject headers = null;
        private DateTime? published = null;
        private int timeout = 0;
}
```
 * ref : The msgid of the message referred to
 * convid : The conversation id to use if the message should take place in a conversation
 * priority : priority of the message. If UNDEFINED, priority lower to 0. See [HMessagePrioity](https://github.com/hubiquitus/hubiquitus4w8/wiki/Codes-v-0.5)
 * relevance : specifies the end of relevance
 * persistent : indicate if the HMessage is persistent
 * location : the location of the HMessage. See [HLocation](https://github.com/hubiquitus/hubiquitus4w8/wiki/hAPI-Datamodel-v-0.5)
 * author : the author of the HMessage
 * headers : the headers of the HMessage. See [HHeader](https://github.com/hubiquitus/hubiquitus4w8/wiki/hAPI-Datamodel-v-0.5)
 * published : Allows the client to set a specific published date. If not specified the hServer will set the published date.
 * timeout : Time (in ms) to wait for a response before hAPI sends a timeout

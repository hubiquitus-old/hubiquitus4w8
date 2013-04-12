Implementation of the hubiquitusClient. It allow to connect to an hNode server and use basic functions (Publish, suscribe, etc ...)

### Connect

Starts a connection to hNode. Status will be received in the `onStatus` callback set by the user and real-time hMessages will be received through the `onMessage` callback. Each command executed has its own callback that receives a hMessage with hResult payload. 

```c#
public void Connect(string login, string password, HOptions options)
public void Connect(string login, string password, HOptions options, JObject context)
```
Where:

* login : login of the publisher (ie : user@domain)
* password : publisher's password
* hOptions : Complementary values used for the connection to the server [HOptions](https://github.com/hubiquitus/hubiquitus4w8/wiki/Options-v-0.5)
* context : optional, the user's context.

Note : if a technical disconnection is raised then the system will try to reconnect by itself automatically.

### Disconnect

Disconnect the user from the current working session.

```c#
public void Disconnect()
```

### onStatus

Set the delegate used to manage the hStatus structure sent by the hAPI when the status of the connection changed.

```c#
public event StatusEventHandler onStatus;
```
Where:
* StatusEventHandler: The delegate called on connection status update

```c#
public delegate void StatusEventHandler(HStatus status);
```
Where:
* status : new connection status.

### onMessage

Set the delegate used to manage the hMessage structure sent by the hAPI when a message is sent by the hServer to the client.

```c#
public event MessageEventHandler onMessage;
```
Where:
* MessageEventHandler : Delegate called on incoming messages

```c#
public delegate void MessageEventHandler(HMessage message);
```
Where:
* message : Received message


### Send

_The client MUST be connected_ 

The hAPI sends the hMessage to the hserver which transfer it to the specified actor
The hserver will perform one of the following actions :
* If the actor is a channel (ie : #channelName@domain) the hserver will perform a publish operation of the provided hMessage to the channel and send an hMessage with hResult payload containing the published message and cmd name set with hsend to acknowledge publishing
* If the actor is either ‘session’ and payload type is ‘hCommand’ the server will handle it. In other cases, it will send an hMessage with a hResult error NOT_AUTHORIZED.
* If the actor is a urn, hserver will relay the message to the relevant actor.

Nominal response :
* If callback provided, an hMessage referring to sent message (eg : ref = hAPI client  msgid of sent message).
* If a timeout is provided and message didn’t arrive before timeout, callback is called with hMessage with an hResult error of type EXEC_TIMEOUT
* If response is from the hAPI or hserver, response will be an hMessage with an hResult payload.

```c#
 public void Send(HMessage message, Action<HMessage> messageDelegate)
```
Where:
* message : the HMessage to send
* messageDelegate : Action that will be notify when response message is available

### Subscribe

_The client MUST be connected_ 

Demands the channel to subscribe.
The server will check if not already subscribed and if authorized subscribe him.

Nominal response : a hMessage with an hResult payload with no error.

```c#
public void Subscribe(string actor, Action<HMessage> messageDelegate)
```
Where:
* actor : The channel urn to subscribe to.(ie : "#test@domain")
* messageDelegate : Delegate that will be notify when command result is available. See send for HMessageDelegate structure


### Unsubscribe

_The client MUST be connected_

Demands the channel an unsubscription.
The hAPI checks the current publisher’s subscriptions and if he is subscribed, performs an unsubscribe.

Nominal response : an hMessage with an hResult where the status 0.

```c#
 public void Unsubscribe(string actor, Action<HMessage> messageDelegate)
```
Where:
* actor : The channel to unsubscribe from.
* messageDelegate : Delegate that will be notify when command result is available. See command for HMessageDelegate structure

### GetSubscriptions

_The client MUST be connected_

Demands the server a list of the publisher’s subscriptions.

Nominal response : a hMessage with a hResult payload contains an array of channel id which are all active.

```c#
public void GetSubscriptions(Action<HMessage> messageDelegate)
```
Where:
* messageDelegate : Delegate that will be notify when command result is available. See command for HMessageDelegate structure

### SetFilter

_The client MUST be connected_

Set a filter to be applied to upcoming messages at the session level 

```c#
public void SetFilter(HCondition filter, Action<HMessage> messageDelegate)
```

Where:
* filter : The filter to apply on the current session managed on the hnode side for this actor.
* messageDelegate : Delegate that will be notify when command result is available. See command for HMessageDelegate structure.



### Builders

For all the builders, if a mandatory field is missing, builders throw an exception :

```java
 public class MissingAttrException : Exception
 {
  public string AttrName(); //name of the missing atttribute
	public string GetMessage();
}
```


#### BuildMessage
Helper function to create a basic hMessage.

```c#
public HMessage BuildMessage(string actor, string type, JObject payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, JArray payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, string payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, bool payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, int payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, double payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, HAck payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, HAlert payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, HCommand payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, HConvState payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, HMeasure payload, HMessageOptions mOptions)
public HMessage BuildMessage(string actor, string type, HResult payload, HMessageOptions mOptions)
```
Where:
* actor : The actor the hMessage. Mandatory.
* type : The type of the hMessage. (ie: hack, halert, ...)
* payload : The payload for the hMessage (the payload should be of type described in type)
* options : hMessage creation options. See below for hMessageOptions Structure.
* return : hMessage msg created with the payload.

HMessageOptions Strucutre : 
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
Where (All fields are optional) :
 * ref : The msgid of the message refered to
 * convid : conversation id
 * priority : priority of the message. If UNDEFINED, priority lower to 0. See HMessagePrioity in codes and enum section.
 * relevance : Date and time until which the message is relevant
 * relevanceOffset : If you use this parameter, it will override the relevance one by updating the date-time for the relevance of the hMessage.
 * persistent : do the server need to persist the hmessage.
 * location : The location of the HMessage. See HLocation in hAPI DataModel
 * author : the author of the HMessage
 * headers : the headers of the HMessage. See HHeader in hAPI DataModel
 * published : Specify a publishing date.
 * timeout : Time (in ms) to wait for a response before hAPI sends a timeout.

#### BuildConvState

Build a hMessage with a hConvState payload

```c#
public HMessage BuildConvState(string actor, string convid, string status, HMessageOptions mOptions)
```
Where:
* actor : The channel id where to publish. Mandatory.
* convid : The conversation id. Mandatory. This will replace any convid set in hMessageOption.
* status : Status of the conversation. Mandatory.
* options : hMessage creation options. See buildMessage for hMessageOptions Structure.
* return : hMessage msg created with the payload.

#### BuildAck

Build a hMessage with a hAck payload

```c#
 public HMessage BuildAck(string actor, string @ref, string ackValue, HMessageOptions mOptions)
```
Where:
* actor : The actor for the hMessage.  Mandatory.
* ref : The msgid to acknowledged. Mandatory.
* ack : The ack value. See AckValue in Codes and enum. Mandatory.
* options : hMessage creation options. See buildMessage for hMessageOptions Structure.
* return : A hMessage with a hAck payload.

#### BuildAlert

Build a hMessage with a hAlert payload

```c#
 public HMessage BuildAlert(string actor, string alert, HMessageOptions mOptions)
```
Where:
* chid : The channel id of the hMessage. Mandatory.
* alert : description of the alert. Mandatory.
* options : hMessage creation options. See buildMessage for hMessageOptions Structure.
* return : hMessage msg created with the payload.

#### BuildMeasure

Build a hMessage with a hMeasure payload

```c#
 public HMessage BuildMeasure(string actor, string value, string unit, HMessageOptions mOptions)
```
Where:
* actor : The actor for the hMessage. Mandatory.
* value : value of the measure in "unit" type.
* unit : unit type of the value (cm, m, g ...).
* options : hMessage creation options. See buildMessage for hMessageOptions Structure.
* return : A hMessage with hMeasure payload.


#### BuildCommand

Build a hMessage with a hCommand payload

```c#
 public HMessage BuildCommand(string actor, string cmd, JObject @params, HCondition filter, HMessageOptions mOptions) 
```
Where:
* actor : The actor for the hMessage. Mandatory.
* cmd : The name of the command.
* params : Parameters of the command. Not mandatory.
* options : hMessage creation options. See buildMessage for hMessageOptions Structure.
* filter : optional. null if there is no filter.
* return : A hMessage with a hCommand payload.

#### BuildResult

Build a hMessage with a hResult payload

```c#
public HMessage BuildResult(string actor, string @ref, ResultStatus status, JObject result, HMessageOptions mOptions)
public HMessage BuildResult(string actor, string @ref, ResultStatus status, JArray result, HMessageOptions mOptions)
public HMessage BuildResult(string actor, string @ref, ResultStatus status, string result, HMessageOptions mOptions)
public HMessage BuildResult(string actor, string @ref, ResultStatus status, bool result, HMessageOptions mOptions)
public HMessage BuildResult(string actor, string @ref, ResultStatus status, int result, HMessageOptions mOptions)
public HMessage BuildResult(string actor, string @ref, ResultStatus status, double result, HMessageOptions mOptions)
```
Where:
* actor : The actor for the hMessage. Mandatory.
* ref : The id of the message received, for correlation purpose.
* status : Result status code. Mandatory.
* result : Result of the command.
* options : hMessage creation options. See buildMessage for hMessageOptions Structure.
* return : A hMessage with a hResult payload.

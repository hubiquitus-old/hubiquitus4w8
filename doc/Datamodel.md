#Datamodel
The hAPI datamodel defines semantics core to the Hubiquitus platform. It defines the core concepts of the hubiquitus programming model, the data structures associated with it and the way data is transmitted and processed through the network.

API heavily relies on JSON, which has been preferred to XML for two main reasons :

* Efficiency : JSON is structured but lightweight ; it is a perfect choice for exchanging data over constraint networks such as wireless mobile networks.
* Web-readiness: as a Web fellow, JSON is natively understood by any web browser complying to the W3C standards ; it is today the best candidate for an ubiquitous format (please notice that the hAPI model could easily be translated to any other structured semantic such as XML).

**_Android HAPI objects are internally JSON Objects. Getters and setters are convenient functions to set and access JSON object values._**

Hubiquitus defines a set of basic data structure used to express elementary piece of typed data:

* Messages
  - hMessage
* hMessage payloads
  - hCommand
  - hResult
  - hMeasure
  - hAlert
  - hAck
  - hConvState
  - hTweet
  - hHTTPData
* Metadata
  - hHeader
  - hLocation
* Filter
  - hCondition




##Messages

###HMessage

HStructure for hubiquitus messages.

```c#
public class HMessage : JObject
{
        public string GetMsgid()
        public void SetMsgid(string msgid)

        public string GetActor()
        public void SetActor(string actor)

        public string GetConvid()
        public void SetConvid(string convid)

        public string GetRef()
        public void SetRef(string @ref)

        public string GetType()
        public void SetType(string type)

        public HMessagePriority? GetPriority()
        public void SetPriority(HMessagePriority? priority)

        public long GetRelevance()
        public DateTime? GetRelevanceAsDate()
        public void SetRelevance(DateTime? relevance)
        public void SetRelevance(long relevance)

        public bool? GetPersistent()
        public void SetPersistent(bool? persistent)

        public HLocation GetLocation()
        public void SetLocation(HLocation location)

        public string GetAuthor()
        public void SetAuthor(string author)

        public string GetPublisher()
        public void SetPublisher(string publisher)

        public long GetPublished()
	public DateTime? GetPublishedAsDate()
        public void SetPublished(DateTime? published)
        public void SetPublished(long published)

        public JObject GetHeaders()
        public void SetHeaders(JObject headers)

        public JObject GetPayloadAsJObject()
        public JArray GetPayloadAsJArray()
        public string GetPayloadAsString()
        public bool? GetPayloadAsBoolean()
        public int? GetPayloadAsInt()
        public double? GetPayloadAsDouble()
        public HAck GetPayloadAsHAck()
        public HMeasure GetPayloadAsHMeasure()
        public HConvState GetPayloadAsHConvState()
        public HResult GetPayloadAsHResult()
        public HCommand GetPayloadAsHCommand()
        
        public void SetPayload(JToken payload)
        public void SetPayload(JObject payload)
        public void SetPayload(JArray payload)
        public void SetPayload(string payload)
        public void SetPayload(bool payload)
        public void SetPayload(int payload)
        public void SetPayload(double payload)
        public void SetPayload(HAlert payload)
        public void SetPayload(HAck payload)
        public void SetPayload(HMeasure payload)
        public void SetPayload(HConvState payload)
        public void SetPayload(HResult payload)
        public void SetPayload(HCommand payload)
        
        public int GetTimeout()
        public void SetTimeout(int timeout)
        
        public long GetSent()
        public DateTime? GetSentAsDate()
        public void SetSent(DateTime? sent)
        public void SetSent(long sent)
}
```
Where : 
* msgid : Message id. Mandatory. Can be filled by the hApi. 
* actor : The unique ID of the channel through which the message is published. Mandatory.
* convid : Conversation if to which the message belongs. Mandatory. Filled by the hNode if empty.
* ref : Refers to another hMessage msgid. Provide a mechanism to do correlation between messages.
* type : Type of the message payload.
* priority : Message priority. If UNDEFINED, priority lower to 0. Mandatory. Can be filled by hApi. 
* persistent : Define if the message is persistent. If true, the message is not persistent. false by defaut.
* location : The geographical location to which the message refer. See HLocation below.
* author : Author's id of this message.
* publisher : Publisher id. Mandatory. Can be filled by hApi.
* published : The date and time at which the message has been published. Mandatory. Can be filled by hApi.
* headers : A Headers object attached to this message. It is a key-value pair map. It is possible to not specify any header.
* payload : The content of the message.
* timeout : The timeout to get an answer to the hMessage. The hAPI will manage the value and response messages will be sent through callback set on send command.
* sent : Set by the hAPI when sending the message. As the published attribute can contain the original creation date of the information know by the author, this attribute contains the creation datetime of the hMessage



## hMessage Payload

### HCommand

The purpose of a hCommand is to execute an operation on a specific component, a hubot or a hServer.

```c#
public class HCommand : JObject
{
        public string GetCmd()
        public void SetCmd(string cmd)

        public JObject GetParams()
        public void SetParams(JObject @params)
}

```

Where : 
* cmd : Name of the command which will be executed. Mandatory.
* params : Parameters of the command.

### HResult

The purpose of a HResult is to get an information on a commmand execution result.
This is returned once a command has been executed by the server.

```c#
public class HResult : JObject
        public ResultStatus? GetStatus()
        public void SetStatus(ResultStatus? status)

        public object GetResult()
        public JObject GetResultAsJObject()
        public JArray GetResultASJArray()
        public string GetResultAsString()
        public bool? GetResultAsBoolean()
        public int? GetResultAsInt()
        public double? GetResultAsDouble()

        public void SetResult(JToken result)
        public void SetResult(JObject result)
        public void SetResult(JArray result)
        public void SetResult(string result)
        public void SetResult(bool result)
        public void SetResult(int result)
        public void SetResult(double result)
    }
```
Where : 
* status : result status. See Codes and enums. Mandatory.
* result : Command result object. Command dependent.

###HStatus

This structure describe the connection status

```c#
public class HStatus : JObject
{
        public ConnectionStatus? GetStatus()
        public void SetStatus(ConnectionStatus? status)

        public ConnectionErrors? GetErrorCode()
        public void SetErrorCode(ConnectionErrors? errorCode)

        public string GetErrorMsg()
        public void SetErrorMsg(string errorMsg)
}

```
Where : 
* status : Current connection status. See ConnectionStatus in codes and enums. Mandatory
* errorCode : 0 if no error. For more informations, see ConnectionError in codes and enums. Mandatory
* errorMsg : error message. Null if no error or no description.


###HMeasure

HStructure for measure payload.

```c#
public class HMeasure : JObject
{
        public string GetUnit()
        public void SetUnit(string unit)

        public string GetValue()
        public void SetValue(string value)
}
```
Where: 
* unit : Unit in which the measure is expressed, should be in lowercase. Mandatory. (ie : "celsius" , "fahrenheit")
* value : Specify the value of the measure. Mandatory. (ie : "31.2")


###HAck

hAPI allows to attach acknowledgements to each message
Acknowledgements are used to identify the participants that have received or not received, read or not read a message.
_When a hMessage contains a such kind of payload, the convid must be provided with the same value has the acknowledged hMessage._

```c#
public class HAck : JObject
{
  public string GetAck()
	public void SetAck(string ack)
}
```
Where : 
* ack : The status of the acknowledgement. See AckValue in codes and enums. Mandatory.

###HAlert

HStructure for alert payload.
_For a such kind of payload, the hMessage’s priority should be greater or equals to 2 and may be greater than the default channel’s priority._

```java
public class HAlert : JObject
{
	public string GetAlert()
	public void SetAlert(string alert)
}
```

Here is an enumeration of these properties : 
* alert : Description of the alert. Mandatory.


###HConvState

This kind of payload is used to describe the status of a thread of correlated messages identified by its convid.
Multiple hConvStates with the same convid can be published into a channel, specifying the evolution of the state of the thread during time.

```c#
public class HConvState : JObject 
{
	public string GetStatus()
	public void SetStatus(string status)
}
```
where :
* status : The status of the thread. Mandatory. (Can be read and set)

###Metadata

####HLocation

HStructure for hubiquitus location.


```java
public class HLocation : JObject
{
        public HGeo GetPos();
	public void SetPos(HGeo pos);
        
        public string GetNum();
	public void SetNum(string num);

        public string GetWayType();
	public void SetWayType(string wayType);

        public string GetWay();
	public void SetWay(string way);

        public string GetFloor();
	public void SetFloor(string floor);

        public String getBuilding();
	public void setBuilding(string building);

	public string GetZip();
	public void SetZip(string zip);
	
	public string GetAddr();
	public void SetAddr(string addr);
	
	public string GetCity();
	public void SetCity(string city);

	public string GetCountry();
	public void SetCountry(string country);

        public string GetCountryCode();
	public void SetCountryCode(string countryCode);
}
```
Where : 
* pos : Specifies the exact longitude and latitude of the location.
* num : Number of the address
* waytype : Type of the way
* way : Name of the street/way
* floor : Floor number of the address
* building : Building’s identifier of the address
* zip : Zip code of the location
* addr : Address of the location
* city : City of the location
* country : Country of the location
* countryCode : Country code 
 

###HGeo

HStructure for hubiquitus geo.
```c#
public class HGeo : JObject
{
       public double GetLng();
       public void SetLng(double lng);

       public double GetLat();
       public void SetLat(double lat);
}
```
Where : 
* lng : The longitude of the location. Mandatory.
* lat : The latitude of the location. Mandatory.

##Filter
###hCondition
```c#
public class HCondition : JObject
{
        public void SetEqValue(HValue value)
        public HValue GetEqValue()

        public void SetNeValue(HValue value)
        public HValue GetNeValue()

        public void SetGtValue(HValue value)
        public HValue GetGtValue()

        public void SetGteValue(HValue value)
        public HValue GetGteValue()

        public void SetLtValue(HValue value)
        public HValue GetLtValue()

        public void SetLteValue(HValue value)
        public HValue GetLteValue()

        public void SetInValue(HArrayOfValue value)
        public HArrayOfValue GetInValue()

        public void SetNinValue(HArrayOfValue value)
        public HArrayOfValue GetNinValue()

        public void SetAndValue(JArray value)
        public JArray GetAndValue()

        public void SetOrValue(JArray value)
        public JArray GetOrValue()

        public void SetNorValue(JArray value)
        public JArray GetNorValue()

        public void SetNotValue(HCondition value)
        public HCondition GetNotValue()
}
```

Samples : 
   { } /* no condition equals to always true */
   { “eq” : { “author” :  “u1@myDomain.com” }}
   { “ne” : { “author” :  “u1@myDomain.com” }}
   { “gt” : { “priority” : 1 }}
   { “gte” : { “priority” : 1 }}
   { “lt” : { “priority” : 3 }}
   { “lte” : { “priority” : 3 }}

   { “in” : { “author” : [ “u1@myDomain.com” , “u2@myDomain.com” ] } }
   { “nin” : { “author” : [ “u1@myDomain.com” , “u2@myDomain.com” ] } }

   { “and” : [
       { “in” : { “author” : [ “u1@myDomain.com” , “u2@myDomain.com” ] } },
       { “lte” : { “priority” : 3 }}
   ] }

   { “or” : [
       { “in” : { “author” : [ “u1@myDomain.com” , “u2@myDomain.com” ] } },
       { “lte” : { “priority” : 3 }}
   ] }

   { “not “ :
      { “and” : [
          { “in” : { “author” : [ “u1@myDomain.com” , “u2@myDomain.com” ] } },
          { “lte” : { “priority” : 3 }}
          ]
       }
   }

   { relevant : true }

   { geo : {
       lat : 40.2,
       lng : 2.4,
       radius : 10000
      }
   }


Where:
 * eq : equals
 * ne : not equals
 * gt : greater than
 * gte : greater than or equals
 * lt : lower than
 * lte : lower than or equals
 * in : the attribute must be equals to one of the values
 * nin : the attribute must be different with all the values
 * and : all the conditions must be true
 * or : one of the conditions must be true
 * nor : all the conditions must be false
 * not : the condition must be false

Operand relevant : used to filter relevant or non relevant messages

Operand geo : used to filter messages with a latitude, longitude and radius definition (see hPos for details)


Available name of operand : 
 * hValue : eq, ne, gt, gte, lt, lte
 * hArrayOfValue : in, nin
 * Array of hCondition : and, or, nor
 * hCondition : not

####hValue
```c#
public class HValue : JObject
{
        public void SetName(string name)
        public string GetName()

        public void SetValue(JToken value)
        public JToken GetValue()
}
```

Where :

 * name : The name of an attribute.
 * value : The value of the attribute to compare with.

Sample : 

   { “author” :  “u1@myDomain.com” } 

####hArrayOfValue
```c#
public class HArrayOfValue : JObject
{
        public string GetName()
        public void SetName(string name)

        public void SetValues(JArray value)
        public JArray GetValues()
}

```

Where : 

 * name : The name of an attribute.
 * values : The values of the attribute to compare with.

Sample : 

   { “author” : [ “u1@myDomain.com” , “u2@myDomain.com” ] } 


####hPos
```c#
public class HPos : JObject {
	public double? GetLat();
	public void SetLat(double lat);

	public double? GetLng();
	public void SetLng(double lng);

	public double? GetRadius();
	public void SetRadius(double radius);
}
```

Where : 

 * lat : The latitude of the searched location.
 * lng : The longitude of the searched location.
 * radius : the precision of the searched location (meter)

Sample : 

{ lat: 48, lng: 2,  radius: 10000  }
 

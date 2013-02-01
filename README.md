# Hubiquitus4w8 - An implementation of Hubiquitus for the Windows 8.


## How to install

First of all, clone the project.
Tap the following command in terminal(Linux) or in Powershell(Windows) : 

```js
git clone git://github.com/hubiquitus/hubiquitus4w8.git
```


## How to use

### How to use hAPI

1. Run project with _Release_ mode.
2. Copy the libary ```hubiquitus4w8.dll``` in _C:\Users\Chenliang\Documents\test\hubiquitus4w8\hubiquitus4w8\obj\Release_ to your project and add it to your reference.


#### hAPI Reference :

 * [hClient Functions](https://github.com/hubiquitus/hubiquitus4w8/blob/master/doc/hClient%20Functions.md) : Connect, disconnect, builder ... All the function of the client.

 * [hClient Variables](https://github.com/hubiquitus/hubiquitus4w8/blob/master/doc/hClient%20Variables.md) : Status, FullJid, Resource... All the variables of the client.

 * [Codes](https://github.com/hubiquitus/hubiquitus4w8/blob/master/doc/Codes.md) : ConnectionStatus, ConnectionError, ResultStatus ... All the enumeration of Hubiquitus.

 * [Datamodel](https://github.com/hubiquitus/hubiquitus4w8/blob/master/doc/Datamodel.md) : Information about hAPI Datamodel.

 * [Options](https://github.com/hubiquitus/hubiquitus4w8/blob/master/doc/hOptions.md) : Information about options class.


## Example

[Simple Client](https://github.com/hubiquitus/hubiquitus4w8/tree/master/SimpleClient) is an example application to test the hAPI.

### How to run

1. Right click on the project -> click _Set as Startup project_
2. Run with mode debug.

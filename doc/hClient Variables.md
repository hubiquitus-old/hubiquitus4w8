When you create an instance of HClient, you have access to the variables :


### Status

This attribute of the client hAPI contains the last value of the hStatus.status attribute. 
Give the latest connection state

```c#
public ConnectionStatus Status;
```
Where:
* return : the connection status (See codes pages)

### FullJid
The FullJid will return the full Jid of the client.
```c#
public string FullJid;
```

### Resource
The Resource will return the resource of the Jid
```c#
public string Resource;
```

/*
 * Copyright (c) Novedia Group 2012.
 *
 *     This file is part of Hubiquitus.
 *
 *     Hubiquitus is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     Hubiquitus is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with Hubiquitus.  If not, see <http://www.gnu.org/licenses/>.
 */



using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json.Linq;
using hubiquitus4w8.hapi.hStructures;
using hubiquitus4w8.hapi.stuctures;
using hubiquitus4w8.hapi.transport;
using hubiquitus4w8.hapi.transport.socketio;
using hubiquitus4w8.hapi.util;
using hubiquitus4w8.hapi.exceptions;

namespace hubiquitus4w8.hapi.client
{
    /// <summary>
    /// Hubiquitus client, public api version v0.4
    /// </summary>
    public class HClient
    {
        private ConnectionStatus connectionStatus = ConnectionStatus.DISCONNECTED;
        private HOptions options = null;
        private HTransport transport = null;
        private HTransportOptions transportOptions;

        public delegate void StatusEventHandler(HStatus status);
        public delegate void MessageEventHandler(HMessage message);
        public delegate void CommandEventHandler(HCommand command);

        /// <summary>
        /// Status event handler recieve all connection status events
        /// </summary>
        public event StatusEventHandler onStatus;

        /// <summary>
        /// Message event handler recieve all message events
        /// </summary>
        public event MessageEventHandler onMessage;

        /// <summary>
        /// Command event handler recieve all command events
        /// </summary>
        public event CommandEventHandler onCommand;

        

        private Hashtable resultDelegates = new Hashtable();

        public HClient()
        {
            transportOptions = new HTransportOptions();
        }


        /// <summary>
        /// Connect to server
        /// </summary>
        /// <param name="publisher">user jid i.e.(my_user@domain/resource)</param>
        /// <param name="password"></param>
        /// <param name="options"></param>
        public void Connect(string publisher, string password, HOptions options)
        {
            bool shouldConnect = false;
            bool connInprogress = false;
            bool disconnInprogress = false;

            if (this.connectionStatus == ConnectionStatus.DISCONNECTED)
            {
                shouldConnect = true;
                connectionStatus = ConnectionStatus.CONNECTING;
            }
            if (this.connectionStatus == ConnectionStatus.CONNECTING)
                connInprogress = true;
            if (this.connectionStatus == ConnectionStatus.DISCONNECTING)
                disconnInprogress = true;

            if (shouldConnect)
            {
                notifyStatus(ConnectionStatus.CONNECTING, ConnectionErrors.NO_ERROR, null);
                try
                {
                    fillTransportOptions(publisher, password, options);
                }
                catch (Exception e)
                {
                    notifyStatus(ConnectionStatus.DISCONNECTED, ConnectionErrors.JID_MALFORMAT, e.Message);
                    return;
                    throw e;
                }

                if (options.transport == "socketio")
                {
                    if (transport == null || !(transport is HTransportSocketIO))
                        this.transport = new HTransportSocketIO();
                    this.transport.Connect(this.transportOptions);
                }
                else
                {
                    // XMPP
                    Console.WriteLine("XMPP to be defined!!");
                }
                this.transport.onStatus += transport_onStatus;
                this.transport.onData += transport_onData;
            }
            else
            {
                if (connInprogress)
                    notifyStatus(ConnectionStatus.CONNECTING, ConnectionErrors.CONN_PROGRESS, null);
                else if (disconnInprogress)
                    notifyStatus(ConnectionStatus.DISCONNECTING, ConnectionErrors.ALREADY_CONNECTED, null);
                else
                    notifyStatus(ConnectionStatus.CONNECTED, ConnectionErrors.ALREADY_CONNECTED, null);
            }
        }

        void transport_onData(string type, JObject obj)
        {
            if (type.Equals("hresult", StringComparison.OrdinalIgnoreCase))
                notifyResult(new HResult(obj));
            if (type.Equals("hmessage", StringComparison.OrdinalIgnoreCase))
                notifyMessage(new HMessage(obj));
            if (type.Equals("hcommand", StringComparison.OrdinalIgnoreCase))
                notifyCommand(new HCommand(obj));
        }

        private void transport_onStatus(ConnectionStatus status, ConnectionErrors error, string errrorMsg)
        {
            notifyStatus(status, error, errrorMsg);
        }

        /// <summary>
        /// disconnect from server
        /// </summary>
        public void Disconnect()
        {
            bool shouldDisconnect = false;
            bool connInprogress = false;

            if (this.connectionStatus == ConnectionStatus.CONNECTED)
            {
                shouldDisconnect = true;
                this.connectionStatus = ConnectionStatus.DISCONNECTING;
            }
            else if (this.connectionStatus == ConnectionStatus.CONNECTING)
            {
                connInprogress = true;
            }

            if (shouldDisconnect)
            {
                notifyStatus(ConnectionStatus.DISCONNECTING, ConnectionErrors.NO_ERROR, null);
                transport.Disconnect();
            }
            else if (connInprogress)
                notifyStatus(ConnectionStatus.CONNECTING, ConnectionErrors.CONN_PROGRESS, "Can not disconnect while a connection is in progress");
            else
                notifyStatus(ConnectionStatus.DISCONNECTED, ConnectionErrors.NOT_CONNECTED, null);

            this.transport.onData -= transport_onData;
            this.transport.onStatus -= transport_onStatus;
        }

        public ConnectionStatus Status()
        {
            return this.connectionStatus;
        }

        
        /// <summary>
        /// removed since v0.5
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="resultDelegate"></param>
        public void Command(HCommand cmd, Action<HResult> resultDelegate)
        {
            if (this.connectionStatus == ConnectionStatus.CONNECTED && cmd != null)
            {
                string reqid = null;
                reqid = cmd.GetReqid();
                if (reqid == null)
                {
                    Random random = new Random();
                    reqid = "c#cmd:" + random.Next();
                    cmd.SetReqid(reqid);
                }

                if (cmd.GetSender() == null)
                    cmd.SetSender(transportOptions.Jid.GetFullJID());

                if (cmd.GetTransient() == null)
                    cmd.SetTransient(true);

                if (cmd.GetEntity() != null)
                {
                    if (resultDelegate != null)
                        resultDelegates.Add(reqid, resultDelegate);
                    transport.SendObject(cmd);
                }
                else
                {
                    notifyResultError(cmd.GetReqid(), cmd.GetCmd(), ResultStatus.MISSING_ATTR, "Entity not found");
                }
            }
            else if (cmd == null)
            {
                notifyResultError(null, null, ResultStatus.MISSING_ATTR, "Provided cmd is null", resultDelegate);
            }
            else
            {
                notifyResultError(cmd.GetReqid(), cmd.GetCmd(), ResultStatus.NOT_CONNECTED, null, resultDelegate);
            }
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Demands the server a subscription to a channel.
        /// The server will check if not already subscribed and if authorized subscribe him.
        /// </summary>
        /// <param name="chid">channel id</param>
        /// <param name="resultDelegate">An action notified when a result issued</param>
        public void Subscribe(string chid, Action<HResult> resultDelegate)
        {
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);
            HCommand cmd = new HCommand(transportOptions.GetHserverService(), "hsubscribe", @params);
            this.Command(cmd, resultDelegate);
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Demands the server an unsubscription to the channel
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="resultDelegate"></param>
        public void Unsubscribe(string chid, Action<HResult> resultDelegate)
        {
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);
            HCommand cmd = new HCommand(transportOptions.GetHserverService(), "hunsubscribe", @params);
            this.Command(cmd, resultDelegate);
        }
        //removed since v0.5
        public void Publish(HMessage msg, Action<HResult> resultDelegate)
        {
            string msgid = msg.GetMsgid();
            if (msgid == null)
            {
                Random random = new Random();
                msgid = "c#cmd: " + random.Next();
                msg.SetMsgid(msgid);
            }

            string convid = msg.GetConvid();
            if (convid == null)
                msg.SetConvid(msgid);
            if (msg.GetPublisher() == null)
                msg.SetPublisher(transportOptions.Jid.GetBareJID());
            HCommand cmd = new HCommand(transportOptions.GetHserverService(), "hpublish", msg);
            Command(cmd, resultDelegate);

        }

        //since v0.5
        /// <summary>
        /// The client MUST be connected to access to this service
        /// The hAPI sends the hMessage to the hServer.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="resultDelegate"></param>
        public void Send(HMeasure msg, Action<HResult> resultDelegate)
        {

        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Demands the hserver a list of the last messages saved for a dedicated channel. 
        /// The requester must be in the channel’s participants list.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="nbLastMsg"></param>
        /// <param name="resultDelegate"></param>
        public void GetLastMessages(string chid, int nbLastMsg, Action<HResult> resultDelegate)
        {
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);
            if (nbLastMsg > 0)
                @params.Add("nbLastMsg", nbLastMsg);
            else
                @params.Add("nbLastMsg", 10);
            HCommand cmd = new HCommand(transportOptions.GetHserverService(), "hgetlastmessages", @params);
            Command(cmd, resultDelegate);
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Demands the hserver a list of the last messages saved for a dedicated channel. 
        /// The requester must be in the channel’s participants list.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="resultDelegate"></param>
        public void GetLastMessages(string chid, Action<HResult> resultDelegate)
        {
            GetLastMessages(chid, -1, resultDelegate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultDelegate"></param>
        public void GetSubscriptions(Action<HResult> resultDelegate)
        {
            HCommand cmd = new HCommand(transportOptions.GetHserverService(), "hgetsubscriptions", null);
            Command(cmd, resultDelegate);
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Demands to the hserver the list of messages correlated by the convid value on a dedicated channel
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="convid"></param>
        /// <param name="resultDelegate"></param>
        public void GetThread(string chid, string convid, Action<HResult> resultDelegate)
        {
            string cmdName = "hgetthread";
            if (chid == null || chid.Length <= 0)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "chid is missing", resultDelegate);
                return;
            }
            if (convid == null || convid.Length <= 0)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "convid is missing", resultDelegate);
                return;
            }
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);
            @params.Add("convid", convid);

            HCommand cmd = new HCommand(transportOptions.GetHserverService(), cmdName, @params);
            Command(cmd, resultDelegate);

        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Demands to the hserver the list of convid where there is a hConvState with the status value searched on the channel 
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="status"></param>
        /// <param name="resultDelegate"></param>
        public void GetThreads(string chid, string status, Action<HResult> resultDelegate)
        {
            string cmdName = "hgetthreads";
            if (chid == null || chid.Length <= 0)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "chid is missing", resultDelegate);
                return;
            }
            if (status == null || status.Length <= 0)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "status is missing", resultDelegate);
                return;
            }
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);
            @params.Add("status", status);

            HCommand cmd = new HCommand(transportOptions.GetHserverService(), cmdName, @params);
            Command(cmd, resultDelegate);
        }

        /// <summary>
        /// Sets a filter to be applied to upcoming messages at the session level for a dedicated channel id.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="resultDelegate"></param>
        public void SetFilter(string chid, HFilterTemplate filter, Action<HResult> resultDelegate)
        {
            string cmdName = "hsetfilter";
            if (chid == null)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "chid is missing", resultDelegate);
                return;
            }
            if (filter == null)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "filter is missing", resultDelegate);
                return;
            }
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);
            @params.Add("filter", filter);

            HCommand cmd = new HCommand(transportOptions.GetHserverService(), cmdName, @params);
            Command(cmd, resultDelegate);
        }

        /// <summary>
        /// fetches the list of filters set on the current session.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="resultDelegate"></param>
        public void ListFilters(string chid, Action<HResult> resultDelegate)
        {
            string cmdName = "hlistfilters";
            if (chid == null || chid.Length <= 0)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "chid is missing", resultDelegate);
                return;
            }
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);

            HCommand cmd = new HCommand(transportOptions.GetHserverService(), cmdName, @params);
            Command(cmd, resultDelegate);
        }

        /// <summary>
        /// Unset a filter for a specified actor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="chid"></param>
        /// <param name="resultDelegate"></param>
        public void UnSetFilter(string name, string chid, Action<HResult> resultDelegate)
        {
            string cmdName = "hunsetfilter";
            if (chid == null || chid.Length <= 0)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "chid is missing", resultDelegate);
                return;
            }
            if (name == null || name.Length <= 0)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "name is missing", resultDelegate);
                return;
            }
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);
            @params.Add("name", name);

            HCommand cmd = new HCommand(transportOptions.GetHserverService(), cmdName, @params);
            Command(cmd, resultDelegate);
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Demands to the hserver the list of the available relevant message for a dedicated channel.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="resultDelegate"></param>
        public void GetRelevantMessages(string chid, Action<HResult> resultDelegate)
        {
            string cmdName = "hrelevantmessages";
            if (chid == null || chid.Length <= 0)
            {
                notifyResultError(null, cmdName, ResultStatus.MISSING_ATTR, "chid is missing", resultDelegate);
                return;
            }
            HJsonDictionnary @params = new HJsonDictionnary();
            @params.Add("chid", chid);

            HCommand cmd = new HCommand(transportOptions.GetHserverService(), cmdName, @params);
            Command(cmd, resultDelegate);
        }


        //Builders
        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Allow a hubapp client to create a hMessage.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="type"></param>
        /// <param name="payload"></param>
        /// <param name="mOptions"></param>
        /// <returns></returns>
        public HMessage BuildMessage(string chid, string type, HJsonObj payload, HMessageOptions mOptions)
        {
            try
            {
                if (chid == null || chid.Length <= 0)
                    throw new MissingAttrException("chid");
                HMessage message = new HMessage();
                message.SetActor(chid);
                message.SetType(type);
                if (mOptions != null)
                {
                    message.SetConvid(mOptions.Convid);
                    message.SetPriority(mOptions.Priority);
                    message.SetAuthor(mOptions.Author);
                    message.SetHeaders(mOptions.Headers);
                    message.SetLocation(mOptions.Location);
                    message.SetPublished(mOptions.Published);
                    message.SetRelevance(mOptions.Relevance);
                    message.SetPersistent(mOptions.Transient);
                }
                if (transportOptions != null && transportOptions.Jid != null)
                    message.SetPublisher(transportOptions.Jid.GetBareJID());
                message.SetPayload(payload);
                return message;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Allow a hubapp client to create a hMessage with a hConvState payload.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="convid"></param>
        /// <param name="status"></param>
        /// <param name="mOptions"></param>
        /// <returns></returns>
        public HMessage BuildConvState(string chid, string convid, string status, HMessageOptions mOptions)
        {
            try
            {
                if (chid == null || chid.Length <= 0)
                    throw new MissingAttrException("chid");
                if (convid == null || convid.Length <= 0)
                    throw new MissingAttrException("convid");
                if (status == null || status.Length <= 0)
                    throw new MissingAttrException("status");
                HConvState convState = new HConvState();
                convState.SetStatus(status);

                HMessage message = BuildMessage(chid, "hConvState", convState, mOptions);
                message.SetConvid(convid);
                return message;
            }
            catch (Exception)
            {

                throw;
            }
        }


        
        //HAckValue à faire
        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Allow a hubapp client to create a hMessage with a hAck payload.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="ref"></param>
        /// <param name="ack">
        /// The following values are authorized :
        /// “recv” : means that the message has been received by the participant (on at least one of its devices)
        /// “read” : means that the message has been read by the participant
        /// </param>
        /// <param name="mOptions"></param>
        /// <returns></returns>
        public HMessage BuildAck(string chid, string @ref, string ack, HMessageOptions mOptions)
        {
            try
            {
                if (chid == null || chid.Length <= 0)
                    throw new MissingAttrException("chid");
                if (@ref == null || @ref.Length <= 0)
                    throw new MissingAttrException("ref");
                if (ack == null)
                    throw new MissingAttrException("ack");
                if (HUtil.CheckAck(ack))
                    throw new Exception("only 'recv' and 'read' are authorized for ack");

                HAck hack = new HAck();
                hack.SetAck(ack);
                hack.SetAckid(@ref);
                HMessage message = BuildMessage(chid, "hAck", hack, mOptions);
                return message;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Allow a hubapp client to create a hMessage with a hAlert payload.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="alert"></param>
        /// <param name="mOptions"></param>
        /// <returns></returns>
        public HMessage BuildAlert(string chid, string alert, HMessageOptions mOptions)
        {
            try
            {
                if (chid == null || chid.Length <= 0)
                    throw new MissingAttrException("chid");
                if (alert == null || alert.Length <= 0)
                    throw new MissingAttrException("alert");

                HAlert halert = new HAlert();
                halert.SetAlert(alert);

                HMessage message = BuildMessage(chid, "hAlert", halert, mOptions);
                return message;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// Allow a hubapp client to create a hMessage with a hMeasure payload.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        /// <param name="mOptions"></param>
        /// <returns></returns>
        public HMessage BuildMeassur(string chid, string value, string unit, HMessageOptions mOptions)
        {
            try
            {
                if (chid == null || chid.Length <= 0)
                    throw new MissingAttrException("chid");
                if (value == null || value.Length <= 0)
                    throw new MissingAttrException("value");
                if (unit == null || unit.Length <= 0)
                    throw new MissingAttrException("unit");

                HMeasure hmeasure = new HMeasure();
                hmeasure.SetUnit(unit);
                hmeasure.SetValue(value);

                HMessage message = BuildMessage(chid, "hMeasure", hmeasure, mOptions);
                return message;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// The client MUST be connected to access to this service.
        /// since v0.5
        /// Allow a hubapp client to create a hMessage with a hCommand payload.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="cmd"></param>
        /// <param name="params"></param>
        /// <param name="mOptions"></param>
        /// <returns></returns>
        public HMessage BuildCommand(string chid, string cmd, HJsonObj @params, HMessageOptions mOptions)
        {
            try
            {
                if (chid == null || chid.Length <= 0)
                    throw new MissingAttrException("chid");
                if (cmd == null || cmd.Length <= 0)
                    throw new MissingAttrException("cmd");

                HCommand hcommand = new HCommand();
                hcommand.SetCmd(cmd);
                hcommand.SetParams(@params);

                HMessage hmessage = BuildMessage(chid, "hcommand", hcommand, mOptions);
                return hmessage;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// he client MUST be connected to access to this service.
        /// Allow a hubapp client to create a hMessage with a hResult payload.
        /// </summary>
        /// <param name="chid"></param>
        /// <param name="status"></param>
        /// <param name="result"></param>
        /// <param name="mOptions"></param>
        /// <returns></returns>
        public HMessage BuildResult(string chid, ResultStatus status, HJsonObj result, HMessageOptions mOptions)
        {
            try
            {
                if (chid == null || chid.Length <= 0)
                    throw new MissingAttrException("chid");

                HResult hresult = new HResult();
                hresult.SetResult(result);
                hresult.SetStatus(status);

                HMessage hmessage = BuildMessage(chid, "hResult", hresult, mOptions);
                return hmessage;

            }
            catch (Exception)
            {

                throw;
            }

            
        }

        //---private methods---
        private void notifyStatus(ConnectionStatus status, ConnectionErrors error, string errorMsg)
        {
            try
            {
                connectionStatus = status;
                if (this.onStatus != null)
                {
                    HStatus hstatus = new HStatus();
                    hstatus.SetStatus(status);
                    hstatus.SetErrorCode(error);
                    hstatus.SetErrorMsg(errorMsg);

                    Thread statusThread = new Thread(new ThreadStart(() =>
                         {
                             try
                             {
                                 this.onStatus(hstatus);
                             }
                             catch (Exception)
                             {

                                 throw;
                             }
                         }));
                    statusThread.Start();
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void notifyResult(HResult result)
        {
            Action<HResult> resultDelegate = (Action<HResult>)resultDelegates[result.GetReqid()];
            notifyResult(result, resultDelegate);
        }

        private void notifyResult(HResult result, Action<HResult> resultDelegate)
        {
            try
            {
                if (resultDelegate != null)
                {
                    Thread thread = new Thread(() => resultDelegate(result));
                    thread.Start();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void notifyMessage(HMessage message)
        {
            try
            {
                if (this.onMessage != null)
                {
                    Thread messageThread = new Thread(new ThreadStart(() =>
                    {
                        try
                        {
                            this.onMessage(message);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }));
                    messageThread.Start();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void notifyCommand(HCommand cmd)
        {
            try
            {
                if (this.onCommand != null)
                {
                    Thread commandThread = new Thread(new ThreadStart(() => {
                        try
                        {
                            this.onCommand(cmd);
                        }
                        catch (Exception)
                        {
                            
                            throw;
                        }
                    }));
                    commandThread.Start();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void notifyResultError(string reqid, string cmd, ResultStatus resultStatus, string errorMsg)
        {
            HJsonDictionnary obj = new HJsonDictionnary();
            obj.Add("errorMsg", errorMsg);
            HResult result = new HResult();
            result.SetCmd(cmd);
            result.SetReqid(reqid);
            result.SetStatus(resultStatus);
            result.SetResult(obj);
            this.notifyResult(result);
        }

        private void notifyResultError(string reqid, string cmd, ResultStatus resultStatus, string errorMsg, Action<HResult> resultDelegate)
        {
            HJsonDictionnary obj = new HJsonDictionnary();
            obj.Add("errorMsg", errorMsg);
            HResult result = new HResult();
            result.SetCmd(cmd);
            result.SetReqid(reqid);
            result.SetStatus(resultStatus);
            result.SetResult(obj);
            this.notifyResult(result, resultDelegate);
        }

        private void fillTransportOptions(string publisher, string password, HOptions options)
        {
            try
            {
                JabberID jid = new JabberID(publisher);

                this.transportOptions.Jid = jid;
                this.transportOptions.Password = password;
                this.transportOptions.Hserver = options.hserver;

                //by default we user server host rather than publish host if defined
                if (options.serverHost != null)
                    this.transportOptions.ServerHost = options.serverHost;
                else
                    this.transportOptions.ServerHost = jid.Domain;
                this.transportOptions.ServerPort = options.serverPort;

                //for endpoints, pick one randomly and fill transport options
                if (options.endpoints.Count() > 0)
                {
                    int endpointIndex = HUtil.PickIndex<string>(options.endpoints);
                    string endpoint = options.endpoints.ElementAt<string>(endpointIndex);

                    transportOptions.EndpointHost = HUtil.GetHost(endpoint);
                    transportOptions.EndpointPort = HUtil.GetPort(endpoint);
                    transportOptions.EndpointPath = HUtil.GetPath(endpoint);
                }
                else
                {
                    transportOptions.EndpointHost = null;
                    transportOptions.EndpointPort = 0;
                    transportOptions.EndpointPath = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

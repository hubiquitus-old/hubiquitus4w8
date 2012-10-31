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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubiquitus4w8.hapi.hStructures;
using Newtonsoft.Json.Linq;

namespace hubiquitus4w8.hapi.transport
{
    public delegate void DataEventHandler(string type, JObject obj);
    public delegate void StatusEventHandler(ConnectionStatus status, ConnectionErrors error, string errrorMsg);
    public interface HTransport
    {
        
        event DataEventHandler onData;
        event StatusEventHandler onStatus;

        void Connect(HTransportOptions options);
        void Disconnect();
        void SendObject(HJsonObj obj);
    }
}

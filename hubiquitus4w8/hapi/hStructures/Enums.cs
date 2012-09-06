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

namespace hubiquitus4w8.hapi.hStructures
{

    enum ConnectionErrors
    {
        NO_ERROR = 0,
        JID_MALFORMAT,
        CONN_TIMEOUT,
        AUTH_FAILED,
        ATTACH_FAILED,
        ALREADY_CONNECTED,
        TECH_ERROR,
        NOT_CONNECTED,
        CONN_PROGRESS
    }

    enum ConnectionStatus
    {
        UNKNOWN = 0,
        CONNECTING,
        CONNECTED,
        REATTACHING,
        REATTACHED,
        DISCONNECTING,
        DISCONNECTED
    }




   

    enum HMessagePriority
    {
        TRACE = 0,
        INFO,
        WARNING,
        ALERT,
        CRITICAL,
        PANIC
    }



    enum ResultStatus
    {
        NO_ERROR = 0,
        TECH_ERROR = 1,
        NOT_CONNECTED = 3,
        NOT_AUTHORIZED = 5,
        MISSING_ATTR = 6,
        INVALID_ATTR = 7,
        NOT_AVAILABLE = 9,
        EXEC_TIMEOUT = 10
    }
}

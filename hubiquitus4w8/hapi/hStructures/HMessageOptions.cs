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
    /// <summary>
    /// Version 0.4
    /// hAPI MessageOption. For more info, see Hubiquitus reference
    /// </summary>
    class HMessageOptions
    {
        private string convid = null;
        private HMessagePriority priority;
        private DateTime relevance;
        private bool transient;
        private HLocation location = null;
        private string author = null;
        private HJsonObj headers = null;
        private DateTime published;

        public string Convid 
        {
            get { return convid; }
            set { convid = value; }
        }

        public HMessagePriority Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public DateTime Relevance
        {
            get { return relevance; }
            set { relevance = value; }
        }

        public bool Transient
        {
            get { return transient; }
            set { transient = value; }
        }

        public HLocation Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public HJsonObj Headers
        {
            get { return headers; }
            set { headers = value; }
        }

        public DateTime Published
        {
            get { return published; }
            set { published = value; }
        }
    }
}

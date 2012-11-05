using hubiquitus4w8.hapi.client;
using hubiquitus4w8.hapi.hStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class BuilderTest
    {
        HClient client = new HClient();
        string actorString = "u1@localhost";

        
        

        [TestMethod]
        public void TestBuildMessage()
        { 
            JObject headers = new JObject();
            headers["name"] = "value";
            
            HLocation location = new HLocation();
            HGeo pos = new HGeo(2.5, 45.5);
            location.SetPos(pos);
            string addrString = "addr string";
            location.SetAddr(addrString);
            string buildingString = "building string";
            location.SetBuilding(buildingString);
            string cityString = "city string";
            location.SetCity(cityString);
            string countryCode = "0033";
            location.SetCountryCode(countryCode);
            string floorString = "floor string";
            location.SetFloor(floorString);
            string numString = "num string";
            location.SetNum(numString);
            string wayString = "way string";
            location.SetWay(wayString);
            string wayTypeString = "way type string";
            location.SetWaytype(wayTypeString);
            string zipString = "zip string";
            location.SetZip(zipString);

            DateTime now = new DateTime();
            string refString = "ref string";
            string authorString = "author name";
            string convidString = "convid string";
            string typeString = "type string";

            HMeasure measure = new HMeasure();
            string unitString = "unit string";
            string valueString = "value string";
            measure.SetUnit(unitString);
            measure.SetValue(valueString);

            HMessage message = new HMessage();
            message.SetActor(actorString);
            message.SetType(typeString);
            message.SetRef(refString);
            message.SetConvid(convidString);
            message.SetPriority(HMessagePriority.INFO);
            message.SetAuthor(authorString);
            message.SetHeaders(headers);
            message.SetLocation(location);
            message.SetPublished(now);
            message.SetPersistent(false);
            message.SetTimeout(5000);
            message.SetRelevance(now);
            message.SetPayload(measure);

            HMessageOptions options = new HMessageOptions();
            options.Location = location;
            options.Headers = headers;
            options.Persistent = false;
            options.Priority = HMessagePriority.INFO;
            options.Published = now;
            options.Author = authorString;
            options.Convid = convidString;
            options.Ref = refString;
            options.Relevance = now;
            options.Timeout = 5000;

            Assert.AreEqual(message.ToString(), client.BuildMessage(actorString, typeString, measure, options).ToString());
        }

        [TestMethod]
        public void TestBuildAck()
        { 
            string ackString = "ack string";
            string refString = "ref string";

            HAck ack = new HAck();
            ack.SetAck(ackString);

            HMessage message = new HMessage();
            message.SetActor(actorString);
            message.SetType("hAck");
            message.SetRef(refString);
            message.SetPayload(ack);

            Assert.AreEqual(message.ToString(), client.BuildAck(actorString, refString, ackString, null).ToString());
        }

        [TestMethod]
        public void TestBuildAlert()
        { 
            string alertString = "alert string";

            HAlert alert = new HAlert();
            alert.SetAlert(alertString);
            
            HMessage message = new HMessage();
            message.SetActor(actorString);
            message.SetType("hAlert");
            message.SetPayload(alert);
            Assert.AreEqual(message.ToString(), client.BuildAlert(actorString, alertString, null).ToString());
        }

        [TestMethod]
        public void TestBuildCommand()
        { 
            string cmdString = "cmd string"; 
            JObject param = new JObject();
            param["params"] = "params string";
            HCommand command = new HCommand(cmdString, param);

            HMessage message = new HMessage();
            message.SetActor(actorString);
            message.SetType("hCommand");
            message.SetPayload(command);

            Assert.AreEqual(message.ToString(), client.BuildCommand(actorString, cmdString, param, null).ToString());
        }

        [TestMethod]
        public void TestBuildConvState()
        {
            string convidString = "convid string";
            string statusString = "status string";

            HConvState convstate = new HConvState();
            convstate.SetStatus(statusString);

            HMessage message = new HMessage();
            message.SetActor(actorString);
            message.SetType("hConvState");
            message.SetPayload(convstate);
            message.SetConvid(convidString);

            Assert.AreEqual(message.ToString(), client.BuildConvState(actorString, convidString, statusString, null).ToString());
        }

        [TestMethod]
        public void TestBuildMeasure()
        {
            string unitString = "unit string";
            string valueString = "value string";

            HMeasure measure = new HMeasure();
            measure.SetUnit(unitString);
            measure.SetValue(valueString);

            HMessage message = new HMessage();
            message.SetActor(actorString);
            message.SetType("hMeasure");
            message.SetPayload(measure);

            Assert.AreEqual(message.ToString(), client.BuildMeasure(actorString, valueString, unitString, null).ToString());
        }

        [TestMethod]
        public void TestBuildResult()
        { 
            string refString = "res string";
            JObject resultJson = new JObject();
            resultJson["result"] = "result string";
            HResult result = new HResult();
            result.SetResult(resultJson);
            result.SetStatus(ResultStatus.NO_ERROR);

            HMessage message = new HMessage();
            message.SetActor(actorString);
            message.SetType("hResult");
            message.SetRef(refString);
            message.SetPayload(result);


            Assert.AreEqual(message.ToString(), client.BuildResult(actorString, refString, ResultStatus.NO_ERROR, resultJson, null).ToString());
        }
    }
}

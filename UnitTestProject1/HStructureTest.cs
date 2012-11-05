using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hubiquitus4w8.hapi.hStructures;
using Newtonsoft.Json.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class HStructureTest
    {
        [TestMethod]
        public void TestHAck()
        {
            HAck ack = new HAck();
            string ackString = "ack string";
            ack.SetAck(ackString);
            JObject ackJson = new JObject();
            ackJson["ack"] = ackString;
            Assert.AreEqual(ack.ToString(), ackJson.ToString());
            Assert.AreEqual(ack.GetAck(), ackString);
        }

        [TestMethod]
        public void TestHAlert()
        {
            HAlert alert = new HAlert();
            string alertString = "alert string";
            alert.SetAlert(alertString);
            JObject alertJson = new JObject();
            alertJson["alert"] = alertString;
            Assert.ReferenceEquals(alert.ToString(), alertJson.ToString());
            Assert.AreEqual(alert.GetAlert(), alertString);
        }

        [TestMethod]
        public void TestHCommand()
        {
            HCommand command = new HCommand();
            string cmd = "cmd name";
            command.SetCmd(cmd);
            JObject param = new JObject();
            param["params"] = "params string";
            command.SetParams(param);
            JObject commandJson = new JObject();
            commandJson["cmd"] = cmd;
            commandJson["params"] = param;
            Assert.AreEqual(command.ToString(), commandJson.ToString());
            Assert.AreEqual(command.GetCmd(), cmd);
            Assert.AreEqual(command.GetParams().ToString(), param.ToString());
        }

        [TestMethod]
        public void TestHCondition()
        {
            HCondition condition = new HCondition();
            HValue value = new HValue("name", "value");
            condition.SetEqValue(value);
            condition.SetNeValue(value);
            condition.SetGtValue(value);
            condition.SetGteValue(value);
            condition.SetLtValue(value);
            condition.SetLteValue(value);
            JArray jArray = new JArray();
            jArray.Add("u1@localhost");
            jArray.Add("u2@localhost");
            HArrayOfValue valueArray = new HArrayOfValue("pubisher", jArray);
            condition.SetInValue(valueArray);
            condition.SetNinValue(valueArray);
            JArray conditionArray = new JArray();
            HCondition c1 = new HCondition();
            c1.SetEqValue(value);
            HCondition c2 = new HCondition();
            c2.SetNeValue(value);
            conditionArray.Add(c1);
            conditionArray.Add(c2);
            condition.SetAndValue(conditionArray);
            condition.SetOrValue(conditionArray);
            condition.SetNorValue(conditionArray);
            condition.SetNotValue(c1);

            Assert.AreEqual(value.ToString(), condition.GetEqValue().ToString());
            Assert.AreEqual(value.ToString(), condition.GetNeValue().ToString());
            Assert.AreEqual(value.ToString(), condition.GetGtValue().ToString());
            Assert.AreEqual(value.ToString(), condition.GetGteValue().ToString());
            Assert.AreEqual(value.ToString(), condition.GetLteValue().ToString());
            Assert.AreEqual(value.ToString(), condition.GetLtValue().ToString());
            Assert.AreEqual(valueArray.ToString(), condition.GetInValue().ToString());
            Assert.AreEqual(valueArray.ToString(), condition.GetNinValue().ToString());
            Assert.AreEqual(conditionArray.ToString(), condition.GetAndValue().ToString());
            Assert.AreEqual(conditionArray.ToString(), condition.GetOrValue().ToString());
            Assert.AreEqual(conditionArray.ToString(), condition.GetNorValue().ToString());
            Assert.AreEqual(c1.ToString(), condition.GetNotValue().ToString());
        }

        [TestMethod]
        public void TestHConvState()
        {
            HConvState convState = new HConvState();
            string statusString = "status string";
            convState.SetStatus(statusString);
            JObject convStateJson = new JObject();
            convStateJson["status"] = statusString;
            Assert.AreEqual(convStateJson.ToString(), convState.ToString());
            Assert.AreEqual(statusString, convState.GetStatus());
        }

        [TestMethod]
        public void TestHLocation()
        {
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

            JObject posJson = new JObject();
            posJson["lat"] = 2.5;
            posJson["lng"] = 45.5;
            JObject locationJson = new JObject();
            locationJson["pos"] = posJson;
            locationJson["addr"] = addrString;
            locationJson["building"] = buildingString;
            locationJson["city"] = cityString;
            locationJson["countryCode"] = countryCode;
            locationJson["floor"] = floorString;
            locationJson["num"] = numString;
            locationJson["way"] = wayString;
            locationJson["waytype"] = wayTypeString;
            locationJson["zip"] = zipString;

            Assert.AreEqual(posJson.ToString(), pos.ToString());
            Assert.AreEqual(2.5, pos.GetLat());
            Assert.AreEqual(45.5, pos.GetLng());

            Assert.AreEqual(locationJson.ToString(), location.ToString());
            Assert.AreEqual(pos.ToString(), location.GetPos().ToString());
            Assert.AreEqual(addrString, location.GetAddr());
            Assert.AreEqual(buildingString, location.GetBuilding());
            Assert.AreEqual(cityString, location.GetCity());
            Assert.AreEqual(countryCode, location.GetCountryCode());
            Assert.AreEqual(floorString, location.GetFloor());
            Assert.AreEqual(numString, location.GetNum());
            Assert.AreEqual(wayString, location.GetWay());
            Assert.AreEqual(wayTypeString, location.GetWaytype());
            Assert.AreEqual(zipString, location.GetZip());
        }

        [TestMethod]
        public void TestHMeasure()
        {
            HMeasure measure = new HMeasure();
            string unitString = "unit string";
            string valueString = "value string";
            measure.SetUnit(unitString);
            measure.SetValue(valueString);

            JObject measureJson = new JObject();
            measureJson["unit"] = unitString;
            measureJson["value"] = valueString;

            Assert.AreEqual(measureJson.ToString(), measure.ToString());
            Assert.AreEqual(unitString, measure.GetUnit());
            Assert.AreEqual(valueString, measure.GetValue());
        }

        [TestMethod]
        public void TestHMessage()
        {
            HMessage message = new HMessage();
            string actorString = "u1@localhost";
            message.SetActor(actorString);
            string authorString = "author's name";
            message.SetAuthor(authorString);
            string convidString = "convid string";
            message.SetConvid(convidString);
            JObject headers = new JObject();
            headers["header1"] = "value 1";
            headers["header2"] = "value 2";
            message.SetHeaders(headers);

            HLocation location = new HLocation();
            HGeo pos = new HGeo(2.5, 45.5);
            location.SetPos(pos);
            message.SetLocation(location);
            string msgidString = "msgid string";
            message.SetMsgid(msgidString);

            HMeasure measure = new HMeasure();
            string unitString = "unit string";
            string valueString = "value string";
            measure.SetUnit(unitString);
            measure.SetValue(valueString);
            message.SetPayload(measure);
            
            message.SetPersistent(true);
            message.SetPriority(HMessagePriority.PANIC);
            DateTime now = new DateTime();
            message.SetPublished(now);
            string publisherString = "publisher string";
            message.SetPublisher(publisherString);
            string refString = "ref string";
            message.SetRef(refString);
            message.SetRelevance(now);
            message.SetSent(now);
            message.SetTimeout(3000);
            string typeString = "type string";
            message.SetType(typeString);

            Assert.AreEqual(actorString, message.GetActor());
            Assert.AreEqual(authorString, message.GetAuthor());
            Assert.AreEqual(convidString, message.GetConvid());
            Assert.AreEqual(headers.ToString(), message.GetHeaders().ToString());
            Assert.AreEqual(location.ToString(), message.GetLocation().ToString());
            Assert.AreEqual(msgidString, message.GetMsgid());
            Assert.AreEqual(measure.ToString(), message.GetPayloadAsHMeasure().ToString());
            Assert.AreEqual(true, message.GetPersistent());
            Assert.AreEqual(HMessagePriority.PANIC, message.GetPriority());
            Assert.AreEqual(now, message.GetPublished());
            Assert.AreEqual(publisherString, message.GetPublisher());
            Assert.AreEqual(refString, message.GetRef());
            Assert.AreEqual(now, message.GetRelevance());
            Assert.AreEqual(now, message.GetSent());
            Assert.AreEqual(3000, message.GetTimeout());
            Assert.AreEqual(typeString, message.GetType());
        }

        [TestMethod]
        public void TestResult()
        {
            HResult result = new HResult();
            result.SetStatus(ResultStatus.NO_ERROR);
            JObject resultJson = new JObject();
            resultJson["result"] = "result string";
            result.SetResult(resultJson);

            Assert.AreEqual(ResultStatus.NO_ERROR, result.GetStatus());
            Assert.AreEqual(resultJson, result.GetResult());
        }

        [TestMethod]
        public void TestStatus()
        {
            HStatus status = new HStatus();
            status.SetErrorCode(ConnectionErrors.NOT_CONNECTED);
            status.SetStatus(ConnectionStatus.DISCONNECTED);
            string errormsgString = "erros msg string";
            status.SetErrorMsg(errormsgString);

            Assert.AreEqual(ConnectionErrors.NOT_CONNECTED, status.GetErrorCode());
            Assert.AreEqual(ConnectionStatus.DISCONNECTED, status.GetStatus());
            Assert.AreEqual(errormsgString, status.GetErrorMsg());
        }

    }
}

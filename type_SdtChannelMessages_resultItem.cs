/*
				   File: type_SdtChannelMessages_resultItem
			Description: result
				 Author: Nemo 🐠 for C# version 17.0.2.148565
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="ChannelMessages.resultItem")]
	[XmlType(TypeName="ChannelMessages.resultItem" , Namespace="RastreamentoTCC" )]
	[Serializable]
	public class SdtChannelMessages_resultItem : GxUserType
	{
		public SdtChannelMessages_resultItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtChannelMessages_resultItem_Battery_status = "";

			gxTv_SdtChannelMessages_resultItem_Device_model = "";

			gxTv_SdtChannelMessages_resultItem_Device_name = "";

			gxTv_SdtChannelMessages_resultItem_Driver_id = "";

			gxTv_SdtChannelMessages_resultItem_Gnss_type = "";

			gxTv_SdtChannelMessages_resultItem_Gsm_mcc = "";

			gxTv_SdtChannelMessages_resultItem_Gsm_mnc = "";

			gxTv_SdtChannelMessages_resultItem_Peer = "";

			gxTv_SdtChannelMessages_resultItem_Vehicle_vin = "";

			gxTv_SdtChannelMessages_resultItem_Report_code = "";

		}

		public SdtChannelMessages_resultItem(IGxContext context)
		{
			this.context = context;
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
				mapper["air.pressure"] = "Air_pressure";
				mapper["alarm.event"] = "Alarm_event";
				mapper["antitheft.event"] = "Antitheft_event";
				mapper["battery.charging.status"] = "Battery_charging_status";
				mapper["battery.status"] = "Battery_status";
				mapper["can.ambient.air.temperature"] = "Can_ambient_air_temperature";
				mapper["can.engine.oil.temperature"] = "Can_engine_oil_temperature";
				mapper["can.engine.rpm"] = "Can_engine_rpm";
				mapper["can.engine.temperature"] = "Can_engine_temperature";
				mapper["can.fuel.consumption"] = "Can_fuel_consumption";
				mapper["can.intake.air.temperature"] = "Can_intake_air_temperature";
				mapper["can.maf.air.flow.rate"] = "Can_maf_air_flow_rate";
				mapper["can.throttle.pedal.level"] = "Can_throttle_pedal_level";
				mapper["can.vehicle.mileage"] = "Can_vehicle_mileage";
				mapper["can.vehicle.speed"] = "Can_vehicle_speed";
				mapper["channel.id"] = "Channel_id";
				mapper["device.id"] = "Device_id";
				mapper["device.model"] = "Device_model";
				mapper["device.name"] = "Device_name";
				mapper["device.temperature"] = "Device_temperature";
				mapper["device.type.id"] = "Device_type_id";
				mapper["din"] = "Din";
				mapper["dout"] = "Dout";
				mapper["driver.id"] = "Driver_id";
				mapper["engine.ignition.on.duration"] = "Engine_ignition_on_duration";
				mapper["engine.ignition.state.enum"] = "Engine_ignition_state_enum";
				mapper["ignition.state"] = "Ignition_state";
				mapper["engine.ignition.status"] = "Engine_ignition_status";
				mapper["engine.motorhours"] = "Engine_motorhours";
				mapper["engine.rpm"] = "Engine_rpm";
				mapper["event.enum"] = "Event_enum";
				mapper["event.seqnum"] = "Event_seqnum";
				mapper["external.powersource.status"] = "External_powersource_status";
				mapper["external.powersource.voltage"] = "External_powersource_voltage";
				mapper["extnav.position.speed"] = "Extnav_position_speed";
				mapper["gnss.antenna.status"] = "Gnss_antenna_status";
				mapper["gnss.type"] = "Gnss_type";
				mapper["gnss.vehicle.mileage"] = "Gnss_vehicle_mileage";
				mapper["gprs.status"] = "Gprs_status";
				mapper["gsm.cellid"] = "Gsm_cellid";
				mapper["gsm.jamming.event"] = "Gsm_jamming_event";
				mapper["gsm.lac"] = "Gsm_lac";
				mapper["gsm.mcc"] = "Gsm_mcc";
				mapper["gsm.mnc"] = "Gsm_mnc";
				mapper["gsm.network.status"] = "Gsm_network_status";
				mapper["message.buffered.status"] = "Message_buffered_status";
				mapper["movement.status"] = "Movement_status";
				mapper["overspeeding.event"] = "Overspeeding_event";
				mapper["overspeeding.status"] = "Overspeeding_status";
				mapper["position.altitude"] = "Position_altitude";
				mapper["position.direction"] = "Position_direction";
				mapper["position.hdop"] = "Position_hdop";
				mapper["position.longitude"] = "Position_longitude";
				mapper["position.pdop"] = "Position_pdop";
				mapper["position.speed"] = "Position_speed";
				mapper["power.on.status"] = "Power_on_status";
				mapper["position.latitude"] = "Position_latitude";
				mapper["protocol.id"] = "Protocol_id";
				mapper["server.timestamp"] = "Server_timestamp";
				mapper["sleep.mode.status"] = "Sleep_mode_status";
				mapper["total.idle.seconds"] = "Total_idle_seconds";
				mapper["trip.status"] = "Trip_status";
				mapper["vehicle.mileage"] = "Vehicle_mileage";
				mapper["vehicle.vin"] = "Vehicle_vin";
				mapper["report.code"] = "Report_code";

			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("air.pressure", gxTpr_Air_pressure, false);


			AddObjectProperty("alarm.event", gxTpr_Alarm_event, false);


			AddObjectProperty("antitheft.event", gxTpr_Antitheft_event, false);


			AddObjectProperty("battery.charging.status", gxTpr_Battery_charging_status, false);


			AddObjectProperty("battery.status", gxTpr_Battery_status, false);


			AddObjectProperty("can.ambient.air.temperature", gxTpr_Can_ambient_air_temperature, false);


			AddObjectProperty("can.engine.oil.temperature", gxTpr_Can_engine_oil_temperature, false);


			AddObjectProperty("can.engine.rpm", gxTpr_Can_engine_rpm, false);


			AddObjectProperty("can.engine.temperature", gxTpr_Can_engine_temperature, false);


			AddObjectProperty("can.fuel.consumption", gxTpr_Can_fuel_consumption, false);


			AddObjectProperty("can.intake.air.temperature", gxTpr_Can_intake_air_temperature, false);


			AddObjectProperty("can.maf.air.flow.rate", gxTpr_Can_maf_air_flow_rate, false);


			AddObjectProperty("can.throttle.pedal.level", gxTpr_Can_throttle_pedal_level, false);


			AddObjectProperty("can.vehicle.mileage", gxTpr_Can_vehicle_mileage, false);


			AddObjectProperty("can.vehicle.speed", gxTpr_Can_vehicle_speed, false);


			AddObjectProperty("channel.id", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Channel_id, 16, 0)), false);


			AddObjectProperty("crash_accelerometer_status", gxTpr_Crash_accelerometer_status, false);


			AddObjectProperty("device.id", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Device_id, 16, 0)), false);


			AddObjectProperty("device.model", gxTpr_Device_model, false);


			AddObjectProperty("device.name", gxTpr_Device_name, false);


			AddObjectProperty("device.temperature", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Device_temperature, 16, 0)), false);


			AddObjectProperty("device.type.id", gxTpr_Device_type_id, false);


			AddObjectProperty("din", gxTpr_Din, false);


			AddObjectProperty("dout", gxTpr_Dout, false);


			AddObjectProperty("driver.id", gxTpr_Driver_id, false);


			AddObjectProperty("engine.ignition.on.duration", gxTpr_Engine_ignition_on_duration, false);


			AddObjectProperty("engine.ignition.state.enum", gxTpr_Engine_ignition_state_enum, false);


			AddObjectProperty("ignition.state", gxTpr_Ignition_state, false);


			AddObjectProperty("engine.ignition.status", gxTpr_Engine_ignition_status, false);


			AddObjectProperty("engine.motorhours", gxTpr_Engine_motorhours, false);


			AddObjectProperty("engine.rpm", gxTpr_Engine_rpm, false);


			AddObjectProperty("event.enum", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Event_enum, 16, 0)), false);


			AddObjectProperty("event.seqnum", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Event_seqnum, 16, 0)), false);


			AddObjectProperty("external.powersource.status", gxTpr_External_powersource_status, false);


			AddObjectProperty("external.powersource.voltage", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_External_powersource_voltage, 16, 3)), false);


			AddObjectProperty("extnav.position.speed", gxTpr_Extnav_position_speed, false);


			AddObjectProperty("fuel_level", gxTpr_Fuel_level, false);


			AddObjectProperty("gnss.antenna.status", gxTpr_Gnss_antenna_status, false);


			AddObjectProperty("gnss.type", gxTpr_Gnss_type, false);


			AddObjectProperty("gnss.vehicle.mileage", gxTpr_Gnss_vehicle_mileage, false);


			AddObjectProperty("gprs.status", gxTpr_Gprs_status, false);


			AddObjectProperty("gsm.cellid", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Gsm_cellid, 16, 0)), false);


			AddObjectProperty("gsm.jamming.event", gxTpr_Gsm_jamming_event, false);


			AddObjectProperty("gsm.lac", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Gsm_lac, 16, 0)), false);


			AddObjectProperty("gsm.mcc", gxTpr_Gsm_mcc, false);


			AddObjectProperty("gsm.mnc", gxTpr_Gsm_mnc, false);


			AddObjectProperty("gsm.network.status", gxTpr_Gsm_network_status, false);


			AddObjectProperty("ident", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Ident, 18, 0)), false);


			AddObjectProperty("message.buffered.status", gxTpr_Message_buffered_status, false);


			AddObjectProperty("movement.status", gxTpr_Movement_status, false);


			AddObjectProperty("overspeeding.event", gxTpr_Overspeeding_event, false);


			AddObjectProperty("overspeeding.status", gxTpr_Overspeeding_status, false);


			AddObjectProperty("peer", gxTpr_Peer, false);


			AddObjectProperty("position.altitude", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Position_altitude, 16, 0)), false);


			AddObjectProperty("position.direction", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Position_direction, 16, 0)), false);


			AddObjectProperty("position.hdop", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Position_hdop, 16, 0)), false);


			AddObjectProperty("position.longitude", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Position_longitude, 16, 6)), false);


			AddObjectProperty("position.pdop", gxTpr_Position_pdop, false);


			AddObjectProperty("position.speed", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Position_speed, 16, 0)), false);


			AddObjectProperty("power.on.status", gxTpr_Power_on_status, false);


			AddObjectProperty("position.latitude", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Position_latitude, 16, 6)), false);


			AddObjectProperty("protocol.id", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Protocol_id, 16, 0)), false);


			AddObjectProperty("server.timestamp", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Server_timestamp, 16, 0)), false);


			AddObjectProperty("sleep.mode.status", gxTpr_Sleep_mode_status, false);


			AddObjectProperty("timestamp", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Timestamp, 16, 0)), false);


			AddObjectProperty("total.idle.seconds", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Total_idle_seconds, 16, 0)), false);


			AddObjectProperty("trip.status", gxTpr_Trip_status, false);


			AddObjectProperty("vehicle.mileage", gxTpr_Vehicle_mileage, false);


			AddObjectProperty("vehicle.vin", gxTpr_Vehicle_vin, false);


			AddObjectProperty("report.code", gxTpr_Report_code, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="air_pressure")]
		[XmlElement(ElementName="air_pressure")]
		public long gxTpr_Air_pressure
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Air_pressure; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Air_pressure = value;
				SetDirty("Air_pressure");
			}
		}




		[SoapElement(ElementName="alarm_event")]
		[XmlElement(ElementName="alarm_event")]
		public bool gxTpr_Alarm_event
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Alarm_event; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Alarm_event = value;
				SetDirty("Alarm_event");
			}
		}




		[SoapElement(ElementName="antitheft_event")]
		[XmlElement(ElementName="antitheft_event")]
		public bool gxTpr_Antitheft_event
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Antitheft_event; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Antitheft_event = value;
				SetDirty("Antitheft_event");
			}
		}




		[SoapElement(ElementName="battery_charging_status")]
		[XmlElement(ElementName="battery_charging_status")]
		public bool gxTpr_Battery_charging_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Battery_charging_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Battery_charging_status = value;
				SetDirty("Battery_charging_status");
			}
		}




		[SoapElement(ElementName="battery_status")]
		[XmlElement(ElementName="battery_status")]
		public string gxTpr_Battery_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Battery_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Battery_status = value;
				SetDirty("Battery_status");
			}
		}




		[SoapElement(ElementName="can_ambient_air_temperature")]
		[XmlElement(ElementName="can_ambient_air_temperature")]
		public long gxTpr_Can_ambient_air_temperature
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_ambient_air_temperature; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_ambient_air_temperature = value;
				SetDirty("Can_ambient_air_temperature");
			}
		}




		[SoapElement(ElementName="can_engine_oil_temperature")]
		[XmlElement(ElementName="can_engine_oil_temperature")]
		public long gxTpr_Can_engine_oil_temperature
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_engine_oil_temperature; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_engine_oil_temperature = value;
				SetDirty("Can_engine_oil_temperature");
			}
		}




		[SoapElement(ElementName="can_engine_rpm")]
		[XmlElement(ElementName="can_engine_rpm")]
		public long gxTpr_Can_engine_rpm
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_engine_rpm; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_engine_rpm = value;
				SetDirty("Can_engine_rpm");
			}
		}




		[SoapElement(ElementName="can_engine_temperature")]
		[XmlElement(ElementName="can_engine_temperature")]
		public long gxTpr_Can_engine_temperature
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_engine_temperature; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_engine_temperature = value;
				SetDirty("Can_engine_temperature");
			}
		}




		[SoapElement(ElementName="can_fuel_consumption")]
		[XmlElement(ElementName="can_fuel_consumption")]
		public long gxTpr_Can_fuel_consumption
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_fuel_consumption; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_fuel_consumption = value;
				SetDirty("Can_fuel_consumption");
			}
		}




		[SoapElement(ElementName="can_intake_air_temperature")]
		[XmlElement(ElementName="can_intake_air_temperature")]
		public long gxTpr_Can_intake_air_temperature
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_intake_air_temperature; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_intake_air_temperature = value;
				SetDirty("Can_intake_air_temperature");
			}
		}




		[SoapElement(ElementName="can_maf_air_flow_rate")]
		[XmlElement(ElementName="can_maf_air_flow_rate")]
		public long gxTpr_Can_maf_air_flow_rate
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_maf_air_flow_rate; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_maf_air_flow_rate = value;
				SetDirty("Can_maf_air_flow_rate");
			}
		}




		[SoapElement(ElementName="can_throttle_pedal_level")]
		[XmlElement(ElementName="can_throttle_pedal_level")]
		public long gxTpr_Can_throttle_pedal_level
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_throttle_pedal_level; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_throttle_pedal_level = value;
				SetDirty("Can_throttle_pedal_level");
			}
		}




		[SoapElement(ElementName="can_vehicle_mileage")]
		[XmlElement(ElementName="can_vehicle_mileage")]
		public long gxTpr_Can_vehicle_mileage
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_vehicle_mileage; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_vehicle_mileage = value;
				SetDirty("Can_vehicle_mileage");
			}
		}




		[SoapElement(ElementName="can_vehicle_speed")]
		[XmlElement(ElementName="can_vehicle_speed")]
		public long gxTpr_Can_vehicle_speed
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Can_vehicle_speed; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Can_vehicle_speed = value;
				SetDirty("Can_vehicle_speed");
			}
		}




		[SoapElement(ElementName="channel_id")]
		[XmlElement(ElementName="channel_id")]
		public long gxTpr_Channel_id
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Channel_id; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Channel_id = value;
				SetDirty("Channel_id");
			}
		}




		[SoapElement(ElementName="crash_accelerometer_status")]
		[XmlElement(ElementName="crash_accelerometer_status")]
		public bool gxTpr_Crash_accelerometer_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Crash_accelerometer_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Crash_accelerometer_status = value;
				SetDirty("Crash_accelerometer_status");
			}
		}




		[SoapElement(ElementName="device_id")]
		[XmlElement(ElementName="device_id")]
		public long gxTpr_Device_id
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Device_id; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Device_id = value;
				SetDirty("Device_id");
			}
		}




		[SoapElement(ElementName="device_model")]
		[XmlElement(ElementName="device_model")]
		public string gxTpr_Device_model
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Device_model; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Device_model = value;
				SetDirty("Device_model");
			}
		}




		[SoapElement(ElementName="device_name")]
		[XmlElement(ElementName="device_name")]
		public string gxTpr_Device_name
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Device_name; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Device_name = value;
				SetDirty("Device_name");
			}
		}




		[SoapElement(ElementName="device_temperature")]
		[XmlElement(ElementName="device_temperature")]
		public long gxTpr_Device_temperature
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Device_temperature; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Device_temperature = value;
				SetDirty("Device_temperature");
			}
		}




		[SoapElement(ElementName="device_type_id")]
		[XmlElement(ElementName="device_type_id")]
		public long gxTpr_Device_type_id
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Device_type_id; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Device_type_id = value;
				SetDirty("Device_type_id");
			}
		}




		[SoapElement(ElementName="din")]
		[XmlElement(ElementName="din")]
		public long gxTpr_Din
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Din; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Din = value;
				SetDirty("Din");
			}
		}




		[SoapElement(ElementName="dout")]
		[XmlElement(ElementName="dout")]
		public long gxTpr_Dout
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Dout; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Dout = value;
				SetDirty("Dout");
			}
		}




		[SoapElement(ElementName="driver_id")]
		[XmlElement(ElementName="driver_id")]
		public string gxTpr_Driver_id
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Driver_id; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Driver_id = value;
				SetDirty("Driver_id");
			}
		}




		[SoapElement(ElementName="engine_ignition_on_duration")]
		[XmlElement(ElementName="engine_ignition_on_duration")]
		public long gxTpr_Engine_ignition_on_duration
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Engine_ignition_on_duration; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Engine_ignition_on_duration = value;
				SetDirty("Engine_ignition_on_duration");
			}
		}




		[SoapElement(ElementName="engine_ignition_state_enum")]
		[XmlElement(ElementName="engine_ignition_state_enum")]
		public long gxTpr_Engine_ignition_state_enum
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Engine_ignition_state_enum; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Engine_ignition_state_enum = value;
				SetDirty("Engine_ignition_state_enum");
			}
		}




		[SoapElement(ElementName="ignition_state")]
		[XmlElement(ElementName="ignition_state")]
		public short gxTpr_Ignition_state
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Ignition_state; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Ignition_state = value;
				SetDirty("Ignition_state");
			}
		}




		[SoapElement(ElementName="engine_ignition_status")]
		[XmlElement(ElementName="engine_ignition_status")]
		public bool gxTpr_Engine_ignition_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Engine_ignition_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Engine_ignition_status = value;
				SetDirty("Engine_ignition_status");
			}
		}




		[SoapElement(ElementName="engine_motorhours")]
		[XmlElement(ElementName="engine_motorhours")]
		public long gxTpr_Engine_motorhours
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Engine_motorhours; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Engine_motorhours = value;
				SetDirty("Engine_motorhours");
			}
		}




		[SoapElement(ElementName="engine_rpm")]
		[XmlElement(ElementName="engine_rpm")]
		public long gxTpr_Engine_rpm
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Engine_rpm; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Engine_rpm = value;
				SetDirty("Engine_rpm");
			}
		}




		[SoapElement(ElementName="event_enum")]
		[XmlElement(ElementName="event_enum")]
		public long gxTpr_Event_enum
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Event_enum; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Event_enum = value;
				SetDirty("Event_enum");
			}
		}




		[SoapElement(ElementName="event_seqnum")]
		[XmlElement(ElementName="event_seqnum")]
		public long gxTpr_Event_seqnum
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Event_seqnum; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Event_seqnum = value;
				SetDirty("Event_seqnum");
			}
		}




		[SoapElement(ElementName="external_powersource_status")]
		[XmlElement(ElementName="external_powersource_status")]
		public bool gxTpr_External_powersource_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_External_powersource_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_External_powersource_status = value;
				SetDirty("External_powersource_status");
			}
		}



		[SoapElement(ElementName="external_powersource_voltage")]
		[XmlElement(ElementName="external_powersource_voltage")]
		public string gxTpr_External_powersource_voltage_double
		{
			get {
				return Convert.ToString(gxTv_SdtChannelMessages_resultItem_External_powersource_voltage, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtChannelMessages_resultItem_External_powersource_voltage = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_External_powersource_voltage
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_External_powersource_voltage; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_External_powersource_voltage = value;
				SetDirty("External_powersource_voltage");
			}
		}




		[SoapElement(ElementName="extnav_position_speed")]
		[XmlElement(ElementName="extnav_position_speed")]
		public long gxTpr_Extnav_position_speed
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Extnav_position_speed; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Extnav_position_speed = value;
				SetDirty("Extnav_position_speed");
			}
		}




		[SoapElement(ElementName="fuel_level")]
		[XmlElement(ElementName="fuel_level")]
		public long gxTpr_Fuel_level
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Fuel_level; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Fuel_level = value;
				SetDirty("Fuel_level");
			}
		}




		[SoapElement(ElementName="gnss_antenna_status")]
		[XmlElement(ElementName="gnss_antenna_status")]
		public bool gxTpr_Gnss_antenna_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gnss_antenna_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gnss_antenna_status = value;
				SetDirty("Gnss_antenna_status");
			}
		}




		[SoapElement(ElementName="gnss_type")]
		[XmlElement(ElementName="gnss_type")]
		public string gxTpr_Gnss_type
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gnss_type; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gnss_type = value;
				SetDirty("Gnss_type");
			}
		}




		[SoapElement(ElementName="gnss_vehicle_mileage")]
		[XmlElement(ElementName="gnss_vehicle_mileage")]
		public long gxTpr_Gnss_vehicle_mileage
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gnss_vehicle_mileage; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gnss_vehicle_mileage = value;
				SetDirty("Gnss_vehicle_mileage");
			}
		}




		[SoapElement(ElementName="gprs_status")]
		[XmlElement(ElementName="gprs_status")]
		public bool gxTpr_Gprs_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gprs_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gprs_status = value;
				SetDirty("Gprs_status");
			}
		}




		[SoapElement(ElementName="gsm_cellid")]
		[XmlElement(ElementName="gsm_cellid")]
		public long gxTpr_Gsm_cellid
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gsm_cellid; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gsm_cellid = value;
				SetDirty("Gsm_cellid");
			}
		}




		[SoapElement(ElementName="gsm_jamming_event")]
		[XmlElement(ElementName="gsm_jamming_event")]
		public bool gxTpr_Gsm_jamming_event
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gsm_jamming_event; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gsm_jamming_event = value;
				SetDirty("Gsm_jamming_event");
			}
		}




		[SoapElement(ElementName="gsm_lac")]
		[XmlElement(ElementName="gsm_lac")]
		public long gxTpr_Gsm_lac
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gsm_lac; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gsm_lac = value;
				SetDirty("Gsm_lac");
			}
		}




		[SoapElement(ElementName="gsm_mcc")]
		[XmlElement(ElementName="gsm_mcc")]
		public string gxTpr_Gsm_mcc
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gsm_mcc; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gsm_mcc = value;
				SetDirty("Gsm_mcc");
			}
		}




		[SoapElement(ElementName="gsm_mnc")]
		[XmlElement(ElementName="gsm_mnc")]
		public string gxTpr_Gsm_mnc
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gsm_mnc; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gsm_mnc = value;
				SetDirty("Gsm_mnc");
			}
		}




		[SoapElement(ElementName="gsm_network_status")]
		[XmlElement(ElementName="gsm_network_status")]
		public bool gxTpr_Gsm_network_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Gsm_network_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Gsm_network_status = value;
				SetDirty("Gsm_network_status");
			}
		}




		[SoapElement(ElementName="ident")]
		[XmlElement(ElementName="ident")]
		public long gxTpr_Ident
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Ident; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Ident = value;
				SetDirty("Ident");
			}
		}




		[SoapElement(ElementName="message_buffered_status")]
		[XmlElement(ElementName="message_buffered_status")]
		public bool gxTpr_Message_buffered_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Message_buffered_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Message_buffered_status = value;
				SetDirty("Message_buffered_status");
			}
		}




		[SoapElement(ElementName="movement_status")]
		[XmlElement(ElementName="movement_status")]
		public bool gxTpr_Movement_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Movement_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Movement_status = value;
				SetDirty("Movement_status");
			}
		}




		[SoapElement(ElementName="overspeeding_event")]
		[XmlElement(ElementName="overspeeding_event")]
		public bool gxTpr_Overspeeding_event
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Overspeeding_event; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Overspeeding_event = value;
				SetDirty("Overspeeding_event");
			}
		}




		[SoapElement(ElementName="overspeeding_status")]
		[XmlElement(ElementName="overspeeding_status")]
		public bool gxTpr_Overspeeding_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Overspeeding_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Overspeeding_status = value;
				SetDirty("Overspeeding_status");
			}
		}




		[SoapElement(ElementName="peer")]
		[XmlElement(ElementName="peer")]
		public string gxTpr_Peer
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Peer; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Peer = value;
				SetDirty("Peer");
			}
		}




		[SoapElement(ElementName="position_altitude")]
		[XmlElement(ElementName="position_altitude")]
		public long gxTpr_Position_altitude
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Position_altitude; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Position_altitude = value;
				SetDirty("Position_altitude");
			}
		}




		[SoapElement(ElementName="position_direction")]
		[XmlElement(ElementName="position_direction")]
		public long gxTpr_Position_direction
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Position_direction; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Position_direction = value;
				SetDirty("Position_direction");
			}
		}




		[SoapElement(ElementName="position_hdop")]
		[XmlElement(ElementName="position_hdop")]
		public long gxTpr_Position_hdop
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Position_hdop; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Position_hdop = value;
				SetDirty("Position_hdop");
			}
		}



		[SoapElement(ElementName="position_longitude")]
		[XmlElement(ElementName="position_longitude")]
		public string gxTpr_Position_longitude_double
		{
			get {
				return Convert.ToString(gxTv_SdtChannelMessages_resultItem_Position_longitude, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtChannelMessages_resultItem_Position_longitude = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Position_longitude
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Position_longitude; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Position_longitude = value;
				SetDirty("Position_longitude");
			}
		}




		[SoapElement(ElementName="position_pdop")]
		[XmlElement(ElementName="position_pdop")]
		public long gxTpr_Position_pdop
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Position_pdop; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Position_pdop = value;
				SetDirty("Position_pdop");
			}
		}




		[SoapElement(ElementName="position_speed")]
		[XmlElement(ElementName="position_speed")]
		public long gxTpr_Position_speed
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Position_speed; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Position_speed = value;
				SetDirty("Position_speed");
			}
		}




		[SoapElement(ElementName="power_on_status")]
		[XmlElement(ElementName="power_on_status")]
		public bool gxTpr_Power_on_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Power_on_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Power_on_status = value;
				SetDirty("Power_on_status");
			}
		}



		[SoapElement(ElementName="position_latitude")]
		[XmlElement(ElementName="position_latitude")]
		public string gxTpr_Position_latitude_double
		{
			get {
				return Convert.ToString(gxTv_SdtChannelMessages_resultItem_Position_latitude, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtChannelMessages_resultItem_Position_latitude = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Position_latitude
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Position_latitude; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Position_latitude = value;
				SetDirty("Position_latitude");
			}
		}




		[SoapElement(ElementName="protocol_id")]
		[XmlElement(ElementName="protocol_id")]
		public long gxTpr_Protocol_id
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Protocol_id; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Protocol_id = value;
				SetDirty("Protocol_id");
			}
		}




		[SoapElement(ElementName="server_timestamp")]
		[XmlElement(ElementName="server_timestamp")]
		public long gxTpr_Server_timestamp
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Server_timestamp; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Server_timestamp = value;
				SetDirty("Server_timestamp");
			}
		}




		[SoapElement(ElementName="sleep_mode_status")]
		[XmlElement(ElementName="sleep_mode_status")]
		public bool gxTpr_Sleep_mode_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Sleep_mode_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Sleep_mode_status = value;
				SetDirty("Sleep_mode_status");
			}
		}




		[SoapElement(ElementName="timestamp")]
		[XmlElement(ElementName="timestamp")]
		public long gxTpr_Timestamp
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Timestamp; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Timestamp = value;
				SetDirty("Timestamp");
			}
		}




		[SoapElement(ElementName="total_idle_seconds")]
		[XmlElement(ElementName="total_idle_seconds")]
		public long gxTpr_Total_idle_seconds
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Total_idle_seconds; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Total_idle_seconds = value;
				SetDirty("Total_idle_seconds");
			}
		}




		[SoapElement(ElementName="trip_status")]
		[XmlElement(ElementName="trip_status")]
		public bool gxTpr_Trip_status
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Trip_status; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Trip_status = value;
				SetDirty("Trip_status");
			}
		}




		[SoapElement(ElementName="vehicle_mileage")]
		[XmlElement(ElementName="vehicle_mileage")]
		public long gxTpr_Vehicle_mileage
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Vehicle_mileage; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Vehicle_mileage = value;
				SetDirty("Vehicle_mileage");
			}
		}




		[SoapElement(ElementName="vehicle_vin")]
		[XmlElement(ElementName="vehicle_vin")]
		public string gxTpr_Vehicle_vin
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Vehicle_vin; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Vehicle_vin = value;
				SetDirty("Vehicle_vin");
			}
		}




		[SoapElement(ElementName="report_code")]
		[XmlElement(ElementName="report_code")]
		public string gxTpr_Report_code
		{
			get { 
				return gxTv_SdtChannelMessages_resultItem_Report_code; 
			}
			set { 
				gxTv_SdtChannelMessages_resultItem_Report_code = value;
				SetDirty("Report_code");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtChannelMessages_resultItem_Battery_status = "";













			gxTv_SdtChannelMessages_resultItem_Device_model = "";
			gxTv_SdtChannelMessages_resultItem_Device_name = "";




			gxTv_SdtChannelMessages_resultItem_Driver_id = "";













			gxTv_SdtChannelMessages_resultItem_Gnss_type = "";





			gxTv_SdtChannelMessages_resultItem_Gsm_mcc = "";
			gxTv_SdtChannelMessages_resultItem_Gsm_mnc = "";






			gxTv_SdtChannelMessages_resultItem_Peer = "";















			gxTv_SdtChannelMessages_resultItem_Vehicle_vin = "";
			gxTv_SdtChannelMessages_resultItem_Report_code = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtChannelMessages_resultItem_Air_pressure;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Alarm_event;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Antitheft_event;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Battery_charging_status;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Battery_status;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_ambient_air_temperature;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_engine_oil_temperature;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_engine_rpm;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_engine_temperature;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_fuel_consumption;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_intake_air_temperature;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_maf_air_flow_rate;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_throttle_pedal_level;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_vehicle_mileage;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Can_vehicle_speed;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Channel_id;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Crash_accelerometer_status;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Device_id;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Device_model;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Device_name;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Device_temperature;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Device_type_id;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Din;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Dout;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Driver_id;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Engine_ignition_on_duration;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Engine_ignition_state_enum;
		 

		protected short gxTv_SdtChannelMessages_resultItem_Ignition_state;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Engine_ignition_status;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Engine_motorhours;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Engine_rpm;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Event_enum;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Event_seqnum;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_External_powersource_status;
		 

		protected decimal gxTv_SdtChannelMessages_resultItem_External_powersource_voltage;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Extnav_position_speed;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Fuel_level;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Gnss_antenna_status;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Gnss_type;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Gnss_vehicle_mileage;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Gprs_status;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Gsm_cellid;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Gsm_jamming_event;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Gsm_lac;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Gsm_mcc;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Gsm_mnc;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Gsm_network_status;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Ident;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Message_buffered_status;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Movement_status;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Overspeeding_event;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Overspeeding_status;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Peer;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Position_altitude;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Position_direction;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Position_hdop;
		 

		protected decimal gxTv_SdtChannelMessages_resultItem_Position_longitude;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Position_pdop;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Position_speed;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Power_on_status;
		 

		protected decimal gxTv_SdtChannelMessages_resultItem_Position_latitude;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Protocol_id;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Server_timestamp;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Sleep_mode_status;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Timestamp;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Total_idle_seconds;
		 

		protected bool gxTv_SdtChannelMessages_resultItem_Trip_status;
		 

		protected long gxTv_SdtChannelMessages_resultItem_Vehicle_mileage;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Vehicle_vin;
		 

		protected string gxTv_SdtChannelMessages_resultItem_Report_code;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"ChannelMessages.resultItem", Namespace="RastreamentoTCC")]
	public class SdtChannelMessages_resultItem_RESTInterface : GxGenericCollectionItem<SdtChannelMessages_resultItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtChannelMessages_resultItem_RESTInterface( ) : base()
		{
		}

		public SdtChannelMessages_resultItem_RESTInterface( SdtChannelMessages_resultItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="air.pressure", Order=0)]
		public  string gxTpr_Air_pressure
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Air_pressure, 10, 0));

			}
			set { 
				sdt.gxTpr_Air_pressure = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="alarm.event", Order=1)]
		public bool gxTpr_Alarm_event
		{
			get { 
				return sdt.gxTpr_Alarm_event;

			}
			set { 
				sdt.gxTpr_Alarm_event = value;
			}
		}

		[DataMember(Name="antitheft.event", Order=2)]
		public bool gxTpr_Antitheft_event
		{
			get { 
				return sdt.gxTpr_Antitheft_event;

			}
			set { 
				sdt.gxTpr_Antitheft_event = value;
			}
		}

		[DataMember(Name="battery.charging.status", Order=3)]
		public bool gxTpr_Battery_charging_status
		{
			get { 
				return sdt.gxTpr_Battery_charging_status;

			}
			set { 
				sdt.gxTpr_Battery_charging_status = value;
			}
		}

		[DataMember(Name="battery.status", Order=4)]
		public  string gxTpr_Battery_status
		{
			get { 
				return sdt.gxTpr_Battery_status;

			}
			set { 
				 sdt.gxTpr_Battery_status = value;
			}
		}

		[DataMember(Name="can.ambient.air.temperature", Order=5)]
		public  string gxTpr_Can_ambient_air_temperature
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_ambient_air_temperature, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_ambient_air_temperature = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.engine.oil.temperature", Order=6)]
		public  string gxTpr_Can_engine_oil_temperature
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_engine_oil_temperature, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_engine_oil_temperature = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.engine.rpm", Order=7)]
		public  string gxTpr_Can_engine_rpm
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_engine_rpm, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_engine_rpm = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.engine.temperature", Order=8)]
		public  string gxTpr_Can_engine_temperature
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_engine_temperature, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_engine_temperature = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.fuel.consumption", Order=9)]
		public  string gxTpr_Can_fuel_consumption
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_fuel_consumption, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_fuel_consumption = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.intake.air.temperature", Order=10)]
		public  string gxTpr_Can_intake_air_temperature
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_intake_air_temperature, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_intake_air_temperature = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.maf.air.flow.rate", Order=11)]
		public  string gxTpr_Can_maf_air_flow_rate
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_maf_air_flow_rate, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_maf_air_flow_rate = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.throttle.pedal.level", Order=12)]
		public  string gxTpr_Can_throttle_pedal_level
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_throttle_pedal_level, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_throttle_pedal_level = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.vehicle.mileage", Order=13)]
		public  string gxTpr_Can_vehicle_mileage
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_vehicle_mileage, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_vehicle_mileage = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="can.vehicle.speed", Order=14)]
		public  string gxTpr_Can_vehicle_speed
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Can_vehicle_speed, 10, 0));

			}
			set { 
				sdt.gxTpr_Can_vehicle_speed = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="channel.id", Order=15)]
		public  string gxTpr_Channel_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Channel_id, 16, 0));

			}
			set { 
				sdt.gxTpr_Channel_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="crash_accelerometer_status", Order=16)]
		public bool gxTpr_Crash_accelerometer_status
		{
			get { 
				return sdt.gxTpr_Crash_accelerometer_status;

			}
			set { 
				sdt.gxTpr_Crash_accelerometer_status = value;
			}
		}

		[DataMember(Name="device.id", Order=17)]
		public  string gxTpr_Device_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Device_id, 16, 0));

			}
			set { 
				sdt.gxTpr_Device_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="device.model", Order=18)]
		public  string gxTpr_Device_model
		{
			get { 
				return sdt.gxTpr_Device_model;

			}
			set { 
				 sdt.gxTpr_Device_model = value;
			}
		}

		[DataMember(Name="device.name", Order=19)]
		public  string gxTpr_Device_name
		{
			get { 
				return sdt.gxTpr_Device_name;

			}
			set { 
				 sdt.gxTpr_Device_name = value;
			}
		}

		[DataMember(Name="device.temperature", Order=20)]
		public  string gxTpr_Device_temperature
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Device_temperature, 16, 0));

			}
			set { 
				sdt.gxTpr_Device_temperature = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="device.type.id", Order=21)]
		public  string gxTpr_Device_type_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Device_type_id, 10, 0));

			}
			set { 
				sdt.gxTpr_Device_type_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="din", Order=22)]
		public  string gxTpr_Din
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Din, 10, 0));

			}
			set { 
				sdt.gxTpr_Din = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="dout", Order=23)]
		public  string gxTpr_Dout
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Dout, 10, 0));

			}
			set { 
				sdt.gxTpr_Dout = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="driver.id", Order=24)]
		public  string gxTpr_Driver_id
		{
			get { 
				return sdt.gxTpr_Driver_id;

			}
			set { 
				 sdt.gxTpr_Driver_id = value;
			}
		}

		[DataMember(Name="engine.ignition.on.duration", Order=25)]
		public  string gxTpr_Engine_ignition_on_duration
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Engine_ignition_on_duration, 15, 0));

			}
			set { 
				sdt.gxTpr_Engine_ignition_on_duration = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="engine.ignition.state.enum", Order=26)]
		public  string gxTpr_Engine_ignition_state_enum
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Engine_ignition_state_enum, 10, 0));

			}
			set { 
				sdt.gxTpr_Engine_ignition_state_enum = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ignition.state", Order=27)]
		public short gxTpr_Ignition_state
		{
			get { 
				return sdt.gxTpr_Ignition_state;

			}
			set { 
				sdt.gxTpr_Ignition_state = value;
			}
		}

		[DataMember(Name="engine.ignition.status", Order=28)]
		public bool gxTpr_Engine_ignition_status
		{
			get { 
				return sdt.gxTpr_Engine_ignition_status;

			}
			set { 
				sdt.gxTpr_Engine_ignition_status = value;
			}
		}

		[DataMember(Name="engine.motorhours", Order=29)]
		public  string gxTpr_Engine_motorhours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Engine_motorhours, 15, 0));

			}
			set { 
				sdt.gxTpr_Engine_motorhours = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="engine.rpm", Order=30)]
		public  string gxTpr_Engine_rpm
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Engine_rpm, 10, 0));

			}
			set { 
				sdt.gxTpr_Engine_rpm = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="event.enum", Order=31)]
		public  string gxTpr_Event_enum
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Event_enum, 16, 0));

			}
			set { 
				sdt.gxTpr_Event_enum = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="event.seqnum", Order=32)]
		public  string gxTpr_Event_seqnum
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Event_seqnum, 16, 0));

			}
			set { 
				sdt.gxTpr_Event_seqnum = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="external.powersource.status", Order=33)]
		public bool gxTpr_External_powersource_status
		{
			get { 
				return sdt.gxTpr_External_powersource_status;

			}
			set { 
				sdt.gxTpr_External_powersource_status = value;
			}
		}

		[DataMember(Name="external.powersource.voltage", Order=34)]
		public  string gxTpr_External_powersource_voltage
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_External_powersource_voltage, 16, 3));

			}
			set { 
				sdt.gxTpr_External_powersource_voltage =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="extnav.position.speed", Order=35)]
		public  string gxTpr_Extnav_position_speed
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Extnav_position_speed, 10, 0));

			}
			set { 
				sdt.gxTpr_Extnav_position_speed = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="fuel_level", Order=36)]
		public  string gxTpr_Fuel_level
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Fuel_level, 10, 0));

			}
			set { 
				sdt.gxTpr_Fuel_level = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="gnss.antenna.status", Order=37)]
		public bool gxTpr_Gnss_antenna_status
		{
			get { 
				return sdt.gxTpr_Gnss_antenna_status;

			}
			set { 
				sdt.gxTpr_Gnss_antenna_status = value;
			}
		}

		[DataMember(Name="gnss.type", Order=38)]
		public  string gxTpr_Gnss_type
		{
			get { 
				return sdt.gxTpr_Gnss_type;

			}
			set { 
				 sdt.gxTpr_Gnss_type = value;
			}
		}

		[DataMember(Name="gnss.vehicle.mileage", Order=39)]
		public  string gxTpr_Gnss_vehicle_mileage
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Gnss_vehicle_mileage, 10, 0));

			}
			set { 
				sdt.gxTpr_Gnss_vehicle_mileage = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="gprs.status", Order=40)]
		public bool gxTpr_Gprs_status
		{
			get { 
				return sdt.gxTpr_Gprs_status;

			}
			set { 
				sdt.gxTpr_Gprs_status = value;
			}
		}

		[DataMember(Name="gsm.cellid", Order=41)]
		public  string gxTpr_Gsm_cellid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Gsm_cellid, 16, 0));

			}
			set { 
				sdt.gxTpr_Gsm_cellid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="gsm.jamming.event", Order=42)]
		public bool gxTpr_Gsm_jamming_event
		{
			get { 
				return sdt.gxTpr_Gsm_jamming_event;

			}
			set { 
				sdt.gxTpr_Gsm_jamming_event = value;
			}
		}

		[DataMember(Name="gsm.lac", Order=43)]
		public  string gxTpr_Gsm_lac
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Gsm_lac, 16, 0));

			}
			set { 
				sdt.gxTpr_Gsm_lac = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="gsm.mcc", Order=44)]
		public  string gxTpr_Gsm_mcc
		{
			get { 
				return sdt.gxTpr_Gsm_mcc;

			}
			set { 
				 sdt.gxTpr_Gsm_mcc = value;
			}
		}

		[DataMember(Name="gsm.mnc", Order=45)]
		public  string gxTpr_Gsm_mnc
		{
			get { 
				return sdt.gxTpr_Gsm_mnc;

			}
			set { 
				 sdt.gxTpr_Gsm_mnc = value;
			}
		}

		[DataMember(Name="gsm.network.status", Order=46)]
		public bool gxTpr_Gsm_network_status
		{
			get { 
				return sdt.gxTpr_Gsm_network_status;

			}
			set { 
				sdt.gxTpr_Gsm_network_status = value;
			}
		}

		[DataMember(Name="ident", Order=47)]
		public  string gxTpr_Ident
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ident, 18, 0));

			}
			set { 
				sdt.gxTpr_Ident = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="message.buffered.status", Order=48)]
		public bool gxTpr_Message_buffered_status
		{
			get { 
				return sdt.gxTpr_Message_buffered_status;

			}
			set { 
				sdt.gxTpr_Message_buffered_status = value;
			}
		}

		[DataMember(Name="movement.status", Order=49)]
		public bool gxTpr_Movement_status
		{
			get { 
				return sdt.gxTpr_Movement_status;

			}
			set { 
				sdt.gxTpr_Movement_status = value;
			}
		}

		[DataMember(Name="overspeeding.event", Order=50)]
		public bool gxTpr_Overspeeding_event
		{
			get { 
				return sdt.gxTpr_Overspeeding_event;

			}
			set { 
				sdt.gxTpr_Overspeeding_event = value;
			}
		}

		[DataMember(Name="overspeeding.status", Order=51)]
		public bool gxTpr_Overspeeding_status
		{
			get { 
				return sdt.gxTpr_Overspeeding_status;

			}
			set { 
				sdt.gxTpr_Overspeeding_status = value;
			}
		}

		[DataMember(Name="peer", Order=52)]
		public  string gxTpr_Peer
		{
			get { 
				return sdt.gxTpr_Peer;

			}
			set { 
				 sdt.gxTpr_Peer = value;
			}
		}

		[DataMember(Name="position.altitude", Order=53)]
		public  string gxTpr_Position_altitude
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Position_altitude, 16, 0));

			}
			set { 
				sdt.gxTpr_Position_altitude = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="position.direction", Order=54)]
		public  string gxTpr_Position_direction
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Position_direction, 16, 0));

			}
			set { 
				sdt.gxTpr_Position_direction = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="position.hdop", Order=55)]
		public  string gxTpr_Position_hdop
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Position_hdop, 16, 0));

			}
			set { 
				sdt.gxTpr_Position_hdop = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="position.longitude", Order=56)]
		public  string gxTpr_Position_longitude
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Position_longitude, 16, 6));

			}
			set { 
				sdt.gxTpr_Position_longitude =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="position.pdop", Order=57)]
		public  string gxTpr_Position_pdop
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Position_pdop, 10, 0));

			}
			set { 
				sdt.gxTpr_Position_pdop = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="position.speed", Order=58)]
		public  string gxTpr_Position_speed
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Position_speed, 16, 0));

			}
			set { 
				sdt.gxTpr_Position_speed = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="power.on.status", Order=59)]
		public bool gxTpr_Power_on_status
		{
			get { 
				return sdt.gxTpr_Power_on_status;

			}
			set { 
				sdt.gxTpr_Power_on_status = value;
			}
		}

		[DataMember(Name="position.latitude", Order=60)]
		public  string gxTpr_Position_latitude
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Position_latitude, 16, 6));

			}
			set { 
				sdt.gxTpr_Position_latitude =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="protocol.id", Order=61)]
		public  string gxTpr_Protocol_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Protocol_id, 16, 0));

			}
			set { 
				sdt.gxTpr_Protocol_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="server.timestamp", Order=62)]
		public  string gxTpr_Server_timestamp
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Server_timestamp, 16, 0));

			}
			set { 
				sdt.gxTpr_Server_timestamp = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="sleep.mode.status", Order=63)]
		public bool gxTpr_Sleep_mode_status
		{
			get { 
				return sdt.gxTpr_Sleep_mode_status;

			}
			set { 
				sdt.gxTpr_Sleep_mode_status = value;
			}
		}

		[DataMember(Name="timestamp", Order=64)]
		public  string gxTpr_Timestamp
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Timestamp, 16, 0));

			}
			set { 
				sdt.gxTpr_Timestamp = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="total.idle.seconds", Order=65)]
		public  string gxTpr_Total_idle_seconds
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Total_idle_seconds, 16, 0));

			}
			set { 
				sdt.gxTpr_Total_idle_seconds = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="trip.status", Order=66)]
		public bool gxTpr_Trip_status
		{
			get { 
				return sdt.gxTpr_Trip_status;

			}
			set { 
				sdt.gxTpr_Trip_status = value;
			}
		}

		[DataMember(Name="vehicle.mileage", Order=67)]
		public  string gxTpr_Vehicle_mileage
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Vehicle_mileage, 10, 0));

			}
			set { 
				sdt.gxTpr_Vehicle_mileage = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="vehicle.vin", Order=68)]
		public  string gxTpr_Vehicle_vin
		{
			get { 
				return sdt.gxTpr_Vehicle_vin;

			}
			set { 
				 sdt.gxTpr_Vehicle_vin = value;
			}
		}

		[DataMember(Name="report.code", Order=69)]
		public  string gxTpr_Report_code
		{
			get { 
				return sdt.gxTpr_Report_code;

			}
			set { 
				 sdt.gxTpr_Report_code = value;
			}
		}


		#endregion

		public SdtChannelMessages_resultItem sdt
		{
			get { 
				return (SdtChannelMessages_resultItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtChannelMessages_resultItem() ;
			}
		}
	}
	#endregion
}
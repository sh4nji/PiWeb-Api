﻿#region copyright
/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss IMT (IZfM Dresden)                   */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2015                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */
#endregion

namespace DataService
{
	#region using

	using System;
	using Newtonsoft.Json;

	#endregion

	/// <summary>
	/// This class contains general information about the DataService, like its current version, the server name etc.
	/// </summary>
	public class ServiceInformation
	{
		#region properties

		/// <summary>
		/// Gets or sets the server name.
		/// </summary>
		public string ServerName { get; set; }

		/// <summary>
		/// Gets or sets the server version.
		/// </summary>
		public string Version { get; set; }

		/// <summary>
		/// Gets or sets whether the server has security enabled.
		/// </summary>
		public bool SecurityEnabled { get; set; }

		/// <summary>
		/// Gets or sets the servers edition.
		/// </summary>
		public string Edition { get; set; }

		/// <summary>
		/// Gets or sets the web service major interface version.
		/// </summary>
		public string VersionWsdlMajor { get; set; }

		/// <summary>
		/// Gets or sets the minor web service interface version.
		/// </summary>
		public string VersionWsdlMinor { get; set; }

		/// <summary>
		/// Gets or sets the number of parts that currently exist in the server. This number is just an approximation.
		/// </summary>
		public int PartCount { get; set; }

		/// <summary>
		/// Gets or sets the number of characteristics that currently exist in the server. This number is just an approximation.
		/// </summary>
		public int CharacteristicCount { get; set; }

		/// <summary>
		/// Gets or sets the number of measurements that currently exist in the server. This number is just an approximation.
		/// </summary>
		public int MeasurementCount { get; set; }

		/// <summary>
		/// Gets or sets the number of values that currently exist in the server. This number is just an approximation.
		/// </summary>
		public int ValueCount { get; set; }

		/// <summary>
		/// Gets or sets a list of features that are supported by the server.
		/// </summary>
		public string[] FeatureList { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of the last inspection plan modification accross the whole server.
		/// </summary>
		public DateTime InspectionPlanTimestamp { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of the last measurement modification accross the whole server.
		/// </summary>
		public DateTime MeasurementTimestamp { get; set; }

		/// <summary>
		/// Gets or sets the timestamp for the last modification of the server configuration.
		/// </summary>
		public DateTime ConfigurationTimestamp { get; set; }

		/// <summary>
		/// Convenience property that combines <see cref="VersionWsdlMajor"/> and <see cref="VersionWsdlMinor"/>.
		/// </summary>
		[JsonIgnore]
		public Version WsdlVersion
		{
			get 
			{
				if( !string.IsNullOrEmpty( VersionWsdlMajor ) && !string.IsNullOrEmpty( VersionWsdlMinor ) )
					return new Version( VersionWsdlMajor + "." + VersionWsdlMinor );

				return new Version( 0, 0 );
			}
		}

		#endregion

		#region methods

		/// <summary>
		/// Overridden <see cref="System.Object.ToString"/> method.
		/// </summary>
		public override string ToString()
		{
			if( Version == null )
				return "";

			var result = Edition + " Edition, Version " + Version;
			if( !string.IsNullOrEmpty( VersionWsdlMajor ) )
				result += " (WSDL: " + VersionWsdlMajor + "." + VersionWsdlMinor + ")";

			return result;
		}

		#endregion
	}
}
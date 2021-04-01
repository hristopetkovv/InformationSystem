using System.Runtime.Serialization;

namespace InformationSystemServer.Services.ViewModels.ReCaptcha
{
	[DataContract]
	public class GResponseModel
	{
		[DataMember]
		public bool success { get; set; }
		[DataMember]
		public string challenge_ts { get; set; }
		[DataMember]
		public string hostname { get; set; }

		//Could create a child object for 
		//error-codes
		[DataMember(Name = "error-codes")]
		public string[] error_codes { get; set; }
	}
}

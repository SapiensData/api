﻿using SoftFluent.ComponentModel.DataAnnotations;

namespace SapiensDataAPI.Models
{
	public class EncryptionTest
	{
		
		public required int Id { get; set; }

		public required string Street { get; set; }

		[Encrypted]
		public required byte[] StreetEncrypted { get; set; }

	}
}

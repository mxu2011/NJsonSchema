using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NJsonSchema.CodeGeneration.CSharp;
using NJsonSchema.Generation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NJsonSchema.CodeGeneration.Tests.CSharp
{
    public class MxuTests
    {
        [Fact]
        public async Task ShouldGenerateBankResultType()
        {
            // looks like the 
            //// Arrange
            var json =
            @"{
  ""$schema"": ""http://json-schema.org/draft-07/schema#"",
  ""$id"": ""http://ia.com/payment.schema.json"",
  ""title"": ""Dealer Service Payment CMF"",
  ""description"": ""Dealer Service Payment CMF"",
  ""type"": ""object"",
  ""properties"": {
    ""id"": {
      ""description"": ""must be a globally unique identifier for this one specific event. UUID will be used"",
      ""type"": ""string"",
      ""minLength"": 36,
      ""maxLength"": 36
    },
    ""specversion"": {
      ""description"": ""Cloud Event Specification Version"",
      ""type"": ""string"",
      ""minLength"": 1,
      ""maxLength"": 5
    },
    ""type"": {
      ""description"": ""Unique ID of the message type. Use the functional name of the message (event or command), prefixed with the LOB code"",
      ""type"": ""string"",
      ""enum"": [
        ""DS.PaymentApproved"",
        ""DS.PaymentCancelled""
      ]
    },
    ""version"": {
      ""description"": ""Version of the message type"",
      ""type"": ""string"",
      ""minLength"": 1,
      ""maxLength"": 5
    },
    ""subject"": {
      ""description"": ""Identifies the subject of the message"",
      ""type"": ""string"",
      ""minLength"": 5,
      ""maxLength"": 30
    },
    ""time"": {
      ""description"": ""Indicates when this event happens. Must be formatted by using the standard RFC3339."",
      ""type"": ""string"",
      ""format"": ""date""
    },
    ""source"": {
      ""description"": ""Indicates where the event is from"",
      ""type"": ""string"",
      ""enum"": [
        ""DS/UNIFI/EFT"",
        ""DS/UN/EFT"",
        ""DS/CAN/EFT""
      ]
    },    
    ""datacontenttype"": {
      ""description"": ""Should be application/json or avro/bytes"",
      ""type"": ""string"",
      ""minLength"": 5,
      ""maxLength"": 30
    },
    ""correlationid"": {
      ""description"": ""Correlation identification. Can be a GUID."",
      ""type"": ""string"",
      ""minLength"": 36,
      ""maxLength"": 36
    },
    ""topic"": {
      ""description"": ""Name of the topic in which the message is published"",
      ""type"": ""string"",
      ""minLength"": 5,
      ""maxLength"": 30
    },
    ""env"": {
      ""description"": ""Environment (ASMB, FNCT, INTG, ACCP, PROD)"",
      ""type"": ""string"",
      ""minLength"": 4,
      ""maxLength"": 4
    },    
    ""data"": {
      ""type"": ""object"",
	  ""properties"": {
        ""context"": {
          ""description"": ""Context"",
          ""type"": ""string"",
          ""minLength"": 1,
          ""maxLength"": 30
        },
		""cmfVersion"": {
		  ""description"": ""CMF Version"",
		  ""type"": ""string"",
		  ""minLength"": 1,
		  ""maxLength"": 5
		},
	    ""paymentId"": {
		  ""description"": ""Payment Transaction Id"",
		  ""type"": ""string"",
		  ""minLength"": 1,
          ""maxLength"": 10
        },
		""paymentMethod"": {
		  ""description"": ""Payment Method - Electronic Funds Transfer, Cheque"",
		  ""type"": ""string"",
		  ""enum"": [ ""EFT"", ""CHQ"" ]
		},
		""paymentType"": {
		  ""description"": ""Payment Type - Standard, Cancellation, Reversal"",
		  ""type"": ""string"",
		  ""enum"": [ ""STD"", ""CAN"", ""REV"" ]
		},
		""transactionType"": {
		  ""description"": ""Transaction Type - Credit (CR) or Debit (DR)"",
		  ""type"": ""string"",
          ""enum"": [ ""CR"", ""DR"" ]
		},
		""paymentNote"": {
		  ""description"": ""Payment Note"",
		  ""type"": ""string"",
		  ""maxLength"": 20
		},
		""systemCode"": {
		  ""description"": ""Payment Method - Electronic Funds Transfer, Cheque"",
		  ""type"": ""string"",
		  ""enum"": [ ""UNIFI"", ""UN"", ""CAN"" ]
		},
		""currency"": {
		  ""description"": ""Currency"",
		  ""type"": ""string"",
		  ""enum"": [ ""CAD"", ""USD"" ]
		},
		""companyCode"": {
		  ""description"": ""Company Code"",
		  ""type"": ""string"",
		  ""minLength"": 1,
		  ""maxLength"": 1
		},
		""authorizationNumber"": {
		  ""description"": ""Authorization Number - Unique ID identifying payment (IE. PaymentID)"",
		  ""type"": ""string"",
		  ""minLength"": 1,
		  ""maxLength"": 10
		},
		""contractDealerNumber"": {
		  ""description"": ""Contract Dealer Number"",
		  ""type"": ""string"",
		  ""minLength"": 1,
		  ""maxLength"": 15
		},
		""filingDate"": {
		  ""description"": ""Payment Date"",
		  ""type"": ""string"",
		  ""format"": ""date""
		},
		""languageCode"": {
		  ""description"": ""Language"",
		  ""type"": ""string"",
		  ""minLength"": 1,
		  ""maxLength"": 1
		},
		""amount"": {
		  ""description"": ""Payment Amount"",
		  ""type"": ""number""
		},
		""eftDetails"": {
		  ""type"": ""object"",
		  ""properties"": {
			""bankNumber"": {
			  ""type"": ""string"",
			  ""minLength"": 4,
			  ""maxLength"": 4
			},
			""branch"": {
			  ""type"": ""string"",
			  ""minLength"": 5,
			  ""maxLength"": 5
			},
			""bankAccount"": {
			  ""type"": ""string"",
			  ""minLength"": 18,
			  ""maxLength"": 18
			},
			""beneficiaryName"": {
			  ""type"": ""string"",
			  ""maxLength"": 30
			}
		  }
		},
		""chequeDetails"": {
		  ""type"": ""object"",
		  ""properties"": {
			""chequeNumber"": {
			  ""description"": ""Cheque Number"",
			  ""type"": ""string"",
			  ""minLength"": 1,
			  ""maxLength"": 10
			},
		    ""payeeName"": {
		      ""description"": ""Payee Name - Recipient of Cheque"",
              ""type"": ""string"",
              ""minLength"": 1,
              ""maxLength"": 75
		    },
			""address"": {
			  ""description"": ""Cheque Mailing Address"",
			  ""type"": ""object"",
			  ""properties"": {
				""addressLine1"": {
				  ""type"": ""string"",
				  ""maxLength"": ""75""
				},
				""addressLine2"": {
				  ""type"": ""string"",
				  ""maxLength"": ""75""
				},
				""addressLine3"": {
				  ""type"": ""string"",
				  ""maxLength"": ""75""
				},
				""addressLine4"": {
				  ""type"": ""string"",
				  ""maxLength"": ""75""
				},
				""addressLine5"": {
				  ""type"": ""string"",
				  ""maxLength"": ""75""
				}
			  }
		    }
		  }
		}
      }
    }
  }
}";
            var schema = await JsonSchema.FromJsonAsync(json);
            var generator = new CSharpGenerator(schema);

            //// Act
            var code = generator.GenerateFile("BankResultMessage");

            //// Assert
            Assert.Contains("public", code);
        }
    }
}

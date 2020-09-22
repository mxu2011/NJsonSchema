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
  ""title"": ""Bank Result Payment CMF"",
  ""description"": ""Bank Result Payment CMF"",
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
        ""SAL.PaymentSucceeded"",
        ""SAL.PaymentFailed""
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
        ""SAL/UNIFI/EFT"",
        ""SAL/UN/EFT"",
        ""SAL/CAN/EFT""
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
      ""description"": ""Environment (ASMB, FNCT, INTG, ACCP, PROD, etc.)"",
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
        ""bankReportDate"": {
          ""description"": ""Must be formatted by using the standard RFC3339"",
          ""type"": ""string"",
          ""format"": ""date""
        },
        ""bankReportName"": {
          ""description"": ""Name of Bank Report - EBR2131A, EBR2132A, EBR2133A, EBR2134A, EBR2135A"",
          ""type"": ""string"",
          ""minLength"": 1,
          ""maxLength"": 20
        },
        ""paymentMethod"": {
          ""description"": ""Payment Method - Electronic Funds Transfer"",
          ""type"": ""string"",
          ""enum"": [
            ""EFT""
          ]
        },
        ""languageCode"": {
          ""description"": ""Language"",
          ""type"": ""string"",
          ""minLength"": 1,
          ""maxLength"": 1
        },
        ""bankPaymentSuccessful"": {
          ""description"": ""Bank Transaction Status - was payment successful or failed?"",
          ""type"": ""boolean""
        },
        ""currency"": {
          ""description"": ""Currency"",
          ""type"": ""string"",
          ""enum"": [
            ""CAD"",
            ""USD""
          ]
        },
        ""companyCode"": {
          ""description"": ""Company Code"",
          ""type"": ""string"",
          ""minLength"": 1,
          ""maxLength"": 1
        },
        ""customerAccount"": {
          ""description"": ""Customer Account"",
          ""type"": ""string"",
          ""minLength"": 10,
          ""maxLength"": 10
        },
        ""authorizationNumber"": {
          ""description"": ""Authorization Number"",
          ""type"": ""string"",
          ""minLength"": 1,
          ""maxLength"": 18
        },
        ""contractDealerNumber"": {
          ""description"": ""Contract Dealer Number"",
          ""type"": ""string"",
          ""minLength"": 1,
          ""maxLength"": 15
        },
        ""depositDate"": {
          ""description"": ""Payment Deposit Date"",
          ""type"": ""string"",
          ""format"": ""date""
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

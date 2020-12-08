using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace Huddle.Todo.API.Tests
{
	public class Tests
	{
		IApi api;

		[SetUp]
		public void Setup()
		{
			api = new Api();
		}

		[Test]
		public void GIVEN_TodoAPIEndpoint_WHEN_SendingRequest_THEN_TheResponseBodyShouldHaveValidDataTypes()
		{
			JSchema todoSchema = new JSchema
			{
				Type = JSchemaType.Array,
				Items = {
					new JSchema {
						Type = JSchemaType.Object,
						Properties = {
							{
								"userId",
								new JSchema {
									Type = JSchemaType.Integer
								}
							},
							{
								"id",
								new JSchema {
									Type = JSchemaType.Integer
								}
							},
							{
								"title",
								new JSchema {
									Type = JSchemaType.String
								}
							},
							{
								"completed",
								new JSchema {
									Type = JSchemaType.Boolean
								}
							}
						}
					}
				}
			};
			var response = api.GetAllTodos();
			JArray.Parse(response.Content).IsValid(todoSchema).Should().BeTrue();
		}
	}
}
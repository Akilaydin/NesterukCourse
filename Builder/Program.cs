#region
using System.Text;

using static System.Console;
#endregion

Write(new ClassBuilder("Person")
	.AddField("Name", "string", "public")
	.AddField("Age", "int", "private")
	.AddField("Position", "string", "private")
	.Build());

public class ClassBuilder(string className)
{
	private List<Field> _fields = [];
	
	public Class Build()
	{
		return new Class(className, _fields);
	}

	public ClassBuilder AddField(string fieldName, string fieldType, string accessModifier)
	{
		_fields.Add(new Field(fieldName,fieldType, accessModifier));
		
		return this;
	}
}

public record Class(string ClassName, List<Field> Fields)
{
	public override string ToString()
	{
		var stringBuilder = new StringBuilder();

		stringBuilder.AppendLine($"public class {ClassName}");
		stringBuilder.AppendLine("{");

		foreach (var field in Fields)
		{
			stringBuilder.AppendLine($"    {field.ToString()}");
		}

		stringBuilder.AppendLine("}");

		return stringBuilder.ToString();
	}
}
public record Field(string FieldName, string FieldType, string AccessModifier)
{
	public override string ToString()
	{
		return $"{AccessModifier} {FieldType} {FieldName}";
	}
}
# Builder

- Fluent builder это когда вызовы можно чейнить друг за другом, как почти в каждом билдере
- Интересная идея добавить статический метод в класс, который мы билдим (то есть для HtmlBuilder.cs добавить в HtmlElement.cs статик метод, который будет называться Create и будет возвращать билдер)
- Также чтобы убрать возможность создавать что-то без билдера, можно сделать конструкторы у объектов, которые строим, приватными или защищенными. То есть у HtmlElements.cs сделать приватным или защищенным

- Еще интересная идея это сделать оператор неявного приведения из типа билдера в тип объекта, который строим. Это позволит делать так
```
public static implicit operator HtmlElement(HtmlBuilder builder)
{
  return builder.root;
} 
HtmlElement root = HtmlElement //Здесь получается привести HtmlBuilder из AddChildFluent из-за переопределения
.Create("ul")
.AddChildFluent("li", "hello")
.AddChildFluent("li", "world");
WriteLine(root);

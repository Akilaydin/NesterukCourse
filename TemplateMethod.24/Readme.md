# Template Method

- Суть паттерна в том, чтобы, как и в паттерне “Strategy” выделить специфику алгоритма и общую часть. Общая часть и будет шаблонным методом. В стратегии специфика выносилась в отдельные классы под интерфейсом, реализацию которого можно подменять. В шаблонном методе же специфика выносится в дочерние классы, в то время как общая часть лежит в родительском классе
- Интересным подходом является передавать детали не в виде реализации методов в дочерних классах, а в виде пробрасывания их как делегатов в класс